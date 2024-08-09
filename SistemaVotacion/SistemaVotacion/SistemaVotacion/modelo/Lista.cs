using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaVotacion.modelo
{
    public class Lista
    {
        private int idLista;
        private string nomLista;
        private string nomPresidente;
        private string nomSecretario;
        private string nomPrimerVocal;
        private int carrera;
        private string nomCarrera;
        private string fotoP;
        private string descripcion;
        private int cantVotos;

        public int IdLista { get => idLista; set => idLista = value; }
        public string NomLista { get => nomLista; set => nomLista = value; }
        public string NomPresidente { get => nomPresidente; set => nomPresidente = value; }
        public string NomSecretario { get => nomSecretario; set => nomSecretario = value; }
        public string NomPrimerVocal { get => nomPrimerVocal; set => nomPrimerVocal = value; }
        public int Carrera { get => carrera; set => carrera = value; }
        public string FotoP { get => fotoP; set => fotoP = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public string NomCarrera { get => nomCarrera; set => nomCarrera = value; }
        public int CantVotos { get => cantVotos; set => cantVotos = value; }
    }
}
