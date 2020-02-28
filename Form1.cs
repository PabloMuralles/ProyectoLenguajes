using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace Proyecto_Lenguajes
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
             

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Cargar_Archivo_Click(object sender, EventArgs e)
        {
            OpenFileDialog Abrir = new OpenFileDialog();

                 
            if (Abrir.ShowDialog() == DialogResult.OK)
            {
                var Direccion = Abrir.FileName;
                var Extencion = Path.GetExtension(Direccion);
                if (Extencion == ".txt")
                {
                    StreamReader Archivo = new StreamReader(Direccion);
                    var Contenido = Archivo.ReadToEnd();

                }
                else
                { 
                    MessageBox.Show("Archivo Ingresado no es .txt");   
                }

            }                 
        }
    }
}
