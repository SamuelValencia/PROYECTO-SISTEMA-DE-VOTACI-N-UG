using SistemaVotacion.controlador;
using SistemaVotacion.modelo;
using SistemaVotacion.vista;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaVotacion
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            FrmLogin form = new FrmLogin();
            FrmLogin_Controlador c = new FrmLogin_Controlador(form);
            c.Iniciar();
           
        }
    }
}
