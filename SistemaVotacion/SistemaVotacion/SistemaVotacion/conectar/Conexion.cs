using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaVotacion.conectar
{
    public class Conexion
    {
        private static string servidor = "localhost";
        private static string bd = "BDVotacion";
        private static string usuario = "root";
        private static string password = "0955399639";
        //private static string password = "12345";
        private static string port = "3306";

        public static MySqlConnection GetConexion()
        {
            string cadenaConexio = "Server=" + servidor + ";Port=" + port + ";Database=" + bd + ";Uid=" + usuario + ";password=" + password + ";";
            try
            {
                MySqlConnection conexioBD = new MySqlConnection(cadenaConexio);
                return conexioBD;

            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message, "Error Conexion");
                return null;
            }
        }
    }
}
