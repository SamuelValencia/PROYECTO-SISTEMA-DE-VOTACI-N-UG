using MySql.Data.MySqlClient;
using SistemaVotacion.modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaVotacion.conectar
{
    public class Usuario_con
    {

        public static Administrador ValidarIngresoAdministrador(Administrador u)
        {
            MySqlConnection conn = Conexion.GetConexion();

            try
            {
                conn.Open();
                string consulta = "SELECT * FROM usuario WHERE correo=@correo AND contrasenia=@pass";
                MySqlCommand SQLComando = new MySqlCommand(consulta, conn);
                SQLComando.Parameters.AddWithValue("@correo", u.Correo);
                SQLComando.Parameters.AddWithValue("@pass", u.Contrasenia);
                using (MySqlDataReader reader = SQLComando.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return u;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }

            return null;
        }

        public static Estudiante ValidarIngresoEstudiante(Estudiante e)
        {
            MySqlConnection conn = Conexion.GetConexion();

            try
            {
                conn.Open();
                string consulta = "SELECT * FROM estudiante WHERE correo=@correo AND contrasenia=@pass";
                MySqlCommand SQLComando = new MySqlCommand(consulta, conn);
                SQLComando.Parameters.AddWithValue("@correo", e.Correo);
                SQLComando.Parameters.AddWithValue("@pass", e.Contrasenia);
                using (MySqlDataReader reader = SQLComando.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        e.IdEstudiante = reader.GetInt32("idEstudiante");
                        e.Cedula = Convert.ToString(reader["cedula"]);
                        return e;

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }

            return null;
        }
    }
}
