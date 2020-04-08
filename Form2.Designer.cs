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
            this.TablaFirstLast = new System.Windows.Forms.DataGridView();
            this.Simbolo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.First = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Last = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nulable = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.TablaFirstLast)).BeginInit();
            this.SuspendLayout();
            // 
            // TablaFirstLast
            // 
            this.TablaFirstLast.BackgroundColor = System.Drawing.SystemColors.Menu;
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
            // 
            // First
            // 
            this.First.HeaderText = "First";
            this.First.Name = "First";
            // 
            // Last
            // 
            this.Last.HeaderText = "Last";
            this.Last.Name = "Last";
            // 
            // Nulable
            // 
            this.Nulable.HeaderText = "Nulable";
            this.Nulable.Name = "Nulable";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(997, 679);
            this.Controls.Add(this.TablaFirstLast);
            this.Name = "Form2";
            this.Text = "Form2";
            ((System.ComponentModel.ISupportInitialize)(this.TablaFirstLast)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView TablaFirstLast;
        private System.Windows.Forms.DataGridViewTextBoxColumn Simbolo;
        private System.Windows.Forms.DataGridViewTextBoxColumn First;
        private System.Windows.Forms.DataGridViewTextBoxColumn Last;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nulable;
    }
}