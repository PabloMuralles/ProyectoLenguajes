using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Proyecto_Lenguajes.FirstLastsFollows;
 

namespace Proyecto_Lenguajes
{
    public partial class Form2 : Form
    {
    
        private static  Bitmap bitmap = new Bitmap(9999, 9999);
        private  Graphics graphics = Graphics.FromImage(bitmap);
        public Form2()
        {
            InitializeComponent();
            LLenarTablaFirst();
            LlenarTablaEstados();
             

             
            DibujarArbol(Tablas.Instance.Arbol, this.Width/2, 100, 250);
            picturebox.Image = bitmap;
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void DibujarArbol(Nodo arbol, int posX, int posY, int separacion)
        {
            if (arbol != null)
            {
                graphics.FillEllipse(new SolidBrush(Color.Blue), new RectangleF(posX, posY, 50, 25));
                graphics.DrawString(arbol.Data, new Font("Arial", 8, FontStyle.Regular), new SolidBrush(Color.Green), posX + 5, posY + 5);

           

                if (arbol.Derecho != null)
                {
                    
                    graphics.DrawLine(new Pen(Color.Black), posX + 15, posY + 15, posX + separacion + 15, posY + 65);
                    DibujarArbol(arbol.Derecho, (posX + separacion), (posY + 50), separacion/2);
                }

                if (arbol.Izquierdo != null)
                {
                    graphics.DrawLine(new Pen(Color.Black), posX + 15, posY + 15, posX - separacion + 15, posY + 65);
                    DibujarArbol(arbol.Izquierdo, (posX - separacion), (posY + 50), separacion/2);
                }
            }
        }



        private void LlenarTablaEstados()
        {
            textBox1.Text = Tablas.Instance.Expresion_;

            var Tabla = new DataTable();

            var diccestados = Tablas.Instance.EstadosT;
             
            var primerelemnto = diccestados.First();

            Tabla.Columns.Add("Estados");

            foreach (var item in primerelemnto.Value)
            {
                Tabla.Columns.Add($"{item.Key}");

            }
            var columnas = Tabla.Columns.Count;
            var ContadorColumnas = 0;
            Tabla.Rows.Add( );
            var ContadorFilas = 0;

            foreach (var item in diccestados)
            {
                Tabla.Rows.Add();
                Tabla.Rows[ContadorFilas][ContadorColumnas] = string.Join(",", item.Key);
                ContadorColumnas++;
                foreach (var item2 in item.Value)
                {
                    if (item2.Value.Count != 0)
                    {
                        Tabla.Rows[ContadorFilas][ContadorColumnas] = string.Join(",", item2.Value);
                        ContadorColumnas++;
                    }
                    else
                    {
                        Tabla.Rows[ContadorFilas][ContadorColumnas] = "----";
                        ContadorColumnas++;
                    }
                     
                }
                ContadorFilas++;
                ContadorColumnas = 0;
            }

            EstadosDg.DataSource = Tabla;
        }
        private void LLenarTablaFirst()
        {
            var Lista = Tablas.Instance.RecorridoFirstLast;

            var Diccionario = Tablas.Instance.Follows;

            int Contador = 0;

            TablaFirstLast.Rows.Add(Lista.Count);

            foreach (var Nodo in Lista)
            {
                TablaFirstLast.Rows[Contador].Cells[0].Value = $"{Nodo.Data}";
                var First = string.Empty;
                foreach (var item in Nodo.First)
                {
                    First += item;
                    First += ",";
                }
                TablaFirstLast.Rows[Contador].Cells[1].Value = $"{First}";

                var Last = string.Empty;
                foreach (var item in Nodo.Last)
                {
                    Last += item;
                    Last += ",";
                }
                TablaFirstLast.Rows[Contador].Cells[2].Value = $"{Last}";
                TablaFirstLast.Rows[Contador].Cells[3].Value = $"{Nodo.Nulable}";
                Contador++;
            }

            TablaFollows.Rows.Add(Diccionario.Keys.Count);

            int Contador2 = 0;

            foreach (var valor in Diccionario)
            {
                TablaFollows.Rows[Contador2].Cells[0].Value = $"{valor.Key}";

                var Follows = string.Empty;
                foreach (var item in valor.Value)
                {
                    Follows += item;
                    Follows += ",";

                }
                TablaFollows.Rows[Contador2].Cells[1].Value = $"{Follows}";
                Contador2++;
            }


        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
