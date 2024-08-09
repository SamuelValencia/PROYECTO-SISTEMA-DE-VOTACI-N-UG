using SistemaVotacion.conectar;
using SistemaVotacion.modelo;
using SistemaVotacion.Utilidad;
using SistemaVotacion.vista;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaVotacion.controlador
{
    public class FrmVisualizarLista_Controlador
    {
        private FrmVisualizarLista vista;
        private Lista lista;

        public FrmVisualizarLista_Controlador(FrmVisualizarLista vista, Lista lista)
        {
            this.vista = vista;
            this.lista = lista;
            ListarPorcentaje();
            ListarEstudiantes_votaron();
            EstiloTabla.EstilizarDataGridView(this.vista.dgvEstudiantes);
            EstiloTabla.EstilizarDataGridView(this.vista.dgvPorcentaje);
        }

        public void ListarPorcentaje()
        {
            List<Lista> listas = Lista_con.Listar();
            int totalVotos = 0;
            for(int i = 0; i < listas.Count; i++)
            {
                totalVotos += listas[i].CantVotos;
            }

            for (int i = 0; i < listas.Count; i++)
            {
                double porcentaje = 0;
                if (totalVotos!=0) porcentaje= (listas[i].CantVotos * 100.0) / totalVotos;
                this.vista.dgvPorcentaje.Rows.Add(new string[] { listas[i].NomLista, porcentaje+"%" });
            }
        }

        public void ListarEstudiantes_votaron()
        {
            List<Estudiante> estudiantes = Estudiante_con.Estudiantes_votaron();

            vista.dgvEstudiantes.Rows.Clear();
            for (int i = 0; i < estudiantes.Count; i++)
            {
                vista.dgvEstudiantes.Rows.Add(new object[] {estudiantes[i].IdEstudiante,estudiantes[i].Nombre, estudiantes[i].Apellidos,
                estudiantes[i].Cedula, estudiantes[i].Correo, estudiantes[i].Celular, estudiantes[i].NomSemestre});
            }

        }
    }
}
