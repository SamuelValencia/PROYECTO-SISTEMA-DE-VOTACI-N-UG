using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaVotacion.modelo
{
    public class Galeria
    {
        private int idGaleria;
        private int idCandidata;

        private string foto;
        private string titulo;
        private string descripcion;
        private byte estado;

        public int IdGaleria { get => idGaleria; set => idGaleria = value; }
        public int IdCandidata { get => idCandidata; set => idCandidata = value; }
        public string Foto { get => foto; set => foto = value; }
        public string Titulo { get => titulo; set => titulo = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public byte Estado { get => estado; set => estado = value; }
    }
}
