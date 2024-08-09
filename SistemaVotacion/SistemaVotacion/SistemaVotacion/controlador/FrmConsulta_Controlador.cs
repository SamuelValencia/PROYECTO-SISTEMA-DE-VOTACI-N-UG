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
    public class FrmConsulta_Controlador
    {
        private FrmConsulta vista;
        private FrmPrincipal principal;
        private Lista lista;
        private Estudiante estudiante;

        public FrmConsulta_Controlador(FrmConsulta vista, Lista lista, Estudiante estudiante,FrmPrincipal principal)
        {
            this.vista = vista;
            this.lista = lista;
            this.estudiante = estudiante;
            this.principal = principal;
            CargarEstudiantes();
            CargarLista();
            EstiloTabla.EstilizarDataGridView(vista.dgvCandidatos);
            EstiloTabla.EstilizarDataGridView(vista.dgvEstudiantes);

            this.vista.btnEditCandidato.Click += BtnEditarCandidato_Click;
            this.vista.btnEditEstudiante.Click += BtnEditarEstudiante_Click;
            this.vista.btnEliminarCandidato.Click += BtnEliminarCandidato_Click;
            this.vista.btnEliminarEstudiante.Click += BtnEliminarEstudiante_Click;
        }

        private void CargarEstudiantes()
        {    
            vista.dgvEstudiantes.Rows.Clear();
            List<Estudiante> estudiantes = Estudiante_con.Listar();
            for (int i = 0; i < estudiantes.Count; i++)
            {
                vista.dgvEstudiantes.Rows.Add(new object[] {estudiantes[i].IdEstudiante,estudiantes[i].Nombre, estudiantes[i].Apellidos,
                estudiantes[i].Cedula, estudiantes[i].Correo, estudiantes[i].Celular, estudiantes[i].NomSemestre});
            }
        }

        private void CargarLista()
        {
            vista.dgvCandidatos.Rows.Clear();
            List<Lista> listas = Lista_con.Listar();
            for (int i = 0; i < listas.Count; i++)
            {
                vista.dgvCandidatos.Rows.Add(new object[] {listas[i].IdLista,
                listas[i].NomLista,listas[i].NomPresidente, listas[i].NomSecretario,
                listas[i].NomPrimerVocal, listas[i].NomCarrera});
            }
        }

        private void BtnEditarCandidato_Click(object sender, EventArgs e)
        {
            if (this.vista.dgvCandidatos.SelectedRows.Count > 0)
            {
                DataGridViewRow filaSeleccionada = this.vista.dgvCandidatos.SelectedRows[0];
                int id = int.Parse(filaSeleccionada.Cells[0].Value.ToString());
                FrmRegistroLista frm = new FrmRegistroLista();
                FrmRegistroLista_Controlador controlador = new FrmRegistroLista_Controlador(frm, new Lista(), 2,id);
                AbrirHijo(frm);
            }
            else
            {
                MessageBox.Show("Seleccione una fila de la tabla candidatos");
            }
        }

        private void BtnEditarEstudiante_Click(object sender, EventArgs e)
        {
            if (this.vista.dgvEstudiantes.SelectedRows.Count > 0)
            {
                DataGridViewRow filaSeleccionada = this.vista.dgvEstudiantes.SelectedRows[0];
                int id = int.Parse(filaSeleccionada.Cells[0].Value.ToString());
                FrmRegistroEstudiante frm = new FrmRegistroEstudiante();
                FrmRegistroEstudiante_Controlador controlador = new FrmRegistroEstudiante_Controlador(frm, new Estudiante(), 2, id);
                CargarEstudiantes();
            }
            else
            {
                MessageBox.Show("Seleccione una fila de la tabla estudiantes");
            }

        }

        private void BtnEliminarCandidato_Click(object sender, EventArgs e)
        {
            if (this.vista.dgvCandidatos.SelectedRows.Count > 0)
            {
                DataGridViewRow filaSeleccionada = this.vista.dgvCandidatos.SelectedRows[0];
                int id = int.Parse(filaSeleccionada.Cells[0].Value.ToString());
                if (Lista_con.Eliminar(id))
                {
                    MessageBox.Show("Lista eliminado", "Elimnar Lista");
                    CargarLista();
                }
                else
                {
                    MessageBox.Show("Error al eliminar lista", "Elimnar Lista");
                }
            }
            else
            {
                MessageBox.Show("Seleccione una fila de la tabla candidatos");
            }
        }

        private void BtnEliminarEstudiante_Click(object sender, EventArgs e)
        {
            if (this.vista.dgvEstudiantes.SelectedRows.Count > 0)
            {
                DataGridViewRow filaSeleccionada = this.vista.dgvEstudiantes.SelectedRows[0];
                int id = int.Parse(filaSeleccionada.Cells[0].Value.ToString());
                if (Estudiante_con.Eliminar(id))
                {
                    MessageBox.Show("Estudiante eliminado", "Elimnar Estudiante");
                    CargarEstudiantes();
                }
                else
                {
                    MessageBox.Show("Error al eliminar estudiante", "Elimnar Estudiante");
                }
            }
            else
            {
                MessageBox.Show("Seleccione una fila de la tabla estudiantes");
            }
        }


        

        private void AbrirHijo(object fornHijo)
        {
            if (this.principal.panel3.Controls.Count > 0)
            {
                this.principal.panel3.Controls.RemoveAt(0);
            }
            Form fh = fornHijo as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            this.principal.panel3.Controls.Add(fh);
            this.principal.panel3.Tag = fh;

            fh.Show();
        }

    }
}
