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
    public class Propuesta_con
    {
        public static int Insertar(Propuesta p)
        {
            MySqlConnection conn = Conexion.GetConexion();

            try
            {
                conn.Open();
                string consulta = "INSERT INTO propuestas(dscripcion, idLista)" +
                                  " VALUES (@dscripcion, @idLista)";
                MySqlCommand SQLComando = new MySqlCommand(consulta, conn);
                SQLComando.Parameters.AddWithValue("@dscripcion", p.Descripcion);
                SQLComando.Parameters.AddWithValue("@idLista", p.IdLista);
                

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

        public static List<Propuesta> ObtenerPropuestasPorIdLista(int idLista)
        {
            List<Propuesta> propuestas = new List<Propuesta>();

            MySqlConnection conn = Conexion.GetConexion();

            try
            {
                conn.Open();
                string consulta = "SELECT * FROM propuestas WHERE idLista = @idLista";
                MySqlCommand SQLComando = new MySqlCommand(consulta, conn);
                SQLComando.Parameters.AddWithValue("@idLista", idLista);

                using (MySqlDataReader reader = SQLComando.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Propuesta propuesta = new Propuesta
                        {
                            IdPropuesta = int.Parse(reader["idPropuesta"].ToString()),
                            Descripcion = reader["dscripcion"].ToString(),
                            IdLista = int.Parse(reader["idLista"].ToString())
                        };

                        propuestas.Add(propuesta);
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

            return propuestas;
        }


        public static void EliminarPropuestasPorIdLista(int idLista)
        {
            MySqlConnection conn = Conexion.GetConexion();

            try
            {
                conn.Open();
                string consulta = "DELETE FROM propuestas WHERE idLista = @idLista";
                MySqlCommand SQLComando = new MySqlCommand(consulta, conn);
                SQLComando.Parameters.AddWithValue("@idLista", idLista);

                SQLComando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }


    }
}
