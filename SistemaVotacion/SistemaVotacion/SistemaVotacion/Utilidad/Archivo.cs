using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SistemaVotacion.Utilidad
{
    public class Archivo
    {
        private string rutaArchivo;

        public Archivo(string ruta)
        {
            rutaArchivo = ruta;
        }

        public bool Guardar(string contenido)
        {
            try
            {
                File.WriteAllText(rutaArchivo, contenido);
                return true;
            }
            catch (Exception)
            {
            }
            return false;
        }

        public string Obtener()
        {
            try
            {
                if (!File.Exists(rutaArchivo))
                {
                    File.Create(rutaArchivo).Close(); 
                }

                string contenido = File.ReadAllText(rutaArchivo);
                return contenido;
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }


    }
}
