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
            this.SuspendLayout();
            // 
            // Generador
            // 
            this.Generador.Location = new System.Drawing.Point(138, 213);
            this.Generador.Name = "Generador";
            this.Generador.Size = new System.Drawing.Size(75, 23);
            this.Generador.TabIndex = 0;
            this.Generador.Text = "Generar ";
            this.Generador.UseVisualStyleBackColor = true;
            this.Generador.Click += new System.EventHandler(this.Generador_Click);
            // 
            // Retorno
            // 
            this.Retorno.Location = new System.Drawing.Point(245, 307);
            this.Retorno.Name = "Retorno";
            this.Retorno.Size = new System.Drawing.Size(75, 23);
            this.Retorno.TabIndex = 1;
            this.Retorno.Text = "Regresar";
            this.Retorno.UseVisualStyleBackColor = true;
            this.Retorno.Click += new System.EventHandler(this.Retorno_Click);
            // 
            // GeneradorDeCodigo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 477);
            this.Controls.Add(this.Retorno);
            this.Controls.Add(this.Generador);
            this.Name = "GeneradorDeCodigo";
            this.Text = "GeneradorDeCodigo";
            this.Load += new System.EventHandler(this.GeneradorDeCodigo_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Generador;
        private System.Windows.Forms.Button Retorno;
    }
}