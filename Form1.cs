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
            ArbolExpreciones Arbol = new ArbolExpreciones();

             

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Cargar_Archivo_Click(object sender, EventArgs e)
        {
            // variable para poder abrir el dialog
            OpenFileDialog Abrir = new OpenFileDialog();

             // abre el explorador de archivos   
            if (Abrir.ShowDialog() == DialogResult.OK)
            {
                // da la direccion del archivo que se abrio
                var Direccion = Abrir.FileName;

                // da la extecion del archivo para poder validarlo que sea txt
                var Extencion = Path.GetExtension(Direccion);

                /*valido la extencion del archivo y si es txt lo leo para posteriomente 
                 * guardarlo y sino es un txt se muestra un messaje*/
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
