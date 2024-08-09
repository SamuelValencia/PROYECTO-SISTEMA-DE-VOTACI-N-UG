using SistemaVotacion.modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace SistemaVotacion.conectar
{
    public class Carrera_con
    {

        public static List<Carrera> Listar()
        {
            List<Carrera> carreras = new List<Carrera>();

            MySqlConnection conn = Conexion.GetConexion();

            try
            {
                conn.Open();
                string consulta = "SELECT * from carrera";
                MySqlCommand SQLComando = new MySqlCommand(consulta, conn);

                using (MySqlDataReader reader = SQLComando.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Carrera carrera = new Carrera
                        {
                            IdCarrera = int.Parse(reader["idCarrera"].ToString()),
                            NomCarrera = reader["nomCarrera"].ToString(),
                           
                        };

                        carreras.Add(carrera);
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

            return carreras;
        }
    }
}
