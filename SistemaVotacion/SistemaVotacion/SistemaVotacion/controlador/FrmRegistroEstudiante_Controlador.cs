using SistemaVotacion.conectar;
using SistemaVotacion.modelo;
using SistemaVotacion.vista;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaVotacion.controlador
{
    public class FrmRegistroEstudiante_Controlador
    {
        private FrmRegistroEstudiante vista;
        private Estudiante estudiante;
        private int op;
        private int id;


        public FrmRegistroEstudiante_Controlador(FrmRegistroEstudiante vista, Estudiante estudiante, int op, int id)
        {
            this.vista = vista;
            this.estudiante = estudiante;
            this.vista.btnAgregar.Click += BtnAgregar_Click;
            this.vista.txtApellidos.KeyPress += new KeyPressEventHandler(txtLetras_KeyPress);
            this.vista.txtNombre.KeyPress += new KeyPressEventHandler(txtLetras_KeyPress);
            this.vista.txtCedula.KeyPress += new KeyPressEventHandler(txtNumeros_KeyPress);
            this.vista.txtCelular.KeyPress += new KeyPressEventHandler(txtNumeros_KeyPress);
            this.op = op;
            this.id = id;
            CargarSemestres();
            CargarDatos();
            this.vista.ShowDialog();
        }

        private void txtLetras_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        private void txtNumeros_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        private void CargarDatos()
        {
            if (op == 2)
            {
                Estudiante e = Estudiante_con.ObtenerEstudiantePorId(id);
                vista.txtApellidos.Text = e.Apellidos;
                vista.txtCedula.Text = e.Cedula;
                vista.txtCelular.Text = e.Celular;
                vista.txtContrasenia.Text = e.Contrasenia;
                vista.txtCorreo.Text = e.Correo;
                vista.txtNombre.Text = e.Nombre;


                for (int i = 0; i < vista.cbSemestre.Items.Count; i++)
                {
                    Semestre s = (Semestre)vista.cbSemestre.Items[i];
                    if (s.IdSemestre == e.IdSemestre)
                    {
                        vista.cbSemestre.SelectedIndex = i;
                        break;
                    }
                }
            }
        }

        private void CargarSemestres()
        {
            vista.cbSemestre.Items.Clear();
            List<Semestre> semestres = Semestre_con.Listar();
            for (int i = 0; i < semestres.Count; i++)
            {
                vista.cbSemestre.Items.Add(semestres[i]);
            }
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            string msj = validarCamposVacios();
            if (op == 1)
            {
                if (msj.Equals(""))
                {
                    estudiante = new Estudiante();
                    Semestre s = null;

                    estudiante.Apellidos = vista.txtApellidos.Text;
                    estudiante.Cedula = vista.txtCedula.Text;
                    estudiante.Celular = vista.txtCelular.Text;
                    estudiante.Contrasenia = vista.txtContrasenia.Text;
                    estudiante.Correo = vista.txtCorreo.Text;
                    estudiante.Nombre = vista.txtNombre.Text;
                    if (vista.cbSemestre.SelectedIndex >= 0)
                    {
                        s = (Semestre)vista.cbSemestre.SelectedItem;
                        estudiante.IdSemestre = s.IdSemestre;
                    }


                    int idEstudiante = Estudiante_con.Insertar(estudiante);
                    if (idEstudiante != -1)
                    {

                        MessageBox.Show("Se registró exitosamente", "Registrar Estudiante");
                        vista.Dispose();
                    }
                    else
                    {
                        MessageBox.Show("Error al intentar registrarse", "Registrar Estudiante");
                    }

                }
                else
                {
                    MessageBox.Show(msj, "Registrar Estudiante");
                }
            }
            else//editar
            {
                if (msj.Equals(""))
                {
                    estudiante = new Estudiante();
                    Semestre s = null;
                    estudiante.IdEstudiante = id;
                    estudiante.Apellidos = vista.txtApellidos.Text;
                    estudiante.Cedula = vista.txtCedula.Text;
                    estudiante.Celular = vista.txtCelular.Text;
                    estudiante.Contrasenia = vista.txtContrasenia.Text;
                    estudiante.Correo = vista.txtCorreo.Text;
                    estudiante.Nombre = vista.txtNombre.Text;
                    if (vista.cbSemestre.SelectedIndex >= 0)
                    {
                        s = (Semestre)vista.cbSemestre.SelectedItem;
                        estudiante.IdSemestre = s.IdSemestre;
                    }


                    bool estado = Estudiante_con.Actualizar(estudiante);
                    if (estado)
                    {

                        MessageBox.Show("Se actualizó el estudiante", "Actualizar Estudiante");
                        vista.Dispose();
                        


                    }
                    else
                    {
                        MessageBox.Show("Error al intentar actualizar", "Actualizar Estudiante");
                    }

                }
                else
                {
                    MessageBox.Show(msj, "Actualizar Estudiante");
                }

            } 

        }



        private string validarCamposVacios()
        {
            string msj = "";
            if (vista.txtApellidos.Text.Equals("")) msj += "Falta ingresar apellidos\n";
            if (vista.txtCedula.Text.Equals("")) msj += "Falta ingresar cédula\n";
            if (vista.txtContrasenia.Text.Equals("")) msj += "Falta ingresar Contraseña\n";
            if (vista.txtCedula.Text.Length != 10) msj += "La cédula debe tener 10 dígitos\n";
            if (vista.txtCelular.Text.Length != 10) msj += "El teléfono debe tener 10 dígitos\n";
            if (! new Regex(@"^(09|120)\d*$").IsMatch(vista.txtCedula.Text)) msj += "La cédula debe empezar con 09 o 120\n";
            if (!new Regex(@"^(096|097|098|099)\d*$").IsMatch(vista.txtCelular.Text)) msj += "El teléfono debe empezar con 096, 097, 098 o 099\n";
            if (!new Regex(@"^[a-zA-Z0-9._%+-]+@ug\.edu\.ec$").IsMatch(vista.txtCorreo.Text)) msj += "El correo es inválido\n";
            if (vista.txtCorreo.Text.Equals("")) msj += "Falta ingresar correo\n";
            if (vista.txtNombre.Text.Equals("")) msj += "Falta ingresar nombre\n";
            if (vista.cbSemestre.SelectedIndex < 0) msj += "Falta seleccionar semestre\n";
            return msj;
        }
    }
}
