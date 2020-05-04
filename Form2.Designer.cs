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
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.TablaFirstLast)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TablaFollows)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EstadosDg)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
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
            this.TablaFirstLast.Location = new System.Drawing.Point(12, 425);
            this.TablaFirstLast.Name = "TablaFirstLast";
            this.TablaFirstLast.Size = new System.Drawing.Size(397, 193);
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
            this.TablaFollows.Location = new System.Drawing.Point(415, 425);
            this.TablaFollows.Name = "TablaFollows";
            this.TablaFollows.Size = new System.Drawing.Size(200, 193);
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
            this.EstadosDg.Location = new System.Drawing.Point(618, 425);
            this.EstadosDg.Name = "EstadosDg";
            this.EstadosDg.Size = new System.Drawing.Size(350, 193);
            this.EstadosDg.TabIndex = 2;
            this.EstadosDg.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick_1);
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Gadugi", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(168, 12);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.textBox1.Size = new System.Drawing.Size(803, 50);
            this.textBox1.TabIndex = 10;
            this.textBox1.WordWrap = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(28, 402);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "First y Last:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(411, 402);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 20);
            this.label6.TabIndex = 12;
            this.label6.Text = "Follows:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(621, 402);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(72, 20);
            this.label7.TabIndex = 13;
            this.label7.Text = "Estados:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(28, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 20);
            this.label2.TabIndex = 14;
            this.label2.Text = "Árbol:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(143, 20);
            this.label3.TabIndex = 15;
            this.label3.Text = "Expresión Regular:";
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(12, 75);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(959, 324);
            this.panel1.TabIndex = 16;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(3, 13);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(946, 296);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click_1);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(22, 624);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 17;
            this.button1.Text = "Atras";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(841, 624);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(111, 23);
            this.button2.TabIndex = 18;
            this.button2.Text = "Generar Programa";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(982, 650);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.EstadosDg);
            this.Controls.Add(this.TablaFollows);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TablaFirstLast);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form2";
            this.Text = "Tablas";
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TablaFirstLast)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TablaFollows)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EstadosDg)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}