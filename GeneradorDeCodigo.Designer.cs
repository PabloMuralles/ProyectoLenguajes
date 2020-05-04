namespace Proyecto_Lenguajes
{
    partial class GeneradorDeCodigo
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
            this.Generador = new System.Windows.Forms.Button();
            this.Retorno = new System.Windows.Forms.Button();
            this.ubicacion = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Seleccionar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Generador
            // 
            this.Generador.Location = new System.Drawing.Point(46, 190);
            this.Generador.Name = "Generador";
            this.Generador.Size = new System.Drawing.Size(75, 23);
            this.Generador.TabIndex = 0;
            this.Generador.Text = "Generar ";
            this.Generador.UseVisualStyleBackColor = true;
            this.Generador.Click += new System.EventHandler(this.Generador_Click);
            // 
            // Retorno
            // 
            this.Retorno.Location = new System.Drawing.Point(189, 190);
            this.Retorno.Name = "Retorno";
            this.Retorno.Size = new System.Drawing.Size(75, 23);
            this.Retorno.TabIndex = 1;
            this.Retorno.Text = "Regresar";
            this.Retorno.UseVisualStyleBackColor = true;
            this.Retorno.Click += new System.EventHandler(this.Retorno_Click);
            // 
            // ubicacion
            // 
            this.ubicacion.Location = new System.Drawing.Point(12, 68);
            this.ubicacion.Name = "ubicacion";
            this.ubicacion.Size = new System.Drawing.Size(294, 20);
            this.ubicacion.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Ubicación";
            // 
            // Seleccionar
            // 
            this.Seleccionar.Location = new System.Drawing.Point(117, 94);
            this.Seleccionar.Name = "Seleccionar";
            this.Seleccionar.Size = new System.Drawing.Size(75, 23);
            this.Seleccionar.TabIndex = 4;
            this.Seleccionar.Text = "Seleccionar";
            this.Seleccionar.UseVisualStyleBackColor = true;
            this.Seleccionar.Click += new System.EventHandler(this.Seleccionar_Click);
            // 
            // GeneradorDeCodigo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(318, 245);
            this.Controls.Add(this.Seleccionar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ubicacion);
            this.Controls.Add(this.Retorno);
            this.Controls.Add(this.Generador);
            this.Name = "GeneradorDeCodigo";
            this.Text = "GeneradorDeCodigo";
            this.Load += new System.EventHandler(this.GeneradorDeCodigo_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Generador;
        private System.Windows.Forms.Button Retorno;
        private System.Windows.Forms.TextBox ubicacion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Seleccionar;
    }
}