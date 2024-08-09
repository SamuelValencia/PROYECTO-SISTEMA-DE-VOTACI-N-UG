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
    public class FrmCandidata_Controlador
    {
        private FrmCandidatas vista;
        private Candidata candidata;
        private string matricula;

        public FrmCandidata_Controlador(FrmCandidatas vista, Candidata candidata,string matricula)
        {
            this.vista = vista;
            this.candidata = candidata;
            this.matricula = matricula;
            CargarCandidata();

        }

        private void CargarCandidata()
        {
            vista.tableLayoutPanel1.AutoSize = true;
            vista.tableLayoutPanel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            vista.tableLayoutPanel1.ColumnCount = 4;
            List<Candidata> candidatas = Candidata_con.ListarCandidatas();
            foreach (Candidata c in candidatas)
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
                    Image = Image.FromFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "candidatas", c.FotoP)),
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Location = new Point(10, 10),
                    Size = new Size(180, 200),
                };

                Label label1 = new Label
                {
                    Text = c.Nombre+" "+c.Apellidos,
                    Size = new Size(180, 30),
                    Dock = DockStyle.Bottom,
                    ForeColor = Color.White,
                    Font = new Font("Arial", 12, FontStyle.Regular),
                    TextAlign = ContentAlignment.MiddleCenter
                };

                Button button = new Button
                {
                    Text = "Ver perfil",
                    Size = new Size(180, 30),
                    Dock = DockStyle.Bottom,
                    ForeColor = Color.White,
                    Font = new Font("Arial", 12, FontStyle.Regular),
                    TextAlign = ContentAlignment.MiddleCenter,
                    BackColor = Color.FromArgb(245, 160, 84),
                    Tag = c.IdCandidata
                };

                button.Click += BtnPerfil_Click;



                panelImagen.Controls.Add(pictureBox);
                panelImagen.Controls.Add(label1);
                panelImagen.Controls.Add(button);
                vista.tableLayoutPanel1.Controls.Add(panelImagen);

            }
        }

        private void BtnPerfil_Click(object sender, EventArgs e)
        {
            if (sender is Button clickedButton)
            {
                int idCandidata = Convert.ToInt32(clickedButton.Tag);
                FrmPerfilCandidata frm = new FrmPerfilCandidata();
                FrmPerfilCandidata_Controlador controlador = new FrmPerfilCandidata_Controlador(frm, new Candidata(), idCandidata, matricula);
                controlador.Iniciar();
            }
        }
    }
}
