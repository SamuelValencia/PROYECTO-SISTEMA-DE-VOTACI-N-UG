using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaVotacion.modelo
{
    public class Candidata
    {
        private int idCandidata;
        private string nombre;
        private string apellidos;
        private string fechaNac;
        private string formacion_academica;
        private string pasatiempos;
        private string habilidades;
        private string intereres;
        private string aspiraciones_futuro;
        private double altura;
        private double peso;
        private string color_ojos;
        private string color_cabello;
        private double medida_cintura;
        private double medida_busto;
        private double medida_cadera;
        private int puntuacionReina;
        private int puntuacionMissFotogenica;
        private string fotoP;

        public int IdCandidata { get => idCandidata; set => idCandidata = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellidos { get => apellidos; set => apellidos = value; }
        public string FechaNac { get => fechaNac; set => fechaNac = value; }
        public string Formacion_academica { get => formacion_academica; set => formacion_academica = value; }
        public string Pasatiempos { get => pasatiempos; set => pasatiempos = value; }
        public string Habilidades { get => habilidades; set => habilidades = value; }
        public string Intereres { get => intereres; set => intereres = value; }
        public string Aspiraciones_futuro { get => aspiraciones_futuro; set => aspiraciones_futuro = value; }
        public double Altura { get => altura; set => altura = value; }
        public double Peso { get => peso; set => peso = value; }
        public string Color_ojos { get => color_ojos; set => color_ojos = value; }
        public string Color_cabello { get => color_cabello; set => color_cabello = value; }
        public double Medida_cintura { get => medida_cintura; set => medida_cintura = value; }
        public double Medida_busto { get => medida_busto; set => medida_busto = value; }
        public double Medida_cadera { get => medida_cadera; set => medida_cadera = value; }
        
        public string FotoP { get => fotoP; set => fotoP = value; }
        public int PuntuacionReina { get => puntuacionReina; set => puntuacionReina = value; }
        public int PuntuacionMissFotogenica { get => puntuacionMissFotogenica; set => puntuacionMissFotogenica = value; }
    }
}
