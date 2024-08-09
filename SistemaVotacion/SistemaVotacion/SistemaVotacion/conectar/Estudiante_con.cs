using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using SistemaVotacion.modelo;

namespace SistemaVotacion.conectar
{
    public class Estudiante_con
    {
        public static int Insertar(Estudiante e)
        {
            MySqlConnection conn = Conexion.GetConexion();

            try
            {
                conn.Open();
                string consulta = "INSERT INTO estudiante(cedula,nombre, apellidos, correo, celular, idSemestre, contrasenia)" +
                                  " VALUES (@cedula, @nombre, @apellidos, @correo, @celular, @idSemestre, @contrasenia)";
                MySqlCommand SQLComando = new MySqlCommand(consulta, conn);
                SQLComando.Parameters.AddWithValue("@nombre", e.Nombre);
                SQLComando.Parameters.AddWithValue("@apellidos", e.Apellidos);
                SQLComando.Parameters.AddWithValue("@correo", e.Correo);
                SQLComando.Parameters.AddWithValue("@celular", e.Celular);
                SQLComando.Parameters.AddWithValue("@idSemestre", e.IdSemestre);
                SQLComando.Parameters.AddWithValue("@contrasenia", e.Contrasenia);
                SQLComando.Parameters.AddWithValue("@cedula", e.Cedula);

                SQLComando.ExecuteNonQuery();

                int ultimoIdInsertado = (int)SQLComando.LastInsertedId;
                return ultimoIdInsertado;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return -1;
            }
            finally
            {
                conn.Close();
            }
        }

        public static bool Actualizar(Estudiante e)
        {
            MySqlConnection conn = Conexion.GetConexion();

            try
            {
                conn.Open();
                string consulta = "UPDATE estudiante SET nombre = @nombre, apellidos = @apellidos, correo = @correo, celular = @celular, " +
                                  "idSemestre = @idSemestre, contrasenia = @contrasenia WHERE idEstudiante = @idEstudiante";
                MySqlCommand SQLComando = new MySqlCommand(consulta, conn);
                SQLComando.Parameters.AddWithValue("@nombre", e.Nombre);
                SQLComando.Parameters.AddWithValue("@apellidos", e.Apellidos);
                SQLComando.Parameters.AddWithValue("@correo", e.Correo);
                SQLComando.Parameters.AddWithValue("@celular", e.Celular);
                SQLComando.Parameters.AddWithValue("@idSemestre", e.IdSemestre);
                SQLComando.Parameters.AddWithValue("@contrasenia", e.Contrasenia);
                SQLComando.Parameters.AddWithValue("@idEstudiante", e.IdEstudiante);

                int filasAfectadas = SQLComando.ExecuteNonQuery();
                return filasAfectadas > 0; 
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                conn.Close();
            }
        }


        public static List<Estudiante> Estudiantes_votaron()
        {
            MySqlConnection conn = Conexion.GetConexion();
            List<Estudiante> estudiantes = new List<Estudiante>();
            
            try
            {
                conn.Open();
                string consulta = "SELECT e.*,s.nomSemestre FROM estudiante e INNER JOIN votacion_estudiante ve ON ve.idEstudiante=e.idEstudiante INNER JOIN semestre s ON s.idSemestre= e.idSemestre";
                MySqlCommand SQLComando = new MySqlCommand(consulta, conn);

                using (MySqlDataReader reader = SQLComando.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Estudiante estudiante = new Estudiante
                        {
                            Cedula = reader["cedula"].ToString(),
                            IdEstudiante = int.Parse(reader["idEstudiante"].ToString()),
                            Nombre = reader["nombre"].ToString(),
                            Apellidos = reader["apellidos"].ToString(),
                            Correo = reader["correo"].ToString(),
                            Celular = reader["celular"].ToString(),
                            NomSemestre = reader["nomSemestre"].ToString(),
                            Contrasenia = reader["contrasenia"].ToString()
                            
                        };

                        estudiantes.Add(estudiante);
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

            return estudiantes;
        }

        public static List<Estudiante> ConsultaCedula(string cedula)
        {
            MySqlConnection conn = Conexion.GetConexion();
            List<Estudiante> estudiantes = new List<Estudiante>();
            try
            {
                conn.Open();
                string consulta = "SELECT e.*, s.nomSemestre FROM estudiante e INNER JOIN semestre s ON e.idSemestre=s.idSemestre WHERE e.cedula = @buscar";
                MySqlCommand SQLComando = new MySqlCommand(consulta, conn);
                SQLComando.Parameters.AddWithValue("@buscar", "%" + cedula + "%");

                MySqlDataReader reader = SQLComando.ExecuteReader();

                while (reader.Read())
                {
                    Estudiante estudiante = new Estudiante
                    {
                        IdEstudiante = reader.GetInt32("idEstudiante"),
                        Nombre = reader.GetString("nombre"),
                        Apellidos = reader.GetString("apellidos"),
                        Cedula = reader.GetString("cedula"),
                        Correo = reader.GetString("correo"),
                        Celular = reader.GetString("celular"),
                        IdSemestre = reader.GetInt32("idSemestre"),
                        Contrasenia = reader.GetString("contrasenia"),
                        NomSemestre = reader.GetString("nomSemestre")
                    };
                    estudiantes.Add(estudiante);

                }
                return estudiantes;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
            finally
            {
                conn.Close();
            }
        }

        public static List<Estudiante> ConsultarApellido(string apellido)
        {
            MySqlConnection conn = Conexion.GetConexion();
            List<Estudiante> estudiantes = new List<Estudiante>();
            try
            {
                conn.Open();
                string consulta = "SELECT e.*, s.nomSemestre FROM estudiante e INNER JOIN semestre s ON e.idSemestre=s.idSemestre WHERE e.apellidos = @buscar";
                MySqlCommand SQLComando = new MySqlCommand(consulta, conn);
                SQLComando.Parameters.AddWithValue("@buscar", "%" + apellido + "%");

                MySqlDataReader reader = SQLComando.ExecuteReader();

                while (reader.Read())
                {
                    Estudiante estudiante = new Estudiante
                    {
                        IdEstudiante = reader.GetInt32("idEstudiante"),
                        Nombre = reader.GetString("nombre"),
                        Apellidos = reader.GetString("apellidos"),
                        Cedula = reader.GetString("cedula"),
                        Correo = reader.GetString("correo"),
                        Celular = reader.GetString("celular"),
                        IdSemestre = reader.GetInt32("idSemestre"),
                        Contrasenia = reader.GetString("contrasenia"),
                        NomSemestre = reader.GetString("nomSemestre")
                    };
                    estudiantes.Add(estudiante);

                }
                return estudiantes;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
            finally
            {
                conn.Close();
            }
        }

        public static List<Estudiante> ConsultarSemesntre(string semestre)
        {
            MySqlConnection conn = Conexion.GetConexion();
            List<Estudiante> estudiantes = new List<Estudiante>();
            try
            {
                conn.Open();
                string consulta = "SELECT e.*, s.nomSemestre FROM estudiante e INNER JOIN semestre s ON e.idSemestre=s.idSemestre WHERE s.nomSemestre = @buscar";
                MySqlCommand SQLComando = new MySqlCommand(consulta, conn);
                SQLComando.Parameters.AddWithValue("@buscar", "%" + semestre + "%");

                MySqlDataReader reader = SQLComando.ExecuteReader();

                while (reader.Read())
                {
                    Estudiante estudiante = new Estudiante
                    {
                        IdEstudiante = reader.GetInt32("idEstudiante"),
                        Nombre = reader.GetString("nombre"),
                        Apellidos = reader.GetString("apellidos"),
                        Cedula = reader.GetString("cedula"),
                        Correo = reader.GetString("correo"),
                        Celular = reader.GetString("celular"),
                        IdSemestre = reader.GetInt32("idSemestre"),
                        Contrasenia = reader.GetString("contrasenia"),
                        NomSemestre = reader.GetString("nomSemestre")
                    };
                    estudiantes.Add(estudiante);

                }
                return estudiantes;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
            finally
            {
                conn.Close();
            }
        }

        public static Estudiante ObtenerEstudiantePorId(int idEstudiante)
        {
            MySqlConnection conn = Conexion.GetConexion();

            try
            {
                conn.Open();
                string consulta = "SELECT * FROM estudiante WHERE idEstudiante = @idEstudiante";
                MySqlCommand SQLComando = new MySqlCommand(consulta, conn);
                SQLComando.Parameters.AddWithValue("@idEstudiante", idEstudiante);

                MySqlDataReader reader = SQLComando.ExecuteReader();

                if (reader.Read())
                {
                    Estudiante estudiante = new Estudiante
                    {
                        IdEstudiante = reader.GetInt32("idEstudiante"),
                        Nombre = reader.GetString("nombre"),
                        Apellidos = reader.GetString("apellidos"),
                        Cedula = reader.GetString("cedula"),
                        Correo = reader.GetString("correo"),
                        Celular = reader.GetString("celular"),
                        IdSemestre = reader.GetInt32("idSemestre"),
                        Contrasenia = reader.GetString("contrasenia")
                    };
                    return estudiante;
                }
                else
                {
                    return null; 
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
            finally
            {
                conn.Close();
            }
        }

        public static List<Estudiante> Listar()
        {
            List<Estudiante> estudiantes = new List<Estudiante>();

            MySqlConnection conn = Conexion.GetConexion();

            try
            {
                conn.Open();
                string consulta = "SELECT e.*,s.nomSemestre FROM estudiante e INNER JOIN semestre s ON e.idSemestre=s.idSemestre";
                MySqlCommand SQLComando = new MySqlCommand(consulta, conn);

                using (MySqlDataReader reader = SQLComando.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Estudiante estudiante = new Estudiante
                        {
                            Cedula = reader["cedula"].ToString(),
                            IdEstudiante = int.Parse(reader["idEstudiante"].ToString()),
                            Nombre = reader["nombre"].ToString(),
                            Apellidos = reader["apellidos"].ToString(),
                            Correo = reader["correo"].ToString(),
                            Celular = reader["celular"].ToString(),
                            NomSemestre = reader["nomSemestre"].ToString(),
                            Contrasenia = reader["contrasenia"].ToString(),   
                        };

                        estudiantes.Add(estudiante);
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

            return estudiantes;
        }

        public static bool Eliminar(int idEstudiante)
        {
            MySqlConnection conn = Conexion.GetConexion();

            try
            {
                conn.Open();
                string consulta = "DELETE FROM estudiante WHERE idEstudiante = @idEstudiante";
                MySqlCommand SQLComando = new MySqlCommand(consulta, conn);
                SQLComando.Parameters.AddWithValue("@idEstudiante", idEstudiante);

                int filasEliminadas = SQLComando.ExecuteNonQuery();
                return filasEliminadas > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                conn.Close();
            }
        }


        public static bool ActualizarContrasenia(string cedula, string nuevaContrasenia)
        {
            MySqlConnection conn = Conexion.GetConexion();

            try
            {
                conn.Open();
                string consulta = "UPDATE estudiante SET contrasenia = @nuevaContrasenia WHERE cedula = @cedula";
                MySqlCommand SQLComando = new MySqlCommand(consulta, conn);
                SQLComando.Parameters.AddWithValue("@nuevaContrasenia", nuevaContrasenia);
                SQLComando.Parameters.AddWithValue("@cedula", cedula);

                int filasAfectadas = SQLComando.ExecuteNonQuery();
                return filasAfectadas > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                conn.Close();
            }
        }

    }
}
