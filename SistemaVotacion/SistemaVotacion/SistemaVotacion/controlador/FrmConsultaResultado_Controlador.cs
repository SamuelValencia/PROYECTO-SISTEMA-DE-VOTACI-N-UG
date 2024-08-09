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
    public class FrmConsultaResultado_Controlador
    {
        private FrmConsultaResultado vista;
        private Candidata candidata;

        public FrmConsultaResultado_Controlador()
        {
            CargarCandidatas();
        }

        public FrmConsultaResultado_Controlador(FrmConsultaResultado vista, Candidata candidata)
        {
            this.vista = vista;
            this.candidata = candidata;
            CargarCandidatas();

        }

        private void CargarCandidatas()
        {
            vista.tableLayoutPanel1.AutoSize = true;
            vista.tableLayoutPanel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            vista.tableLayoutPanel1.ColumnCount = 4;
            Candidata canReina = Candidata_con.ObtenerGanadoraReina();
            Candidata canMissFoto = Candidata_con.ObtenerGanadoraMissFotogenica();
            if (canReina != null)
            {
                vista.pb1.Image = Image.FromFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "candidatas", canReina.FotoP));
                vista.txtReina.Text = canReina.Nombre + "\n" + canReina.Apellidos+"\nPuntuación: "+ canReina.PuntuacionReina;
            }

            if (canMissFoto != null)
            {
                vista.pb2.Image = Image.FromFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "candidatas", canMissFoto.FotoP));
                vista.TxtFotgenica.Text = canMissFoto.Nombre + "\n" + canMissFoto.Apellidos + "\nPuntuación: " + canMissFoto.PuntuacionMissFotogenica;
            }


            List<Candidata> candidatas = Candidata_con.ListarCandidatas();
            foreach (Candidata c in candidatas)
            {
                Panel panelImagen = new Panel
                {
                    BorderStyle = BorderStyle.FixedSingle,
                    Margin = new Padding(10),
                    Size = new Size(250, 300),
                };


                PictureBox pictureBox = new PictureBox
                {
                    Image = Image.FromFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "candidatas", c.FotoP)),
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Size = new Size(240, 190),
                };

                Label label1 = new Label
                {
                    Text = "Nombre: " + c.Nombre,
                    Size = new Size(240, 20),
                    Dock = DockStyle.Bottom,
                    ForeColor = Color.White,
                    Font = new Font("Arial", 10, FontStyle.Bold),
                    TextAlign = ContentAlignment.MiddleCenter
                };

                Label label2 = new Label
                {
                    Text = "Apellidos: " + c.Apellidos,
                    Size = new Size(240, 20),
                    Dock = DockStyle.Bottom,
                    ForeColor = Color.White,
                    Font = new Font("Arial", 10, FontStyle.Bold),
                    TextAlign = ContentAlignment.MiddleCenter
                };

                Label label3 = new Label
                {
                    Text = "Puntuación Reina: " + c.PuntuacionReina,
                    Size = new Size(240, 20),
                    ForeColor=Color.Red,
                    Font = new Font("Arial", 10, FontStyle.Bold),
                    Dock = DockStyle.Bottom,
                    TextAlign = ContentAlignment.MiddleCenter
                };

                Label label4 = new Label
                {
                    Text = "Puntuación Miss Fotogénica: " + c.PuntuacionMissFotogenica,
                    Size = new Size(240, 20),
                    ForeColor = Color.Red,
                    Font = new Font("Arial", 10, FontStyle.Bold),
                    Dock = DockStyle.Bottom,
                    TextAlign = ContentAlignment.MiddleCenter
                };

                panelImagen.Controls.Add(pictureBox);
                panelImagen.Controls.Add(label1);
                panelImagen.Controls.Add(label2);
                panelImagen.Controls.Add(label3);
                panelImagen.Controls.Add(label4);
                vista.tableLayoutPanel1.Controls.Add(panelImagen);

            }
        }

  
    }
}
