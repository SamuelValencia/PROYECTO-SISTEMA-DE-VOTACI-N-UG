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
    public class FrmCambiarContrasenia_Controlador
    {
        private FrmCambiarContrasenia vista;
        private Estudiante estudiante;


        public FrmCambiarContrasenia_Controlador(FrmCambiarContrasenia vista, Estudiante estudiante)
        {
            this.vista = vista;
            this.estudiante = estudiante;
            this.vista.btnCambiarPass.Click += BtnCambiar_Click;
            this.vista.ShowDialog();
        }


        private void BtnCambiar_Click(object sender, EventArgs e)
        {
            string msj = validarCamposVacios();
            if (msj.Equals(""))
            {
                string matricula = vista.txtCedula.Text;
                string pass1 = vista.txtPass.Text;
                string pass2 = vista.txtPass2.Text;
                if (!pass1.Equals(pass2)) {
                    MessageBox.Show("Las contraseñas no coinciden");
                }
                else
                {
                    bool estado = Estudiante_con.ActualizarContrasenia(matricula, pass1);
                    if (estado)
                    {
                        MessageBox.Show("Actualizó su contraseña correctamente", "Actualizar Contraseña");
                        vista.Dispose();
                    }
                    else
                    {
                        MessageBox.Show("Error al intentar actualizar contraseña", "Actualizar Contraseña");
                    }
                }
            }
            else
            {
                MessageBox.Show(msj, "Actualizar Contraseña");
            }

        }



        private string validarCamposVacios()
        {
            string msj = "";
            if (vista.txtCedula.Text.Equals("")) msj+= "Falta ingresar la matrícula\n";
            if (vista.txtPass.Text.Equals("")) msj += "Falta ingresar contraseña\n";
            if (vista.txtPass2.Text.Equals("")) msj += "Falta ingresar reptir nueva contraseña\n";
            
            return msj;
        }
    }
}
