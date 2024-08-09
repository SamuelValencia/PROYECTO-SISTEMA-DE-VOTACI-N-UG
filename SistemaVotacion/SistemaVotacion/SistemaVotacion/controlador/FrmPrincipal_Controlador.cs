using SistemaVotacion.conectar;
using SistemaVotacion.modelo;
using SistemaVotacion.Utilidad;
using SistemaVotacion.vista;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaVotacion.controlador
{
    public class FrmPrincipal_Controlador
    {
        private FrmPrincipal vista;
        private FrmLogin vistaLogin;
        private Object usuario;
        private static int votar = 0;

        public FrmPrincipal_Controlador(FrmPrincipal vista,FrmLogin vistaLogin, Object usuario)
        {
            Archivo archivo = new Archivo("iniciar");
            this.vista = vista;
            this.vistaLogin = vistaLogin;
            this.usuario = usuario;

            this.vista.btnInscripcion.Click += BtnInscripcion_Click;
            this.vista.btnConsulta.Click += BtnConsulta_Click;
            this.vista.btnResultados.Click += BtnResultados_Click;
            this.vista.btnListas.Click+= BtnListas_Click;
            this.vista.btnBuscar.Click += BtnBuscar_Click;
            this.vista.btnVisualizar.Click += BtnVisualizar_Click;

            this.vista.btnGuardar.Click += BtnGuardar_Click;
            this.vista.FormClosing += Vista_FormClosing;
            this.vista.btnCerrar.Click += BtnCerrar_Click;

            try
            {
                string inicio = archivo.Obtener();
                if (inicio.Equals(""))
                {
                    vista.radBDetener.Checked = true;
                    votar = 0;
                }
                else if (int.Parse(inicio) == 0)
                {
                    vista.radBDetener.Checked = true;
                    votar = 0;
                }
                else
                {
                    vista.radBIniciar.Checked = true;
                    votar = 1;
                }
            }
            catch (Exception ) {  }
           

            if (usuario is Administrador)//administrador
            {
                this.vista.btnListas.Visible = false;
                this.vista.btnVisualizar.Visible = false;
            }
            else if(usuario is Estudiante)//estudiante
            {
                this.vista.btnInscripcion.Visible = false;
                this.vista.btnConsulta.Visible = false;
                this.vista.panel_iniciar.Visible = false;
                this.vista.btnBuscar.Visible = false;

            }
            else//invitado
            {
                this.vista.btnBuscar.Visible = false;
                this.vista.btnInscripcion.Visible=false;
                this.vista.btnListas.Visible=false;
                this.vista.btnConsulta.Visible = false;
                this.vista.btnResultados.Visible=false;
                this.vista.panel_iniciar.Visible = false;
            }
        }


        private void Vista_FormClosing(object sender, FormClosingEventArgs e)
        {
            vista.Dispose();
            vistaLogin.Show();
        }

        public void iniciar()
        {
            this.vista.ShowDialog();
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            vista.Dispose();
            vistaLogin.Show();
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            Archivo archivo = new Archivo("iniciar");
            string dato = "1";
            if (vista.radBDetener.Checked)
            {  
                dato = "0";
            }

            if (archivo.Guardar(dato)) MessageBox.Show("Se Guardó exitosamente");
            else MessageBox.Show("Error al guardar");

        }

        private void BtnVisualizar_Click(object sender, EventArgs e)
        {
            FrmVisualizarLista frm = new FrmVisualizarLista();
            FrmVisualizarLista_Controlador controlador = new FrmVisualizarLista_Controlador(frm, new Lista());
            AbrirHijo(frm);
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            FrmBuscar frm = new FrmBuscar();
            FrmBuscar_Controlador controlador = new FrmBuscar_Controlador(frm, new Estudiante(), vista);
            AbrirHijo(frm);
        }

        private void BtnInscripcion_Click(object sender, EventArgs e)
        {
            FrmRegistroLista frm = new FrmRegistroLista();
            FrmRegistroLista_Controlador controlador = new FrmRegistroLista_Controlador(frm, new Lista(),1,0);
            AbrirHijo(frm);
        }

        private void AbrirHijo(object fornHijo)
        {
            if (this.vista.panel3.Controls.Count > 0)
            {
                this.vista.panel3.Controls.RemoveAt(0);
            }
            Form fh = fornHijo as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            this.vista.panel3.Controls.Add(fh);
            this.vista.panel3.Tag = fh;

            fh.Show();
        }



        private void BtnConsulta_Click(object sender, EventArgs e)
        {
            FrmConsulta frm = new FrmConsulta();
            FrmConsulta_Controlador controlador = new FrmConsulta_Controlador(frm,new Lista(), new Estudiante(),vista);
            AbrirHijo(frm);
        }

        private void BtnResultados_Click(object sender, EventArgs e)
        {
            FrmResultado frm = new FrmResultado();
            FrmResultado_Controlador controlador = new FrmResultado_Controlador(frm, new Lista());
            AbrirHijo(frm);
        }

        private void BtnListas_Click(object sender, EventArgs e)
        {
            Estudiante est = (Estudiante)usuario;
            if (Lista_con.ExisteVotacionPorEstudiante(est.IdEstudiante))
            {
                MessageBox.Show("Usted ya realizó su votación");
                return;
            }

            if (FrmPrincipal_Controlador.votar == 0)
            {
                MessageBox.Show("Las votaciones estan deshabilitadas");
                return;
            }
            FrmVotarLista frm = new FrmVotarLista();
            FrmVotarLista_Controlador controlador = new FrmVotarLista_Controlador(frm, new Lista(), est.IdEstudiante);
            AbrirHijo(frm);
        }
    }
}
