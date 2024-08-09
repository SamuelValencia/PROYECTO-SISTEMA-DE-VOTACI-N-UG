using SistemaVotacion.conectar;
using SistemaVotacion.modelo;
using SistemaVotacion.Utilidad;
using SistemaVotacion.vista;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaVotacion.controlador
{
    public class FrmBuscar_Controlador
    {
        private FrmBuscar vista;
        private FrmPrincipal principal;
        private Estudiante estudiante;

        public FrmBuscar_Controlador(FrmBuscar vista, Estudiante estudiante, FrmPrincipal principal)
        {
            this.vista = vista;
            this.estudiante = estudiante;
            this.principal = principal;

            this.vista.btnBuscarApellido.Click += BtnBuscarApellido_Click;
            this.vista.btnBuscarCedula.Click += BtnBuscarCedula_Click;
            this.vista.btnBuscarSemestre.Click += BtnBuscarSemestre_Click;


        }

        private void BtnBuscarApellido_Click(object sender, EventArgs e)
        {
            FrmBuscarApellido frm = new FrmBuscarApellido();
            FrmBuscarApellido_Controlador controlador = new FrmBuscarApellido_Controlador(frm, new Estudiante());
            AbrirHijo(frm);
        }

        private void BtnBuscarCedula_Click(object sender, EventArgs e)
        {
            FrmBuscarCedula frm = new FrmBuscarCedula();
            FrmBuscarCedula_Controlador controlador = new FrmBuscarCedula_Controlador(frm, new Estudiante());
            AbrirHijo(frm);
        }

        private void BtnBuscarSemestre_Click(object sender, EventArgs e)
        {
            FrmBuscarSemestre frm = new FrmBuscarSemestre();
            FrmBuscarSemestre_Controlador controlador = new FrmBuscarSemestre_Controlador(frm, new Estudiante());
            AbrirHijo(frm);
        }


      

        private void AbrirHijo(object fornHijo)
        {
            if (this.vista.panel_datos.Controls.Count > 0)
            {
                this.vista.panel_datos.Controls.RemoveAt(0);
            }
            Form fh = fornHijo as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            this.vista.panel_datos.Controls.Add(fh);
            this.vista.panel_datos.Tag = fh;

            fh.Show();
        }



    }
}
