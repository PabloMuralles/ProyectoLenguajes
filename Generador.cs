using System;
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
    public partial class Generador : Form
    {
        public Generador()
        {
            InitializeComponent();
        }

        private void ubicacion_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog Abrir = new FolderBrowserDialog();

            // abre el explorador de archivos   
            if (Abrir.ShowDialog() == DialogResult.OK && !string.IsNullOrWhiteSpace(Abrir.SelectedPath))
            {
                Direccion.Text = Abrir.SelectedPath;

            }  
        }

        private void Generador_Load(object sender, EventArgs e)
        {

        }
    }
}
