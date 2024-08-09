namespace SistemaVotacion.vista
{
    partial class FrmBuscar
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.panel_datos = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnBuscarSemestre = new System.Windows.Forms.Button();
            this.btnBuscarApellido = new System.Windows.Forms.Button();
            this.btnBuscarCedula = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(61)))), ((int)(((byte)(111)))));
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(950, 50);
            this.label1.TabIndex = 4;
            this.label1.Text = "CONSULTAS";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel_datos
            // 
            this.panel_datos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(81)))), ((int)(((byte)(143)))));
            this.panel_datos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_datos.Location = new System.Drawing.Point(0, 50);
            this.panel_datos.Name = "panel_datos";
            this.panel_datos.Size = new System.Drawing.Size(764, 443);
            this.panel_datos.TabIndex = 5;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(61)))), ((int)(((byte)(111)))));
            this.panel1.Controls.Add(this.btnBuscarSemestre);
            this.panel1.Controls.Add(this.btnBuscarApellido);
            this.panel1.Controls.Add(this.btnBuscarCedula);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(764, 50);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(186, 443);
            this.panel1.TabIndex = 47;
            // 
            // btnBuscarSemestre
            // 
            this.btnBuscarSemestre.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(46)))), ((int)(((byte)(84)))));
            this.btnBuscarSemestre.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnBuscarSemestre.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(56)))), ((int)(((byte)(99)))));
            this.btnBuscarSemestre.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(95)))), ((int)(((byte)(52)))));
            this.btnBuscarSemestre.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscarSemestre.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscarSemestre.ForeColor = System.Drawing.Color.White;
            this.btnBuscarSemestre.Image = global::SistemaVotacion.Properties.Resources.semestre;
            this.btnBuscarSemestre.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBuscarSemestre.Location = new System.Drawing.Point(0, 70);
            this.btnBuscarSemestre.Name = "btnBuscarSemestre";
            this.btnBuscarSemestre.Size = new System.Drawing.Size(186, 35);
            this.btnBuscarSemestre.TabIndex = 7;
            this.btnBuscarSemestre.Text = "Buscar Semestre";
            this.btnBuscarSemestre.UseVisualStyleBackColor = false;
            // 
            // btnBuscarApellido
            // 
            this.btnBuscarApellido.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(46)))), ((int)(((byte)(84)))));
            this.btnBuscarApellido.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnBuscarApellido.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(56)))), ((int)(((byte)(99)))));
            this.btnBuscarApellido.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(95)))), ((int)(((byte)(52)))));
            this.btnBuscarApellido.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscarApellido.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscarApellido.ForeColor = System.Drawing.Color.White;
            this.btnBuscarApellido.Image = global::SistemaVotacion.Properties.Resources.editar_informacion;
            this.btnBuscarApellido.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBuscarApellido.Location = new System.Drawing.Point(0, 35);
            this.btnBuscarApellido.Name = "btnBuscarApellido";
            this.btnBuscarApellido.Size = new System.Drawing.Size(186, 35);
            this.btnBuscarApellido.TabIndex = 6;
            this.btnBuscarApellido.Text = "Buscar Apellido";
            this.btnBuscarApellido.UseVisualStyleBackColor = false;
            // 
            // btnBuscarCedula
            // 
            this.btnBuscarCedula.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(46)))), ((int)(((byte)(84)))));
            this.btnBuscarCedula.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnBuscarCedula.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(56)))), ((int)(((byte)(99)))));
            this.btnBuscarCedula.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(95)))), ((int)(((byte)(52)))));
            this.btnBuscarCedula.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscarCedula.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscarCedula.ForeColor = System.Drawing.Color.White;
            this.btnBuscarCedula.Image = global::SistemaVotacion.Properties.Resources.tarjeta_de_seguro_de_salud;
            this.btnBuscarCedula.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBuscarCedula.Location = new System.Drawing.Point(0, 0);
            this.btnBuscarCedula.Name = "btnBuscarCedula";
            this.btnBuscarCedula.Size = new System.Drawing.Size(186, 35);
            this.btnBuscarCedula.TabIndex = 5;
            this.btnBuscarCedula.Text = "Buscar Cédula";
            this.btnBuscarCedula.UseVisualStyleBackColor = false;
            // 
            // FrmBuscar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(950, 493);
            this.Controls.Add(this.panel_datos);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FrmBuscar";
            this.Text = "FrmConsultas";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.Button btnBuscarSemestre;
        public System.Windows.Forms.Button btnBuscarApellido;
        public System.Windows.Forms.Button btnBuscarCedula;
        public System.Windows.Forms.Panel panel_datos;
    }
}