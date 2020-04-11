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
        private string Direccion = string.Empty;

        private bool ExtencionValidar = true;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// action del boton para cargar archivo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Cargar_Archivo_Click(object sender, EventArgs e)
        {
            // variable para poder abrir el dialog
            OpenFileDialog Abrir = new OpenFileDialog();

            // abre el explorador de archivos   
            if (Abrir.ShowDialog() == DialogResult.OK)
            {
                // da la direccion del archivo que se abrio
                Direccion = Abrir.FileName;

                // da la extecion del archivo para poder validarlo que sea txt
                var Extencion = Path.GetExtension(Direccion);

                /*valido la extencion del archivo y si es txt lo leo para posteriomente 
                 * guardarlo y sino es un txt se muestra un messaje*/

                try
                {
                    if (Extencion == ".txt")
                    {
                        var ArchivoEnseñar = new StreamReader(Direccion);
                        if (ArchivoEnseñar.BaseStream.Length != 0)
                        {
                            ExtencionValidar = true; 
                            path.Text = Direccion;
                            textomostrar.Text = ArchivoEnseñar.ReadToEnd();
                        }
                        else
                        {
                            throw new Exception("Archivo vacio");
                        }
             


                    }
                    else
                    {
                        ExtencionValidar = false;
                        throw new Exception("El documento ingesado no es un txt");
                    }

                }
                catch (Exception p)
                { 
                    MessageBox.Show(p.Message);
                }     
            }        
        }

        /// <summary>
        /// acction del boton para analizar texto
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            if (ExtencionValidar == true)
            { 
                var Archivo = new StreamReader(Direccion);
                var Archivo2 = new StreamReader(Direccion);

                Validacion.ManipulacionTexto TextoVerificadado = new Validacion.ManipulacionTexto(Archivo);
                FirstLastsFollows.GenerarExpresion LecturaTokens = new FirstLastsFollows.GenerarExpresion(Archivo2);
                this.Hide();
            }
        }
    }
}
