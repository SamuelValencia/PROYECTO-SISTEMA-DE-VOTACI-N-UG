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
    public class FrmGaleriaCandidata_Controlador
    {
        private FrmGaleriaCandidata vista;
        private Galeria galeria;

        public FrmGaleriaCandidata_Controlador(int idCandidata)
        {
            CargarGaleria(idCandidata);
        }

        public FrmGaleriaCandidata_Controlador(FrmGaleriaCandidata vista, Galeria galeria, int idCandidata)
        {
            this.vista = vista;
            this.galeria = galeria;
            CargarGaleria(idCandidata);

        }

        private void CargarGaleria(int idCandidata)
        {
            vista.tableLayoutPanel1.AutoSize = true;
            vista.tableLayoutPanel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            vista.tableLayoutPanel1.ColumnCount = 4;
            List<Galeria> galerias = Galeria_con.ListarGaleria_IDCandidata(idCandidata);
            foreach (Galeria g in galerias)
            {
                Panel panelImagen = new Panel
                {
                    BorderStyle = BorderStyle.Fixed3D,
                    Margin = new Padding(15),
                    Size= new Size(200, 300),
                };


                PictureBox pictureBox = new PictureBox
                {

                    Image = Image.FromFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "candidatas", g.Foto)),
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Size = new Size(190, 190),
                };

                Label label1 = new Label
                {
                    Text = "Titulo: "+g.Titulo,
                    Size = new Size(100, 30),
                    Dock = DockStyle.Bottom,
                    ForeColor = Color.White,
                    Font = new Font("Arial", 12, FontStyle.Regular),
                    TextAlign = ContentAlignment.MiddleCenter 
                };

                Label label2 = new Label
                {
                    Text = "Descripción: " + g.Descripcion,
                    Size = new Size(100, 60),
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
