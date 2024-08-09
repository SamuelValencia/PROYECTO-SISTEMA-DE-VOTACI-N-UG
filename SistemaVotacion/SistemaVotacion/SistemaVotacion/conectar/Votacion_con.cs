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
    public class Votacion_con
    {
        public static bool Insertar(Votacion v)
        {
            MySqlConnection conn = Conexion.GetConexion();

            try
            {
                conn.Open();
                string consulta = "INSERT INTO votacion(idCandidata, matricula, tipo)" +
                                  " VALUES (@idCandidata, @matricula, @tipo)";
                MySqlCommand SQLComando = new MySqlCommand(consulta, conn);
                SQLComando.Parameters.AddWithValue("@idCandidata", v.IdCandidata);
                SQLComando.Parameters.AddWithValue("@matricula", v.Matricula);
                SQLComando.Parameters.AddWithValue("@tipo", v.Tipo);
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

        public static bool BuscarVotacionMissFotogenica(string matricula)
        {
            MySqlConnection conn = Conexion.GetConexion();

            try
            {
                conn.Open();
                string consulta = "SELECT * FROM votacion WHERE matricula=@matricula AND tipo=1";
                MySqlCommand SQLComando = new MySqlCommand(consulta, conn);
                SQLComando.Parameters.AddWithValue("@matricula", matricula);
                using (MySqlDataReader reader = SQLComando.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return true;
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

            return false;
        }

        public static bool BuscarVotacionReinaa(string matricula)
        {
            MySqlConnection conn = Conexion.GetConexion();

            try
            {
                conn.Open();
                string consulta = "SELECT * FROM votacion WHERE matricula=@matricula AND tipo=2";
                MySqlCommand SQLComando = new MySqlCommand(consulta, conn);
                SQLComando.Parameters.AddWithValue("@matricula", matricula);
                using (MySqlDataReader reader = SQLComando.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return true;
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

            return false;
        }
    }
}
