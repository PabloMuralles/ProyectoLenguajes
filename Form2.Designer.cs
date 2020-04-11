namespace Proyecto_Lenguajes
{
    partial class Form2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.TablaFirstLast = new System.Windows.Forms.DataGridView();
            this.Simbolo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.First = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Last = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nulable = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TablaFollows = new System.Windows.Forms.DataGridView();
            this.Simbolo1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Follow = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EstadosDg = new System.Windows.Forms.DataGridView();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.panel = new System.Windows.Forms.Panel();
            this.picturebox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.TablaFirstLast)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TablaFollows)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EstadosDg)).BeginInit();
            this.panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picturebox)).BeginInit();
            this.SuspendLayout();
            // 
            // TablaFirstLast
            // 
            this.TablaFirstLast.BackgroundColor = System.Drawing.Color.White;
            this.TablaFirstLast.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TablaFirstLast.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Simbolo,
            this.First,
            this.Last,
            this.Nulable});
            this.TablaFirstLast.Location = new System.Drawing.Point(12, 459);
            this.TablaFirstLast.Name = "TablaFirstLast";
            this.TablaFirstLast.Size = new System.Drawing.Size(445, 208);
            this.TablaFirstLast.TabIndex = 0;
            this.TablaFirstLast.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // Simbolo
            // 
            this.Simbolo.HeaderText = "Simbolo";
            this.Simbolo.Name = "Simbolo";
            this.Simbolo.ReadOnly = true;
            // 
            // First
            // 
            this.First.HeaderText = "First";
            this.First.Name = "First";
            this.First.ReadOnly = true;
            // 
            // Last
            // 
            this.Last.HeaderText = "Last";
            this.Last.Name = "Last";
            this.Last.ReadOnly = true;
            // 
            // Nulable
            // 
            this.Nulable.HeaderText = "Nulable";
            this.Nulable.Name = "Nulable";
            this.Nulable.ReadOnly = true;
            // 
            // TablaFollows
            // 
            this.TablaFollows.BackgroundColor = System.Drawing.SystemColors.Menu;
            this.TablaFollows.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TablaFollows.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Simbolo1,
            this.Follow});
            this.TablaFollows.Location = new System.Drawing.Point(463, 459);
            this.TablaFollows.Name = "TablaFollows";
            this.TablaFollows.Size = new System.Drawing.Size(240, 208);
            this.TablaFollows.TabIndex = 1;
            // 
            // Simbolo1
            // 
            this.Simbolo1.HeaderText = "Simbolo";
            this.Simbolo1.Name = "Simbolo1";
            this.Simbolo1.ReadOnly = true;
            // 
            // Follow
            // 
            this.Follow.HeaderText = "Follow";
            this.Follow.Name = "Follow";
            this.Follow.ReadOnly = true;
            // 
            // EstadosDg
            // 
            this.EstadosDg.BackgroundColor = System.Drawing.Color.White;
            this.EstadosDg.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.EstadosDg.Location = new System.Drawing.Point(709, 459);
            this.EstadosDg.Name = "EstadosDg";
            this.EstadosDg.Size = new System.Drawing.Size(438, 208);
            this.EstadosDg.TabIndex = 2;
            this.EstadosDg.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick_1);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 12);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(1135, 20);
            this.textBox1.TabIndex = 0;
            // 
            // panel
            // 
            this.panel.AutoScroll = true;
            this.panel.Controls.Add(this.picturebox);
            this.panel.Location = new System.Drawing.Point(12, 38);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(1135, 415);
            this.panel.TabIndex = 13;
            // 
            // picturebox
            // 
            this.picturebox.Location = new System.Drawing.Point(3, 21);
            this.picturebox.Name = "picturebox";
            this.picturebox.Size = new System.Drawing.Size(1129, 374);
            this.picturebox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picturebox.TabIndex = 0;
            this.picturebox.TabStop = false;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1159, 679);
            this.Controls.Add(this.panel);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.EstadosDg);
            this.Controls.Add(this.TablaFollows);
            this.Controls.Add(this.TablaFirstLast);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form2";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TablaFirstLast)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TablaFollows)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EstadosDg)).EndInit();
            this.panel.ResumeLayout(false);
            this.panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picturebox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView TablaFirstLast;
        private System.Windows.Forms.DataGridView TablaFollows;
        private System.Windows.Forms.DataGridViewTextBoxColumn Simbolo1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Follow;
        private System.Windows.Forms.DataGridViewTextBoxColumn Simbolo;
        private System.Windows.Forms.DataGridViewTextBoxColumn First;
        private System.Windows.Forms.DataGridViewTextBoxColumn Last;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nulable;
        private System.Windows.Forms.DataGridView EstadosDg;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.PictureBox picturebox;
    }
}