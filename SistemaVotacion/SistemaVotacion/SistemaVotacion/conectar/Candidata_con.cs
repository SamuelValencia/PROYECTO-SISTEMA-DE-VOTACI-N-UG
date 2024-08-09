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
    public class Candidata_con
    {
        public static int Insertar(Candidata c)
        {
            MySqlConnection conn = Conexion.GetConexion();

            try
            {
                conn.Open();
                string consulta = "INSERT INTO candidata(nombre, apellidos, fechaNac, formacion_academica, pasatiempos, habilidades, intereres, aspiraciones_futuro, altura, peso, color_ojos, color_cabello, medida_cintura, medida_busto, medida_cadera, puntuacionReina,puntuacionMissFotogenica)" +
                                  " VALUES (@nombre, @apellidos, @fechaNac, @formacion_academica, @pasatiempos, @habilidades, @intereres, @aspiraciones_futuro, @altura, @peso, @color_ojos, @color_cabello, @medida_cintura, @medida_busto, @medida_cadera, @puntuacionReina,@puntuacionMissFotogenica)";
                MySqlCommand SQLComando = new MySqlCommand(consulta, conn);
                SQLComando.Parameters.AddWithValue("@nombre", c.Nombre);
                SQLComando.Parameters.AddWithValue("@apellidos", c.Apellidos);
                SQLComando.Parameters.AddWithValue("@fechaNac", c.FechaNac);
                SQLComando.Parameters.AddWithValue("@formacion_academica", c.Formacion_academica);
                SQLComando.Parameters.AddWithValue("@pasatiempos", c.Pasatiempos);
                SQLComando.Parameters.AddWithValue("@habilidades", c.Pasatiempos);
                SQLComando.Parameters.AddWithValue("@intereres", c.Intereres);
                SQLComando.Parameters.AddWithValue("@aspiraciones_futuro", c.Aspiraciones_futuro);
                SQLComando.Parameters.AddWithValue("@altura", c.Altura);
                SQLComando.Parameters.AddWithValue("@peso", c.Peso);
                SQLComando.Parameters.AddWithValue("@color_ojos", c.Color_ojos);
                SQLComando.Parameters.AddWithValue("@color_cabello", c.Color_cabello);
                SQLComando.Parameters.AddWithValue("@medida_cintura", c.Medida_cintura);
                SQLComando.Parameters.AddWithValue("@medida_busto", c.Medida_busto);
                SQLComando.Parameters.AddWithValue("@medida_cadera", c.Medida_cadera);
                SQLComando.Parameters.AddWithValue("@puntuacionReina", c.PuntuacionReina);
                SQLComando.Parameters.AddWithValue("@puntuacionMissFotogenica", c.PuntuacionMissFotogenica);
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

        public static Candidata ObtenerGanadoraMissFotogenica()
        {
            MySqlConnection conn = Conexion.GetConexion();

            try
            {
                conn.Open();
                string consulta = "SELECT c.*,g.foto FROM candidata c INNER JOIN galeria g ON c.idCandidata=g.idCandidata WHERE g.estado=1  ORDER BY puntuacionMissFotogenica DESC LIMIT 1";
                MySqlCommand SQLComando = new MySqlCommand(consulta, conn);
                using (MySqlDataReader reader = SQLComando.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        Candidata candidata = new Candidata
                        {
                            IdCandidata = Convert.ToInt32(reader["idCandidata"]),
                            Nombre = Convert.ToString(reader["nombre"]),
                            Apellidos = Convert.ToString(reader["apellidos"]),
                            PuntuacionMissFotogenica = Convert.ToInt32(reader["puntuacionMissFotogenica"]),
                            PuntuacionReina= Convert.ToInt32(reader["puntuacionReina"]),
                            FotoP = Convert.ToString(reader["foto"]),
                        };
                        return candidata;
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

        public static Candidata ObtenerGanadoraReina()
        {
            MySqlConnection conn = Conexion.GetConexion();

            try
            {
                conn.Open();
                string consulta = "SELECT c.*,g.foto FROM candidata c INNER JOIN galeria g ON c.idCandidata=g.idCandidata WHERE g.estado=1  ORDER BY puntuacionReina DESC LIMIT 1";
                MySqlCommand SQLComando = new MySqlCommand(consulta, conn);
                using (MySqlDataReader reader = SQLComando.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        Candidata candidata = new Candidata
                        {
                            IdCandidata = Convert.ToInt32(reader["idCandidata"]),
                            Nombre = Convert.ToString(reader["nombre"]),
                            Apellidos = Convert.ToString(reader["apellidos"]),
                            PuntuacionMissFotogenica = Convert.ToInt32(reader["puntuacionMissFotogenica"]),
                            PuntuacionReina = Convert.ToInt32(reader["puntuacionReina"]),
                            FotoP = Convert.ToString(reader["foto"]),
                        };
                        return candidata;
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

        public static List<Candidata> ListarCandidatas()
        {
            MySqlConnection conn = Conexion.GetConexion();
            List<Candidata> listaCandidatas = new List<Candidata>();

            try
            {
                conn.Open();
                string consulta = "SELECT c.*,g.foto FROM candidata c INNER JOIN galeria g ON c.idCandidata=g.idCandidata WHERE g.estado=1";
                MySqlCommand SQLComando = new MySqlCommand(consulta, conn);
                using (MySqlDataReader reader = SQLComando.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Candidata candidata = new Candidata
                        {
                            IdCandidata = Convert.ToInt32(reader["idCandidata"]),
                            Nombre = Convert.ToString(reader["nombre"]),
                            Apellidos = Convert.ToString(reader["apellidos"]),
                            FechaNac = reader["fechaNac"].ToString(),
                            Formacion_academica = Convert.ToString(reader["formacion_academica"]),
                            Pasatiempos = Convert.ToString(reader["pasatiempos"]),
                            Habilidades = Convert.ToString(reader["habilidades"]),
                            Intereres = Convert.ToString(reader["intereres"]),
                            Aspiraciones_futuro = Convert.ToString(reader["aspiraciones_futuro"]),
                            Altura = Convert.ToDouble(reader["altura"]),
                            Peso = Convert.ToDouble(reader["peso"]),
                            Color_ojos = Convert.ToString(reader["color_ojos"]),
                            Color_cabello = Convert.ToString(reader["color_cabello"]),
                            Medida_cintura = Convert.ToDouble(reader["medida_cintura"]),
                            Medida_busto = Convert.ToDouble(reader["medida_busto"]),
                            Medida_cadera = Convert.ToDouble(reader["medida_cadera"]),
                            PuntuacionReina = Convert.ToInt32(reader["puntuacionReina"]),
                            PuntuacionMissFotogenica = Convert.ToInt32(reader["puntuacionMissFotogenica"]),
                            FotoP = Convert.ToString(reader["foto"])
                        };
                        listaCandidatas.Add(candidata);
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

            return listaCandidatas;
        }

        public static Candidata BuscarCandidata(int idCandidata)
        {
            MySqlConnection conn = Conexion.GetConexion();

            try
            {
                conn.Open();
                string consulta = "SELECT * FROM candidata WHERE idCandidata=@idCandidata";
                MySqlCommand SQLComando = new MySqlCommand(consulta, conn);
                SQLComando.Parameters.AddWithValue("@idCandidata", idCandidata);
                using (MySqlDataReader reader = SQLComando.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        Candidata candidata = new Candidata
                        {
                            IdCandidata = Convert.ToInt32(reader["idCandidata"]),
                            Nombre = Convert.ToString(reader["nombre"]),
                            Apellidos = Convert.ToString(reader["apellidos"]),
                            FechaNac = reader["fechaNac"].ToString(),
                            Formacion_academica = Convert.ToString(reader["formacion_academica"]),
                            Pasatiempos = Convert.ToString(reader["pasatiempos"]),
                            Habilidades = Convert.ToString(reader["habilidades"]),
                            Intereres = Convert.ToString(reader["intereres"]),
                            Aspiraciones_futuro = Convert.ToString(reader["aspiraciones_futuro"]),
                            Altura = Convert.ToDouble(reader["altura"]),
                            Peso = Convert.ToDouble(reader["peso"]),
                            Color_ojos = Convert.ToString(reader["color_ojos"]),
                            Color_cabello = Convert.ToString(reader["color_cabello"]),
                            Medida_cintura = Convert.ToDouble(reader["medida_cintura"]),
                            Medida_busto = Convert.ToDouble(reader["medida_busto"]),
                            Medida_cadera = Convert.ToDouble(reader["medida_cadera"]),
                            PuntuacionReina = Convert.ToInt32(reader["puntuacionReina"]),
                            PuntuacionMissFotogenica = Convert.ToInt32(reader["puntuacionMissFotogenica"]),
                        };
                        return candidata;
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

        public static bool AumentarPuntuacionReina(Votacion v)
        {
            MySqlConnection conn = Conexion.GetConexion();
            MessageBox.Show(v.IdCandidata+"");
            try
            {
                conn.Open();
                string consulta = "UPDATE candidata SET puntuacionReina= puntuacionReina+1 WHERE idCandidata=@idCandidata";
                MySqlCommand SQLComando = new MySqlCommand(consulta, conn);
                SQLComando.Parameters.AddWithValue("@idCandidata", v.IdCandidata);
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


        public static bool AumentarPuntuacionMissFotogenica(Votacion v)
        {
            MySqlConnection conn = Conexion.GetConexion();

            try
            {
                conn.Open();
                string consulta = "UPDATE candidata SET puntuacionMissFotogenica= puntuacionMissFotogenica+1 WHERE idCandidata=@idCandidata";
                MySqlCommand SQLComando = new MySqlCommand(consulta, conn);
                SQLComando.Parameters.AddWithValue("@idCandidata", v.IdCandidata);
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
    }


}
