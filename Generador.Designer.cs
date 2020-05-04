namespace Proyecto_Lenguajes
{
    partial class Generador
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
            this.Generar = new System.Windows.Forms.Button();
            this.ubicacion = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Nombre = new System.Windows.Forms.TextBox();
            this.Direccion = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // Generar
            // 
            this.Generar.Location = new System.Drawing.Point(160, 185);
            this.Generar.Name = "Generar";
            this.Generar.Size = new System.Drawing.Size(75, 23);
            this.Generar.TabIndex = 0;
            this.Generar.Text = "Generar";
            this.Generar.UseVisualStyleBackColor = true;
            // 
            // ubicacion
            // 
            this.ubicacion.Location = new System.Drawing.Point(39, 185);
            this.ubicacion.Name = "ubicacion";
            this.ubicacion.Size = new System.Drawing.Size(75, 23);
            this.ubicacion.TabIndex = 1;
            this.ubicacion.Text = "Ubicación";
            this.ubicacion.UseVisualStyleBackColor = true;
            this.ubicacion.Click += new System.EventHandler(this.ubicacion_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 95);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Direccion";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(36, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Nombre";
            // 
            // Nombre
            // 
            this.Nombre.Location = new System.Drawing.Point(39, 49);
            this.Nombre.Name = "Nombre";
            this.Nombre.Size = new System.Drawing.Size(196, 20);
            this.Nombre.TabIndex = 4;
            // 
            // Direccion
            // 
            this.Direccion.Location = new System.Drawing.Point(39, 121);
            this.Direccion.Name = "Direccion";
            this.Direccion.Size = new System.Drawing.Size(196, 20);
            this.Direccion.TabIndex = 5;
            // 
            // Generador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(283, 260);
            this.Controls.Add(this.Direccion);
            this.Controls.Add(this.Nombre);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ubicacion);
            this.Controls.Add(this.Generar);
            this.Name = "Generador";
            this.Text = "Generador";
            this.Load += new System.EventHandler(this.Generador_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Generar;
        private System.Windows.Forms.Button ubicacion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Nombre;
        private System.Windows.Forms.TextBox Direccion;
    }
}