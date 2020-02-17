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
            this.boton_cargar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // boton_cargar
            // 
            this.boton_cargar.Location = new System.Drawing.Point(146, 258);
            this.boton_cargar.Name = "boton_cargar";
            this.boton_cargar.Size = new System.Drawing.Size(75, 23);
            this.boton_cargar.TabIndex = 0;
            this.boton_cargar.Text = "Cargar ";
            this.boton_cargar.UseVisualStyleBackColor = true;
            this.boton_cargar.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 338);
            this.Controls.Add(this.boton_cargar);
            this.Name = "Form1";
            this.Text = "Cargar Archivo";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button boton_cargar;
    }
}

