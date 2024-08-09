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
    public class Lista_con
    {
        public static int Insertar(Lista l)
        {
            MySqlConnection conn = Conexion.GetConexion();

            try
            {
                conn.Open();
                string consulta = "INSERT INTO lista(nomLista, nomPresidente, nomSecretario, nomPrimerVocal, idCarrera, fotoP, descripcion,cantVotos)" +
                                  " VALUES (@nomLista, @nomPresidente, @nomSecretario, @nomPrimerVocal, @idCarrera, @fotoP, @descripcion,@cantVotos)";
                MySqlCommand SQLComando = new MySqlCommand(consulta, conn);
                SQLComando.Parameters.AddWithValue("@nomLista", l.NomLista);
                SQLComando.Parameters.AddWithValue("@nomPresidente", l.NomPresidente);
                SQLComando.Parameters.AddWithValue("@nomSecretario", l.NomSecretario);
                SQLComando.Parameters.AddWithValue("@nomPrimerVocal", l.NomPrimerVocal);
                SQLComando.Parameters.AddWithValue("@idCarrera", l.Carrera);
                SQLComando.Parameters.AddWithValue("@fotoP", l.FotoP);
                SQLComando.Parameters.AddWithValue("@descripcion", l.Descripcion);
                SQLComando.Parameters.AddWithValue("@cantVotos", l.CantVotos);
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

        public static List<Lista> Listar()
        {
            List<Lista> listas = new List<Lista>();

            MySqlConnection conn = Conexion.GetConexion();

            try
            {
                conn.Open();
                string consulta = "SELECT l.*,c.nomCarrera FROM lista l INNER JOIN carrera c ON c.idCarrera=l.idCarrera";
                MySqlCommand SQLComando = new MySqlCommand(consulta, conn);

                using (MySqlDataReader reader = SQLComando.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Lista lista = new Lista
                        {
                            NomLista = reader["nomLista"].ToString(),
                            IdLista = int.Parse(reader["idLista"].ToString()),
                            NomPresidente = reader["nomPresidente"].ToString(),
                            NomSecretario = reader["nomSecretario"].ToString(),
                            NomPrimerVocal = reader["nomPrimerVocal"].ToString(),
                            NomCarrera = reader["nomCarrera"].ToString(),
                            FotoP = reader["fotoP"].ToString(),
                            Descripcion = reader["descripcion"].ToString(),
                            CantVotos= int.Parse(reader["cantVotos"].ToString()),
                        };

                        listas.Add(lista);
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

            return listas;
        }

        public static Lista ObtenerListaPorId(int idLista)
        {
            Lista lista = null;

            MySqlConnection conn = Conexion.GetConexion();

            try
            {
                conn.Open();
                string consulta = "SELECT l.*, c.nomCarrera FROM lista l INNER JOIN carrera c ON c.idCarrera = l.idCarrera WHERE l.idLista = @idLista";
                MySqlCommand SQLComando = new MySqlCommand(consulta, conn);
                SQLComando.Parameters.AddWithValue("@idLista", idLista);

                using (MySqlDataReader reader = SQLComando.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        lista = new Lista
                        {
                            NomLista = reader["nomLista"].ToString(),
                            IdLista = int.Parse(reader["idLista"].ToString()),
                            NomPresidente = reader["nomPresidente"].ToString(),
                            NomSecretario = reader["nomSecretario"].ToString(),
                            NomPrimerVocal = reader["nomPrimerVocal"].ToString(),
                            NomCarrera = reader["nomCarrera"].ToString(),
                            FotoP = reader["fotoP"].ToString(),
                            Descripcion = reader["descripcion"].ToString(),
                            Carrera= int.Parse(reader["idCarrera"].ToString()),
                        };
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

            return lista;
        }

        public static bool Actualizar(Lista lista)
        {
            MySqlConnection conn = Conexion.GetConexion();

            try
            {
                conn.Open();
                string consulta = "UPDATE lista SET nomLista = @nomLista, nomPresidente = @nomPresidente, nomSecretario = @nomSecretario, " +
                                  "nomPrimerVocal = @nomPrimerVocal, idCarrera = @idCarrera, fotoP = @fotoP, descripcion = @descripcion " +
                                  "WHERE idLista = @idLista";
                MySqlCommand SQLComando = new MySqlCommand(consulta, conn);
                SQLComando.Parameters.AddWithValue("@nomLista", lista.NomLista);
                SQLComando.Parameters.AddWithValue("@nomPresidente", lista.NomPresidente);
                SQLComando.Parameters.AddWithValue("@nomSecretario", lista.NomSecretario);
                SQLComando.Parameters.AddWithValue("@nomPrimerVocal", lista.NomPrimerVocal);
                SQLComando.Parameters.AddWithValue("@idCarrera", lista.Carrera);
                SQLComando.Parameters.AddWithValue("@fotoP", lista.FotoP);
                SQLComando.Parameters.AddWithValue("@descripcion", lista.Descripcion);
                SQLComando.Parameters.AddWithValue("@idLista", lista.IdLista);

                int filasActualizadas = SQLComando.ExecuteNonQuery();

                return filasActualizadas > 0;
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

        public static bool Eliminar(int idLista)
        {
            MySqlConnection conn = Conexion.GetConexion();

            try
            {
                conn.Open();
                string consulta = "DELETE FROM lista WHERE idLista = @idLista";
                MySqlCommand SQLComando = new MySqlCommand(consulta, conn);
                SQLComando.Parameters.AddWithValue("@idLista", idLista);

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


        public static bool AumentarPuntuacion(int idLista, int idEstudiante)
        {
            MySqlConnection conn = Conexion.GetConexion();
            try
            {
                conn.Open();
                string consulta = "UPDATE lista SET cantVotos= cantVotos+1 WHERE idLista=@idLista";
                MySqlCommand SQLComando = new MySqlCommand(consulta, conn);
                SQLComando.Parameters.AddWithValue("@idLista", idLista);
                SQLComando.ExecuteNonQuery();

                consulta = "INSERT votacion_estudiante(idLista,idEstudiante) values(@idLista, @idEstudiante)";
                SQLComando = new MySqlCommand(consulta, conn);
                SQLComando.Parameters.AddWithValue("@idLista", idLista);
                SQLComando.Parameters.AddWithValue("@idEstudiante", idEstudiante);
                SQLComando.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            
            return false;
        }

        public static bool ExisteVotacionPorEstudiante(int idEstudiante)
        {
            MySqlConnection conn = Conexion.GetConexion();
            try
            {
                conn.Open();
                string consulta = "SELECT COUNT(*) FROM votacion_estudiante WHERE idEstudiante = @idEstudiante";
                MySqlCommand SQLComando = new MySqlCommand(consulta, conn);
                SQLComando.Parameters.AddWithValue("@idEstudiante", idEstudiante);

                int count = Convert.ToInt32(SQLComando.ExecuteScalar());
                return count > 0;
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
