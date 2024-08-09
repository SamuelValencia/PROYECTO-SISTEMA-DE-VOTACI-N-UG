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
    public class Semestre_con
    {
        public static List<Semestre> Listar()
        {
            List<Semestre> semestres = new List<Semestre>();

            MySqlConnection conn = Conexion.GetConexion();

            try
            {
                conn.Open();
                string consulta = "SELECT * from semestre";
                MySqlCommand SQLComando = new MySqlCommand(consulta, conn);

                using (MySqlDataReader reader = SQLComando.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Semestre semestre = new Semestre
                        {
                            IdSemestre = int.Parse(reader["idSemestre"].ToString()),
                            NomSemestre = reader["nomSemestre"].ToString(),

                        };

                        semestres.Add(semestre);
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

            return semestres;
        }
    }
}
