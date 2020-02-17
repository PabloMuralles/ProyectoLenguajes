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
        string Carpeta = Application.ExecutablePath + @"\Contenedor";
        string Archivo = @"\ArchivoTexto.txt";
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog Abrir = new OpenFileDialog();


            if (Abrir.ShowDialog()==DialogResult.OK)
            {
                string direccion = Abrir.FileName;
                Process process = new Process();
                process.StartInfo.FileName = direccion;
                process.Start();

            }



            
        }
    }
}
