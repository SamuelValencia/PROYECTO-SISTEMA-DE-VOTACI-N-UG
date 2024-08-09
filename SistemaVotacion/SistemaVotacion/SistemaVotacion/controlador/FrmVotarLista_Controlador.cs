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
    public class FrmVotarLista_Controlador
    {
        private FrmVotarLista vista;
        private Lista lista;
        private int idEstudiante;

        public FrmVotarLista_Controlador(FrmVotarLista vista, Lista lista, int idEstudiante)
        {
            this.vista = vista;
            this.lista = lista;
            this.idEstudiante = idEstudiante;
            CargarLista();

        }

        private void CargarLista()
        {
            List<Lista> listas = Lista_con.Listar();

            // Limpiar el TableLayoutPanel antes de agregar nuevos paneles
            vista.tableLayoutPanel1.Controls.Clear();
            vista.tableLayoutPanel1.RowStyles.Clear();

            // Configura el TableLayoutPanel para que tenga una columna y un número inicial de filas.
            vista.tableLayoutPanel1.ColumnCount = 1;
            vista.tableLayoutPanel1.RowCount = listas.Count; // Inicialmente, tantas filas como listas
            vista.tableLayoutPanel1.AutoSize = true;
            vista.tableLayoutPanel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;

            // Configura el contenedor del TableLayoutPanel para que tenga scroll
            Panel contenedor = new Panel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true, // Activar el scroll automático cuando sea necesario
            };

            // Agrega el TableLayoutPanel al contenedor con scroll
            contenedor.Controls.Add(vista.tableLayoutPanel1);

            // Asegúrate de que el contenedor sea el que está en el formulario (no el TableLayoutPanel directamente)
            vista.Controls.Clear();
            vista.Controls.Add(contenedor);

            foreach (Lista c in listas)
            {
                List<Propuesta> propuestas = Propuesta_con.ObtenerPropuestasPorIdLista(c.IdLista);

                // Crear un nuevo panel para cada fila
                Panel panelFila = new Panel
                {
                    BorderStyle = BorderStyle.Fixed3D,
                    Margin = new Padding(15),
                    Size = new Size(800, 230), // Ajusta el tamaño según sea necesario
                    BackColor = Color.FromArgb(25, 61, 111)
                };

                // Crear TableLayoutPanel para organizar columnas
                TableLayoutPanel tableLayout = new TableLayoutPanel
                {
                    ColumnCount = 3,
                    RowCount = 1,
                    Dock = DockStyle.Fill
                };
                tableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 200F));
                tableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
                tableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));

                // Crear PictureBox para la foto
                PictureBox pictureBox = new PictureBox
                {
                    Image = Image.FromFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "foto_lista", c.FotoP)),
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Dock = DockStyle.Fill
                };

                // Crear un FlowLayoutPanel para los datos
                FlowLayoutPanel panelDatos = new FlowLayoutPanel
                {
                    FlowDirection = FlowDirection.TopDown,
                    WrapContents = false,
                    Dock = DockStyle.Fill
                };

                // Crear etiquetas para los datos
                Label labelNombreLista = new Label
                {
                    Text = "Nombre de la Lista: " + c.NomLista,
                    AutoSize = true,
                    ForeColor = Color.White,
                    Font = new Font("Arial", 12, FontStyle.Regular)
                };

                Label labelPresidente = new Label
                {
                    Text = "Presidente: " + c.NomPresidente,
                    AutoSize = true,
                    ForeColor = Color.White,
                    Font = new Font("Arial", 12, FontStyle.Regular)
                };

                Label labelSecretario = new Label
                {
                    Text = "Secretario: " + c.NomSecretario,
                    AutoSize = true,
                    ForeColor = Color.White,
                    Font = new Font("Arial", 12, FontStyle.Regular)
                };

                Label labelVocal = new Label
                {
                    Text = "Vocal: " + c.NomPrimerVocal,
                    AutoSize = true,
                    ForeColor = Color.White,
                    Font = new Font("Arial", 12, FontStyle.Regular)
                };

                // Crear el botón de votación
                Button button = new Button
                {
                    Text = "Votar",
                    Size = new Size(180, 30),
                    ForeColor = Color.White,
                    Font = new Font("Arial", 12, FontStyle.Regular),
                    TextAlign = ContentAlignment.MiddleCenter,
                    BackColor = Color.FromArgb(34, 81, 143),
                    Tag = c.IdLista
                };

                button.Click += BtnVotar_Click;

                // Crear un panel para el título y el ListBox
                Panel panelPropuestas = new Panel
                {
                    Dock = DockStyle.Fill,
                    Padding = new Padding(5),
                    BackColor = Color.FromArgb(34, 81, 143),
                    BorderStyle = BorderStyle.FixedSingle
                };

                // Crear el título del ListBox
                Label labelPropuestas = new Label
                {
                    Text = "Propuestas",
                    AutoSize = true,
                    ForeColor = Color.White,
                    Font = new Font("Arial", 12, FontStyle.Bold),
                    Dock = DockStyle.Top,
                    TextAlign = ContentAlignment.MiddleCenter
                };

                // Crear el ListBox para las propuestas
                ListBox listBoxPropuestas = new ListBox
                {
                    Dock = DockStyle.Fill,
                    BackColor = Color.FromArgb(255, 255, 255) // Fondo del ListBox
                };

                // Añadir las propuestas al ListBox
                foreach (Propuesta p in propuestas)
                {
                    listBoxPropuestas.Items.Add(p.Descripcion);
                }

                // Agregar el título y el ListBox al panel de propuestas
                panelPropuestas.Controls.Add(listBoxPropuestas);
                panelPropuestas.Controls.Add(labelPropuestas);

                // Agregar las etiquetas y el botón al FlowLayoutPanel
                panelDatos.Controls.Add(labelNombreLista);
                panelDatos.Controls.Add(labelPresidente);
                panelDatos.Controls.Add(labelSecretario);
                panelDatos.Controls.Add(labelVocal);
                panelDatos.Controls.Add(button);

                // Añadir el PictureBox, panel de datos y panel de propuestas al TableLayoutPanel
                tableLayout.Controls.Add(pictureBox, 0, 0);
                tableLayout.Controls.Add(panelDatos, 1, 0);
                tableLayout.Controls.Add(panelPropuestas, 2, 0);

                // Agregar el TableLayoutPanel al panel de fila
                panelFila.Controls.Add(tableLayout);

                // Agregar el panel de fila al TableLayoutPanel principal
                vista.tableLayoutPanel1.Controls.Add(panelFila);

                // Agregar una nueva fila para cada panelFila
                vista.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            }
        }


        private void BtnVotar_Click(object sender, EventArgs e)
        {
            if (sender is Button clickedButton)
            {
                int idLista = Convert.ToInt32(clickedButton.Tag);
                if(Lista_con.AumentarPuntuacion(idLista, idEstudiante))
                {
                    MessageBox.Show("Realizó su votación exitosamente");
                    vista.tableLayoutPanel1.Controls.Clear();
                }
                else
                {
                    MessageBox.Show("Error al intentar votar, intente mas tarde");
                }
            }
        }
    }
}
