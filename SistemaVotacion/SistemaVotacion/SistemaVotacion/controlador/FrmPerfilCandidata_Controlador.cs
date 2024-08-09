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
    public class FrmPerfilCandidata_Controlador
    {
        private FrmPerfilCandidata vista;
        private Candidata candidata;
        private string matricula;
        private int idCandidata;

        public FrmPerfilCandidata_Controlador(FrmPerfilCandidata vista, Candidata candidata, int idCandidata, string matricula)
        {
            this.matricula = matricula;
            this.vista = vista;
            this.candidata = candidata;
            this.idCandidata = idCandidata;
            candidata = Candidata_con.BuscarCandidata(idCandidata);
            this.vista.btnVotarFotgenic.Click += BtnVotarFotogenica_Click;
            this.vista.btnVotarReina.Click += BtnVotarReina_Click;
            if (candidata!=null)
            {
                CargarCandidata(candidata);
                CargarGaleria(candidata.IdCandidata);
            }
        }

        private void BtnVotarFotogenica_Click(object sender, EventArgs e)
        {
            if (Votacion_con.BuscarVotacionMissFotogenica(matricula))
            {
                MessageBox.Show("Usted ya realizó la votación por Miss Fotogénica");
            }
            else
            {
                Votacion v = new Votacion();
                v.IdCandidata = idCandidata;
                v.Matricula = matricula;
                v.Tipo = 1;
                if (Candidata_con.AumentarPuntuacionMissFotogenica(v))
                {
                    Votacion_con.Insertar(v);
                    MessageBox.Show("Realizó su votación exitosamente por Miss Fotogénica");
                }
                else
                {
                    MessageBox.Show("Error al votar por Miss Fotogénica");
                }
            }
        }

        private void BtnVotarReina_Click(object sender, EventArgs e)
        {
            if (Votacion_con.BuscarVotacionReinaa(matricula))
            {
                MessageBox.Show("Usted ya realizó la votación por candidata a Reina");
            }
            else
            {
                Votacion v = new Votacion();
                v.IdCandidata = idCandidata;
                v.Matricula = matricula;
                v.Tipo = 2;
                if (Candidata_con.AumentarPuntuacionReina(v))
                {
                    Votacion_con.Insertar(v);
                    MessageBox.Show("Realizó su votación exitosamente por candidata a Reina");
                }
                else
                {
                    MessageBox.Show("Error al votar por Miss Fotogénica");
                }
            }
        }

        private void CargarCandidata(Candidata c)
        {
            vista.txtNombre.Text = c.Nombre;
            vista.txtApellido.Text = c.Apellidos;
            vista.txtFecha.Text = c.FechaNac;
            vista.txtFormAcademica.Text = c.Formacion_academica;
            vista.txtCintura.Text = c.Medida_cintura+"";
            vista.txtCadera.Text = c.Medida_cadera + "";
            vista.txtAltura.Text = c.Altura + "";
            vista.txtBusto.Text = c.Medida_busto+"";
            vista.txtPeso.Text = c.Peso + "";
            vista.txtColorCabello.Text = c.Color_cabello;
            vista.txtColorOjos.Text = c.Color_ojos;
            vista.txtHabilidades.Text = c.Habilidades;
            vista.txtIntereses.Text = c.Intereres;
            vista.txtPasatiempo.Text = c.Pasatiempos;
            vista.txtAspiraciones.Text = c.Aspiraciones_futuro;
        }

        private void CargarGaleria(int idCandidata)
        {
            vista.tableLayoutPanel1.AutoSize = true;
            vista.tableLayoutPanel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            vista.tableLayoutPanel1.ColumnCount = 1;
            List<Galeria> galerias = Galeria_con.ListarGaleria_IDCandidata(idCandidata);
            foreach (Galeria g in galerias)
            {
                Panel panelImagen = new Panel
                {
                    BorderStyle = BorderStyle.Fixed3D,
                    Margin = new Padding(15),
                    Size = new Size(200, 300),
                    BackColor = Color.FromArgb(191, 125, 66)
                };


                PictureBox pictureBox = new PictureBox
                {
                    Image = Image.FromFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "candidatas", g.Foto)),
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Location= new Point(10, 10),
                    Size = new Size(180, 200)
                   
                };

                Label label1 = new Label
                {
                    Text = "Titulo: " + g.Titulo,
                    Size = new Size(200, 20),
                    Dock = DockStyle.Bottom,
                    ForeColor = Color.White,
                    Font = new Font("Arial", 12, FontStyle.Regular),
                    TextAlign = ContentAlignment.MiddleCenter
                };

                Label label2 = new Label
                {
                    Text = "Descripción: " + g.Descripcion,
                    Size = new Size(200, 20),
                    Dock = DockStyle.Bottom,
                    ForeColor = Color.White,
                    Font = new Font("Arial", 12, FontStyle.Regular),
                    TextAlign = ContentAlignment.MiddleCenter
                };

                panelImagen.Controls.Add(pictureBox);
                panelImagen.Controls.Add(label1);
                panelImagen.Controls.Add(label2);
                vista.tableLayoutPanel1.Controls.Add(panelImagen);

            }
        }

        public void Iniciar()
        {
            this.vista.ShowDialog();
        }
    }
}
