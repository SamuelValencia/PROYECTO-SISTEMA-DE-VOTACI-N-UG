using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaVotacion.modelo
{
    public class Propuesta
    {
        private int idPropuesta;
        private int idLista;
        private string descripcion;

        public int IdPropuesta { get => idPropuesta; set => idPropuesta = value; }
        public int IdLista { get => idLista; set => idLista = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
    }
}
