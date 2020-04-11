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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.Cargar_Archivo = new System.Windows.Forms.Button();
            this.path = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.textomostrar = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Cargar_Archivo
            // 
            this.Cargar_Archivo.Location = new System.Drawing.Point(68, 303);
            this.Cargar_Archivo.Name = "Cargar_Archivo";
            this.Cargar_Archivo.Size = new System.Drawing.Size(75, 23);
            this.Cargar_Archivo.TabIndex = 0;
            this.Cargar_Archivo.Text = "Cargar";
            this.Cargar_Archivo.UseVisualStyleBackColor = true;
            this.Cargar_Archivo.Click += new System.EventHandler(this.Cargar_Archivo_Click);
            // 
            // path
            // 
            this.path.Location = new System.Drawing.Point(12, 49);
            this.path.Multiline = true;
            this.path.Name = "path";
            this.path.ReadOnly = true;
            this.path.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.path.Size = new System.Drawing.Size(360, 36);
            this.path.TabIndex = 1;
            this.path.WordWrap = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(216, 303);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Analizar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textomostrar
            // 
            this.textomostrar.Location = new System.Drawing.Point(12, 114);
            this.textomostrar.Multiline = true;
            this.textomostrar.Name = "textomostrar";
            this.textomostrar.ReadOnly = true;
            this.textomostrar.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textomostrar.Size = new System.Drawing.Size(360, 172);
            this.textomostrar.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Direción";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Texto";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(389, 338);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textomostrar);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.path);
            this.Controls.Add(this.Cargar_Archivo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Cargar Archivo";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Cargar_Archivo;
        private System.Windows.Forms.TextBox path;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textomostrar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

