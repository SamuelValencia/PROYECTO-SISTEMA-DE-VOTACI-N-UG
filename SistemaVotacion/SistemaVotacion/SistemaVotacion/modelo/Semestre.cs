using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaVotacion.modelo
{
    public class Semestre
    {
        private int idSemestre;
        private string nomSemestre;

        public int IdSemestre { get => idSemestre; set => idSemestre = value; }
        public string NomSemestre { get => nomSemestre; set => nomSemestre = value; }

        public override string ToString()
        {
            return NomSemestre;
        }
    }
}
