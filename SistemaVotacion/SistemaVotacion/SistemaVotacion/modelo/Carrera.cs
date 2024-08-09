using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaVotacion.modelo
{
    public class Carrera
    {
        private int idCarrera;
        private string nomCarrera;

        public int IdCarrera { get => idCarrera; set => idCarrera = value; }
        public string NomCarrera { get => nomCarrera; set => nomCarrera = value; }

        public override string ToString()
        {
            return NomCarrera;
        }
    }
}
