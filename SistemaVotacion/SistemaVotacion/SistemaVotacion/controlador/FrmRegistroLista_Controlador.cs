using SistemaVotacion.conectar;
using SistemaVotacion.modelo;
using SistemaVotacion.vista;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaVotacion.controlador
{
    public class FrmRegistroLista_Controlador
    {
        private FrmRegistroLista vista;
        private Lista lista;
        private string nombreUnico;
        private int opcion;
        private int id;

        /*public FrmRegistroLista_Controlador(int opcion,int id)
        {
            nombreUnico = "";
            CargarCarreras();
            this.opcion = opcion;
            this.id = id;
            CargarDatos();
        }*/

        public FrmRegistroLista_Controlador(FrmRegistroLista vista, Lista lista, int opcion,int id)
        {
            this.vista = vista;
            this.lista = lista;
            this.nombreUnico = "";
            CargarCarreras();
            this.vista.btnAgregar.Click += BtnAgregar_Click;
            this.vista.btnAgregarFoto.Click += BtnAgregarFoto_Click;
            this.vista.btnPro.Click += BtnAgregarPropuesta_Click;
            this.vista.btnQuitar.Click += BtnQuitar_Click;
            this.vista.btnQuitarFoto.Click += BtnQuitarFoto_Click;
            this.vista.txtNomLista.KeyPress += new KeyPressEventHandler(txtNomLista_KeyPress);
            this.vista.txtNomPresidente.KeyPress += new KeyPressEventHandler(txtNomLista_KeyPress);
            this.vista.txtNomSecretario.KeyPress += new KeyPressEventHandler(txtNomLista_KeyPress);
            this.vista.txtNomVocal.KeyPress += new KeyPressEventHandler(txtNomLista_KeyPress);
            this.opcion = opcion;
            this.id = id;

            CargarDatos();
        }

        private void CargarDatos()
        {
            if (opcion == 2)
            {
                this.lista = Lista_con.ObtenerListaPorId(id);
                List<Propuesta> propuestas = Propuesta_con.ObtenerPropuestasPorIdLista(id);

                this.vista.txtNomLista.Text = lista.NomLista;
                vista.txtNomPresidente.Text = lista.NomPresidente;
                vista.txtNomSecretario.Text = lista.NomSecretario;
                vista.txtNomVocal.Text = lista.NomPrimerVocal;
                for(int i=0; i<vista.cbCarrera.Items.Count; i++)
                {
                    Carrera c = (Carrera)vista.cbCarrera.Items[i];
                    if (c.IdCarrera == lista.Carrera)
                    {
                        vista.cbCarrera.SelectedIndex = i;
                        break;
                    }

                }

                vista.listPropuestas.Items.Clear();
                for(int i=0; i<propuestas.Count; i++)
                {
                    this.vista.listPropuestas.Items.Add(propuestas[i].Descripcion);
                }

                vista.txtDescripcion.Text = lista.Descripcion;
                if (!string.IsNullOrEmpty(lista.FotoP))
                {
                    string rutaImagen = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "foto_lista", lista.FotoP);
                    if (File.Exists(rutaImagen))
                    {
                        vista.pbImagen.Image = Image.FromFile(rutaImagen);
                    }
                }

            }
        }

        private void txtNomLista_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true; 
            }
        }


        private void BtnQuitarFoto_Click(object sender, EventArgs e)
        {
            vista.pbImagen.Image = null;
            nombreUnico = "";
        }

        private void BtnQuitar_Click(object sender, EventArgs e)
        {
            if (vista.listPropuestas.SelectedIndex != -1)
            {
                int indiceSeleccionado = vista.listPropuestas.SelectedIndex;
                vista.listPropuestas.Items.RemoveAt(indiceSeleccionado);
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un fila de la lista de propuestas para eliminar.", "Eliminar Propuesta");
            }
        }

        private void BtnAgregarPropuesta_Click(object sender, EventArgs e)
        {
            string propuesta = vista.txtPropuesta.Text;
            if (propuesta.Equals(""))
            {
                MessageBox.Show("Ingrese una propuesta");
            }
            else
            {
                vista.listPropuestas.Items.Add(propuesta);
                vista.txtPropuesta.Text = "";
            }
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            if (opcion == 1)
            {
                string msj = validarCamposVacios();
                if (msj.Equals(""))
                {
                    Carrera c = null;
                    Propuesta p = new Propuesta();
                    lista = new Lista();

                    lista.NomLista = vista.txtNomLista.Text;
                    lista.NomPresidente = vista.txtNomPresidente.Text;
                    lista.NomSecretario = vista.txtNomSecretario.Text;
                    lista.NomPrimerVocal = vista.txtNomVocal.Text;
                    lista.Descripcion = vista.txtDescripcion.Text;
                    if (vista.cbCarrera.SelectedIndex >= 0)
                    {
                        c = (Carrera)vista.cbCarrera.SelectedItem;
                        lista.Carrera = c.IdCarrera;
                    }
                    lista.FotoP = nombreUnico;
                    lista.CantVotos = 0;


                    int idLista = Lista_con.Insertar(lista);
                    if (idLista != -1)
                    {
                        foreach (object item in vista.listPropuestas.Items)
                        {
                            p = new Propuesta();
                            p.IdLista = idLista;
                            p.Descripcion = item.ToString();
                            Propuesta_con.Insertar(p);
                        }
 
                        MessageBox.Show("Se registró nueva lista", "Registrar Lista");
                        Limpiar();
                    }
                    else
                    {
                        MessageBox.Show("Error al intentar registrar nueva lista", "Registrar Lista");
                    }

                }
                else
                {
                    MessageBox.Show(msj, "Registrar Lista");
                }
            }
            else//modificar
            {
                string msj = validarCamposVacios();
                if (msj.Equals(""))
                {
                    Carrera c = null;
                    Propuesta p = new Propuesta();
                    if (nombreUnico.Equals("")) nombreUnico = lista.FotoP;
                    lista = new Lista();
                    lista.IdLista = id;
                    lista.NomLista = vista.txtNomLista.Text;
                    lista.NomPresidente = vista.txtNomPresidente.Text;
                    lista.NomSecretario = vista.txtNomSecretario.Text;
                    lista.NomPrimerVocal = vista.txtNomVocal.Text;
                    lista.Descripcion = vista.txtDescripcion.Text;
                    if (vista.cbCarrera.SelectedIndex >= 0)
                    {
                        c = (Carrera)vista.cbCarrera.SelectedItem;
                        lista.Carrera = c.IdCarrera;
                    }
                    lista.FotoP = nombreUnico;


                    bool estado = Lista_con.Actualizar(lista);
                    if (estado)
                    {
                        Propuesta_con.EliminarPropuestasPorIdLista(id);
                        foreach (object item in vista.listPropuestas.Items)
                        {
                            p = new Propuesta();
                            p.IdLista = id;
                            p.Descripcion = item.ToString();
                            Propuesta_con.Insertar(p);
                        }

                        MessageBox.Show("Se actualizó la lista", "Actualizar Lista");
                    }
                    else
                    {
                        MessageBox.Show("Error al intentar actualizar la lista", "Actualizar Lista");
                    }
                }
                else
                {
                    MessageBox.Show(msj, "Actualizar Lista");
                }
            }
        }

        private void BtnAgregarFoto_Click(object sender, EventArgs e)
        {
            try
            {
                vista.ofd_foto.Filter = "Archivos de imagen|*.jpg;*.jpeg;*.png;*.gif;*.bmp|Todos los archivos|*.*";
                DialogResult result = vista.ofd_foto.ShowDialog();
                if (result == DialogResult.OK)
                {
                    string rutaImagenOriginal = vista.ofd_foto.FileName;
                    string nombreArchivoOriginal = Path.GetFileName(rutaImagenOriginal);
                    nombreUnico = DateTime.Now.ToString("yyyyMMddHHmmss") + ".png";
                    string rutaDestino = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "foto_lista", nombreUnico);
                    string directorioDestino = Path.GetDirectoryName(rutaDestino);
                    if (!Directory.Exists(directorioDestino))
                    {
                        Directory.CreateDirectory(directorioDestino);
                    }

                    File.Copy(rutaImagenOriginal, rutaDestino, true);

                    vista.pbImagen.Image = Image.FromFile(rutaDestino);
                }
            }
            catch(OutOfMemoryException ex)
            {
                MessageBox.Show("Memoria insuficiente para cargar la imagen. Por favor, elija una imagen más pequeña.", "Error de memoria");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void CargarCarreras()
        {
            vista.cbCarrera.Items.Clear();
            List<Carrera> carreras = Carrera_con.Listar();
            for(int i=0; i<carreras.Count; i++)
            {
                vista.cbCarrera.Items.Add(carreras[i]);
            }
        }

        private string validarCamposVacios()
        {
            string msj = "";
            if (vista.txtNomLista.Text.Equals("")) msj += "Falta ingresar nombre de lista\n";
            if (vista.txtNomPresidente.Text.Equals("")) msj += "Falta ingresar nombre del presidente\n";
            if (vista.txtNomSecretario.Text.Equals("")) msj += "Falta ingresar nombre del secretario\n";
            if (vista.txtNomVocal.Text.Equals("")) msj += "Falta ingresar nombre del vocal\n";
            if (nombreUnico.Equals("")) msj += "Falta ingresar foto\n";
            if (vista.cbCarrera.SelectedIndex<0) msj += "Falta seleccionar carrera\n";
            return msj;
        }

        private void Limpiar()
        {
            vista.listPropuestas.Items.Clear();
            vista.pbImagen.Image = null;
            vista.txtNomLista.Text = "";
            vista.txtNomPresidente.Text = "";
            vista.txtNomSecretario.Text = "";
            vista.txtNomVocal.Text = "";
            vista.txtDescripcion.Text = "";
            nombreUnico = "";
            vista.pbImagen.Image = null;
            if (vista.cbCarrera.SelectedIndex >= 0) vista.cbCarrera.SelectedIndex = 0;
        }
    }
}
