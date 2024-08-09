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
    public class FrmResultado_Controlador
    {
        private FrmResultado vista;
        private Lista lista;

        public FrmResultado_Controlador(FrmResultado vista, Lista lista)
        {
            this.vista = vista;
            this.lista = lista;
            CargarLista();

        }

        private void CargarLista()
        {
            // Crear un Panel con AutoScroll para contener el TableLayoutPanel
            Panel panelScroll = new Panel
            {
                AutoScroll = true, // Habilitar el scroll automático
                Dock = DockStyle.Fill, // Hacer que el panel ocupe todo el espacio disponible
            };

            vista.tableLayoutPanel1.AutoSize = true;
            vista.tableLayoutPanel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            vista.tableLayoutPanel1.ColumnCount = 4;

            List<Lista> listas = Lista_con.Listar();
            int total = 0;
            foreach (Lista c in listas)
            {
                total += c.CantVotos;
            }

            foreach (Lista c in listas)
            {
                Panel panelImagen = new Panel
                {
                    BorderStyle = BorderStyle.Fixed3D,
                    Margin = new Padding(15),
                    Size = new Size(200, 300),
                    BackColor = Color.FromArgb(25, 61, 111)
                };

                Label label1 = new Label
                {
                    Text = c.NomLista,
                    Size = new Size(180, 30),
                    Location = new Point(10, 10),
                    ForeColor = Color.White,
                    Font = new Font("Arial", 12, FontStyle.Regular),
                    TextAlign = ContentAlignment.MiddleCenter
                };

                PictureBox pictureBox = new PictureBox
                {
                    Image = Image.FromFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "foto_lista", c.FotoP)),
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Location = new Point(10, 50),
                    Size = new Size(180, 200),
                };

                Label label2 = new Label
                {
                    Text = "Puntuación: " + Math.Round(((c.CantVotos * 100.0) / total), 2) + " %",
                    Size = new Size(180, 30),
                    Location = new Point(10, 260),
                    ForeColor = Color.White,
                    Font = new Font("Arial", 12, FontStyle.Regular),
                    TextAlign = ContentAlignment.MiddleCenter
                };

                panelImagen.Controls.Add(label1);
                panelImagen.Controls.Add(pictureBox);
                panelImagen.Controls.Add(label2);

                vista.tableLayoutPanel1.Controls.Add(panelImagen);
            }

            // Añadir el TableLayoutPanel al Panel con scroll
            panelScroll.Controls.Add(vista.tableLayoutPanel1);

            // Añadir el Panel con scroll al formulario principal o al contenedor adecuado
            vista.Controls.Add(panelScroll);
        }


    }
}
