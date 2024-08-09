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
    public class Galeria_con
    {
        public static bool Insertar(Galeria g)
        {
            MySqlConnection conn = Conexion.GetConexion();

            try
            {
                conn.Open();
                string consulta = "INSERT INTO galeria(idCandidata,foto,titulo,descripcion,estado)" +
                    " VALUES (@idCandidata,@foto,@titulo,@descripcion,@estado)";
                MySqlCommand SQLComando = new MySqlCommand(consulta, conn);
                SQLComando.Parameters.AddWithValue("@idCandidata", g.IdCandidata);
                SQLComando.Parameters.AddWithValue("@foto", g.Foto);
                SQLComando.Parameters.AddWithValue("@titulo", g.Titulo);
                SQLComando.Parameters.AddWithValue("@descripcion", g.Descripcion);
                SQLComando.Parameters.AddWithValue("@estado", g.Estado);
              
                SQLComando.ExecuteNonQuery();
                return true;

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

        public static List<Galeria> ListarGaleria_IDCandidata(int idCandidata)
        {
            List<Galeria> galerias = new List<Galeria>();

            MySqlConnection conn = Conexion.GetConexion();

            try
            {
                conn.Open();
                string consulta = "SELECT * FROM galeria WHERE idCandidata = @idCandidata";
                MySqlCommand SQLComando = new MySqlCommand(consulta, conn);
                SQLComando.Parameters.AddWithValue("@idCandidata", idCandidata);

                using (MySqlDataReader reader = SQLComando.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Galeria galeria = new Galeria
                        {
                            Foto = reader["foto"].ToString(),
                            Titulo= reader["titulo"].ToString(),
                            Descripcion = reader["descripcion"].ToString(),
                        };

                        galerias.Add(galeria);
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

            return galerias;
        }
    }
}
