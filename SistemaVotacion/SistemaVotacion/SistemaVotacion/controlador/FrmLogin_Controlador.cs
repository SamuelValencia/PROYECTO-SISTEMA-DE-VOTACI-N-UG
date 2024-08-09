using SistemaVotacion.conectar;
using SistemaVotacion.modelo;
using SistemaVotacion.vista;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaVotacion.controlador
{
    public class FrmLogin_Controlador
    {
        private FrmLogin vista;

        public FrmLogin_Controlador(FrmLogin vista)
        {
            this.vista = vista;
            this.vista.btnIngresar.Click += BtnIngresar_Click;
            this.vista.cbTipo.SelectedIndex = 0;

            this.vista.linkContrasenia.Click += BtnOlvidaContrasenia_Click;
            this.vista.linkRegistro.Click += BtnRegistro_Click;

        }

        public void Iniciar()
        {
            this.vista.ShowDialog();
        }

        private void BtnIngresar_Click(object sender, EventArgs e)
        {
            object objeto=null;
            if (vista.cbTipo.SelectedIndex == 0 || vista.cbTipo.SelectedIndex == 1)
            {
                if(vista.cbTipo.SelectedIndex == 0)  objeto = Usuario_con.ValidarIngresoAdministrador(new Administrador(vista.txtCorreo.Text, vista.txtPass.Text)); 
                else objeto = Usuario_con.ValidarIngresoEstudiante(new Estudiante(vista.txtCorreo.Text, vista.txtPass.Text));

                if (objeto != null)
                {
                    vista.txtCorreo.Text = "";
                    vista.txtPass.Text = "";
                    vista.cbTipo.SelectedIndex = 0;
                    FrmPrincipal frm = new FrmPrincipal();
                    FrmPrincipal_Controlador controlador = new FrmPrincipal_Controlador(frm, vista, objeto);
                    this.vista.Hide();
                    controlador.iniciar();

                }
                else
                {
                    MessageBox.Show("Correo y/o Contraseña incorrecto");
                }
            }
            else
            {
                vista.txtCorreo.Text = "";
                vista.txtPass.Text = "";
                vista.cbTipo.SelectedIndex = 0;
                FrmPrincipal frm = new FrmPrincipal();
                FrmPrincipal_Controlador controlador = new FrmPrincipal_Controlador(frm, vista, objeto);
                this.vista.Hide();
                controlador.iniciar();
            }
            
        }

        private void BtnOlvidaContrasenia_Click(object sender, EventArgs e)
        {
            FrmCambiarContrasenia frm = new FrmCambiarContrasenia();
            FrmCambiarContrasenia_Controlador controlador = new FrmCambiarContrasenia_Controlador(frm, new Estudiante());
        }

        private void BtnRegistro_Click(object sender, EventArgs e)
        {
            FrmRegistroEstudiante frm = new FrmRegistroEstudiante();
            FrmRegistroEstudiante_Controlador controlador = new FrmRegistroEstudiante_Controlador(frm,new Estudiante(),1,0);
        }
    }
}
