﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_Lenguajes
{
    public partial class GeneradorDeCodigo : Form
    {
        public GeneradorDeCodigo()
        {
            InitializeComponent();
        }

        private void GeneradorDeCodigo_Load(object sender, EventArgs e)
        {

        }

        private void Generador_Click(object sender, EventArgs e)
        {
            FirstLastsFollows.Tablas.Instance.GenerarCodigo();
        }

        private void Retorno_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            this.Close();
            form1.Show();
        }
    }
}