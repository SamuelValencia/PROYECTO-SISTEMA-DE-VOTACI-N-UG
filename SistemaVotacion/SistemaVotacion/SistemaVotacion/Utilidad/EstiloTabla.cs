using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaVotacion.Utilidad
{
    public class EstiloTabla
    {
        public static void EstilizarDataGridView(DataGridView dgv)
        {
            // Estilo de la cabecera de columna
            DataGridViewCellStyle columnHeaderStyle = new DataGridViewCellStyle();
            columnHeaderStyle.BackColor = Color.Black; // Color de fondo negro
            columnHeaderStyle.ForeColor = Color.White; // Color del texto blanco
            columnHeaderStyle.Font = new Font("Verdana", 10, FontStyle.Bold);
            columnHeaderStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.ColumnHeadersDefaultCellStyle = columnHeaderStyle;

            // Estilo de la cabecera de fila
            DataGridViewCellStyle rowHeaderStyle = new DataGridViewCellStyle();
            rowHeaderStyle.BackColor = Color.Navy;
            rowHeaderStyle.ForeColor = Color.White;
            rowHeaderStyle.Font = new Font("Verdana", 10, FontStyle.Bold);
            rowHeaderStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.RowHeadersDefaultCellStyle = rowHeaderStyle;

            // Estilo de las celdas
            DataGridViewCellStyle cellStyle = new DataGridViewCellStyle();
            cellStyle.BackColor = Color.LightGray;
            cellStyle.ForeColor = Color.Black;
            cellStyle.Font = new Font("Verdana", 9, FontStyle.Regular);
            cellStyle.SelectionBackColor = Color.DarkSlateBlue;
            cellStyle.SelectionForeColor = Color.White;
            dgv.DefaultCellStyle = cellStyle;

            // Alternar color de fila
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.White;

            // Color de fondo del área vacía
            dgv.BackgroundColor = Color.LightBlue;

            // Otras configuraciones del DataGridView
            dgv.EnableHeadersVisualStyles = false; // Deshabilitar estilos visuales predeterminados
            dgv.BorderStyle = BorderStyle.Fixed3D;
            dgv.GridColor = Color.Black;
            dgv.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; // Ajustar columnas para llenar el control
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect; // Selección de fila completa
            dgv.AllowUserToResizeColumns = false; // Deshabilitar redimensionamiento de columnas
            dgv.AllowUserToResizeRows = false; // Deshabilitar redimensionamiento de filas

            // Permitir scroll en el DataGridView
            dgv.ScrollBars = ScrollBars.Both; // Habilitar barras de scroll vertical y horizontal

            // Configurar el ajuste de las columnas y filas
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells; // Ajustar columnas a las celdas mostradas
            dgv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells; // Ajustar filas a las celdas mostradas

            // Otras configuraciones
            dgv.AllowUserToResizeColumns = true; // Permitir redimensionamiento de columnas
            dgv.AllowUserToResizeRows = true; // Permitir redimensionamiento de filas
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect; // Selección de fila completa
        }
    }
}
