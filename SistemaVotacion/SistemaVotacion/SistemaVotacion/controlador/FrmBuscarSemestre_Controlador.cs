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
    public class FrmBuscarSemestre_Controlador
    {
        private FrmBuscarSemestre vista;
        private Estudiante estudiante;

        public FrmBuscarSemestre_Controlador(FrmBuscarSemestre vista, Estudiante estudiante)
        {
            this.vista = vista;
            this.estudiante = estudiante;
            this.vista.txtBuscar.KeyPress += new KeyPressEventHandler(txtBuscar_KeyPress);
            CargarEstudiantes(Estudiante_con.Listar());
            EstiloTabla.EstilizarDataGridView(this.vista.dgvEstudiantes);
            this.vista.Show();
        }

        private void txtBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            string buscar = this.vista.txtBuscar.Text;
            CargarEstudiantes(Estudiante_con.ConsultarSemesntre(buscar));

        }

        private void CargarEstudiantes(List<Estudiante> estudiantes)
        {
            vista.dgvEstudiantes.Rows.Clear();
            for (int i = 0; i < estudiantes.Count; i++)
            {
                vista.dgvEstudiantes.Rows.Add(new object[] {estudiantes[i].IdEstudiante,estudiantes[i].Nombre, estudiantes[i].Apellidos,
                estudiantes[i].Cedula, estudiantes[i].Correo, estudiantes[i].Celular, estudiantes[i].NomSemestre});
            }
        }
    }
}
