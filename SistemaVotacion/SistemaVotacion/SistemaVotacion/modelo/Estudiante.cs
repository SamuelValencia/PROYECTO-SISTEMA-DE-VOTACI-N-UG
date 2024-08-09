using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaVotacion.modelo
{
    public class Estudiante
    {
        private int idEstudiante;
        private string nombre;
        private string apellidos;
        private string correo;
        private string cedula;
        private string celular;
        private int idSemestre;
        private string nomSemestre;
        private string contrasenia;

        public Estudiante()
        {
        }

        public Estudiante(string correo, string contrasenia)
        {
            this.correo = correo;
            this.contrasenia = contrasenia;
        }

        public int IdEstudiante { get => idEstudiante; set => idEstudiante = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellidos { get => apellidos; set => apellidos = value; }
        public string Correo { get => correo; set => correo = value; }
        public string Cedula { get => cedula; set => cedula = value; }
        public string Celular { get => celular; set => celular = value; }
        public int IdSemestre { get => idSemestre; set => idSemestre = value; }
        public string NomSemestre { get => nomSemestre; set => nomSemestre = value; }
        public string Contrasenia { get => contrasenia; set => contrasenia = value; }
    }
}
