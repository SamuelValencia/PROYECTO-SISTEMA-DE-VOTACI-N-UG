using SistemaVotacion.modelo;
using SistemaVotacion.vista;
using System;
using System.Drawing;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SistemaVotacion.conectar;

namespace SistemaVotacion.controlador
{
    public class FrmListaCandidatas_Controlador
    {
        private FrmListaCandidatas vista;
        private Galeria galeria;
        private string nombreUnico;
        private int idCandidata;

        public FrmListaCandidatas_Controlador()
        {
            nombreUnico = "";
            CargarCandidatas();
            idCandidata = 0;
        }

        public FrmListaCandidatas_Controlador(FrmListaCandidatas vista, Galeria galeria)
        {
            this.vista = vista;
            this.galeria = galeria;
            this.nombreUnico = "";
            this.vista.btnAgregarFoto.Click += BtnAgregarFoto_Click;
            this.vista.btnGaleria.Click += BtnGaleria_Click;
            this.vista.btnGuardar.Click += BtnGuardar_Click;
            this.vista.dgvDatos.CellClick+= DgvDatos_CellClick;
            CargarCandidatas();
            idCandidata = 0;
        }

        private void CargarCandidatas()
        {
            List<Candidata> candidatas = Candidata_con.ListarCandidatas();
            for(int i=0; i< candidatas.Count; i++)
            {
                Candidata c = candidatas[i];
                vista.dgvDatos.Rows.Add(c.IdCandidata, c.Nombre, c.Apellidos, c.FechaNac, c.Medida_cintura, c.Medida_cadera, c.Medida_busto, c.Peso, c.Altura);
            }
        }

        private void BtnAgregarFoto_Click(object sender, EventArgs e)
        {
            vista.ofd_foto.Filter = "Archivos de imagen|*.jpg;*.jpeg;*.png;*.gif;*.bmp|Todos los archivos|*.*";
            DialogResult result = vista.ofd_foto.ShowDialog();
            if (result == DialogResult.OK)
            {
                string rutaImagenOriginal = vista.ofd_foto.FileName;
                string nombreArchivoOriginal = Path.GetFileName(rutaImagenOriginal);
                nombreUnico = DateTime.Now.ToString("yyyyMMddHHmmss") + ".png";
                string rutaDestino = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "candidatas", nombreUnico);
                string directorioDestino = Path.GetDirectoryName(rutaDestino);
                if (!Directory.Exists(directorioDestino))
                {
                    Directory.CreateDirectory(directorioDestino);
                }

                File.Copy(rutaImagenOriginal, rutaDestino, true);

                vista.pbImagen.Image = Image.FromFile(rutaDestino);
            }
        }

        private void BtnGaleria_Click(object sender, EventArgs e)
        {
            if (idCandidata != 0)
            {
                FrmGaleriaCandidata frm = new FrmGaleriaCandidata();
                FrmGaleriaCandidata_Controlador controlador = new FrmGaleriaCandidata_Controlador(frm, new Galeria(), idCandidata);
                controlador.Iniciar();
            }
            else
            {
                MessageBox.Show("Seleccione una candidata de la tabla");
            }
            
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (idCandidata == 0)
            {
                MessageBox.Show("Seleccione una candidata de la tabla");
            }
            else
            {
                string msj = ValidarDatos();
                if (msj.Equals(""))
                {
                    galeria = new Galeria();
                    galeria.IdCandidata = idCandidata;
                    galeria.Foto = nombreUnico;
                    galeria.Titulo = vista.txtTitulo.Text;
                    galeria.Descripcion = vista.txtDescripcion.Text;
                    galeria.Estado = 0;
                    if (Galeria_con.Insertar(galeria))
                    {
                        MessageBox.Show("Nueva foto agregado a la candidata "+vista.txtNombre.Text, "Agregar Foto");
                        idCandidata = 0;
                        nombreUnico = "";
                        vista.txtNombre.Text = "";
                        vista.txtApellido.Text = "";
                        vista.txtTitulo.Text = "";
                        vista.txtDescripcion.Text = "";
                        vista.pbImagen.Image = null;
                    }
                    else
                    {
                        MessageBox.Show("Error al agregar foto a candidata", "Agregar Foto");
                    }
                }
                else
                {
                    MessageBox.Show(msj, "Agregar Foto");
                }
            }
        }

        private string ValidarDatos()
        {
            string msj = "";
            if (nombreUnico.Equals("")) msj += "Falta ingresar foto\n";
            if (vista.txtTitulo.Text.Equals("")) msj += "Falta ingresar titulo de foto\n";
            if (vista.txtDescripcion.Text.Equals("")) msj += "Falta ingresar descripción de foto\n";
            return msj;
        }

        private void DgvDatos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow filaSeleccionada = vista.dgvDatos.Rows[e.RowIndex];

                idCandidata = int.Parse(filaSeleccionada.Cells[0].Value.ToString());
                vista.txtNombre.Text = filaSeleccionada.Cells[1].Value.ToString();
                vista.txtApellido.Text = filaSeleccionada.Cells[2].Value.ToString();
            }
        }

    }
}
