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
    public class FrmRegistrarCandidata_Controlador
    {
        private FrmRegistrarCandidata vista;
        private Candidata candidata;
        private Galeria galeria;
        private string nombreUnico;


        public FrmRegistrarCandidata_Controlador()
        {
            nombreUnico = "";
        }

        public FrmRegistrarCandidata_Controlador(FrmRegistrarCandidata vista, Candidata candidata, Galeria galeria)
        {
            this.vista = vista;
            this.candidata = candidata;
            this.galeria = galeria;
            this.nombreUnico = "";
            this.vista.btnAgregar.Click += BtnAgregar_Click;
            this.vista.btnAgregarFoto.Click += BtnAgregarFoto_Click;
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            string msj = validarCamposVacios();
            if (msj.Equals(""))
            {
                candidata = new Candidata();
                galeria = new Galeria();
                candidata.Nombre = vista.txtNombre.Text;
                candidata.Apellidos = vista.txtApellido.Text;
                candidata.FechaNac = vista.dtpFechaNac.Value.ToString("yyyy-MM-dd");
                candidata.Formacion_academica = vista.txtFormAcademica.Text;
                candidata.Medida_cintura = Convert.ToDouble(vista.numUpMedidaCintura.Value);
                candidata.Medida_cadera= Convert.ToDouble(vista.numUpMedidaCadera.Value);
                candidata.Medida_busto = Convert.ToDouble(vista.numUpMedidaCadera.Value);
                candidata.Color_cabello = vista.txtColorCabello.Text;
                candidata.Color_ojos= vista.txtColorOjos.Text;
                candidata.Peso = Convert.ToDouble(vista.numUpPeso.Value);
                candidata.Altura= Convert.ToDouble(vista.numUpAltura.Value);
                candidata.Habilidades = vista.txtHabilidades.Text;
                candidata.Intereres = vista.txtIntereses.Text;
                candidata.Pasatiempos = vista.txtPasatiempo.Text;
                candidata.Aspiraciones_futuro = vista.txtAspiraciones.Text;
                candidata.PuntuacionMissFotogenica = 0;
                candidata.PuntuacionReina = 0;
                galeria.Foto = nombreUnico;
                galeria.Titulo = vista.txtTitulo.Text;
                galeria.Descripcion = vista.txtDescripcion.Text;
                galeria.Estado = 1;

                int idCandidata = Candidata_con.Insertar(candidata);
                if (idCandidata != -1)
                {
                    galeria.IdCandidata = idCandidata;
                    Galeria_con.Insertar(galeria);
                    Limpiar();
                    MessageBox.Show("Se registró nueva candidata", "Registrar Candidata");
                }
                else
                {
                    MessageBox.Show("Error al intentar insertar nueva candidata", "Registrar Candidata");
                }

            }
            else {
                MessageBox.Show(msj,"Registrar Candidata");
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

        private string validarCamposVacios()
        {
            string msj = "";
            if (vista.txtNombre.Text.Equals("")) msj += "Falta ingresar nombre\n";
            if (vista.txtApellido.Text.Equals("")) msj += "Falta ingresar apellido\n";
            if (vista.txtFormAcademica.Text.Equals("")) msj += "Falta ingresar formación académica\n";
            if (vista.txtColorCabello.Text.Equals("")) msj += "Falta ingresar color de cabello\n";
            if (vista.txtColorOjos.Text.Equals("")) msj += "Falta ingresar color de ojos\n";
            if (vista.txtHabilidades.Text.Equals("")) msj += "Falta ingresar habilidades\n";
            if (vista.txtIntereses.Text.Equals("")) msj += "Falta ingresar intereses\n";
            if (vista.txtPasatiempo.Text.Equals("")) msj += "Falta ingresar pasatiempo\n";
            if (vista.txtAspiraciones.Text.Equals("")) msj += "Falta ingresar aspiraciones al futuro\n";
            if(nombreUnico.Equals("")) msj+="Falta ingresar foto\n";
            if (vista.txtTitulo.Text.Equals("")) msj += "Falta ingresar titulo de foto\n";

            if (vista.txtDescripcion.Text.Equals("")) msj += "Falta ingresar descripción de foto\n";
            return msj;
        }

        private void Limpiar()
        {
            vista.txtNombre.Text = "";
            vista.txtApellido.Text = "";
            vista.txtColorCabello.Text = "";
            vista.txtColorOjos.Text = "";
            vista.txtHabilidades.Text = "";
            vista.txtIntereses.Text = "";
            vista.txtPasatiempo.Text = "";
            vista.txtAspiraciones.Text = "";
            nombreUnico = "";
            vista.txtTitulo.Text = "";
            vista.txtDescripcion.Text = "";
            vista.pbImagen.Image = null;
            vista.numUpMedidaCadera.Value = 50;
            vista.numUpAltura.Value = 100;
            vista.numUpPeso.Value = 50;
            vista.numUpMedidaCintura.Value = 50;
            vista.numUpMedBusto.Value = 50;

        }
    }
}
