namespace Proyecto_Lenguajes
{
    partial class Form1
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
            this.Cargar_Archivo = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Cargar_Archivo
            // 
            this.Cargar_Archivo.Location = new System.Drawing.Point(160, 251);
            this.Cargar_Archivo.Name = "Cargar_Archivo";
            this.Cargar_Archivo.Size = new System.Drawing.Size(75, 23);
            this.Cargar_Archivo.TabIndex = 0;
            this.Cargar_Archivo.Text = "Cargar";
            this.Cargar_Archivo.UseVisualStyleBackColor = true;
            this.Cargar_Archivo.Click += new System.EventHandler(this.Cargar_Archivo_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 338);
            this.Controls.Add(this.Cargar_Archivo);
            this.Name = "Form1";
            this.Text = "Cargar Archivo";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Cargar_Archivo;
    }
}

