using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaVotacion.modelo
{
    public class Votacion
    {
        private int idVotacion;
        private int idCandidata;
        private string matricula;
        private int tipo;

        public int IdVotacion { get => idVotacion; set => idVotacion = value; }
        public int IdCandidata { get => idCandidata; set => idCandidata = value; }
        public string Matricula { get => matricula; set => matricula = value; }
        public int Tipo { get => tipo; set => tipo = value; }
    }
}
