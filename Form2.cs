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
        /// <summary>
        /// variables globales de la clase
        /// </summary>
        private static  Bitmap bitmap = new Bitmap(9999, 9999);
        private  Graphics graphics = Graphics.FromImage(bitmap);

       
        /// <summary>
        /// se uso el metodo ya creado para llamar a los distintos metos y crear las tablas 
        /// </summary>
        public Form2()
        {
            InitializeComponent();
            LLenarTablaFirst();
            LlenarTablaEstados();
            DibujarArbol(Tablas.Instance.Arbol, this.Width * 6, 80, 2000);
            pictureBox1.Image = bitmap;
        }

    
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Metodo para dibujar el arbol creado con la expresion regular de tokens
        /// </summary>
        /// <param name="arbol"> recibe el arbol para poder dibujarlo</param>
        /// <param name="posX">la posicion en x para poder dibujar el nodo</param>
        /// <param name="posY">la posicion en y para poder dibujar el nodo</param>
        /// <param name="separacion"> la cantidad de separacion entre cada uno</param>
        private void DibujarArbol(Nodo arbol, int posX, int posY, int separacion)
        {
            if (arbol != null)
            {
                graphics.FillEllipse(new SolidBrush(Color.GreenYellow), new RectangleF(posX, posY, 50, 25));
                graphics.DrawString(arbol.Data, new Font("Arial", 8, FontStyle.Regular), new SolidBrush(Color.Black), posX + 5, posY + 5);
                 
                if (arbol.Derecho != null)
                {
                    separacion = separacion + 20;
                    graphics.DrawLine(new Pen(Color.BlueViolet), posX + 15, posY + 15, posX + separacion + 15, posY + 65);
                    DibujarArbol(arbol.Derecho, (posX + separacion), (posY + 50), (separacion/2));
                     
                     
                }

                if (arbol.Izquierdo != null)
                {

                    separacion = separacion + 20;
                    graphics.DrawLine(new Pen(Color.BlueViolet), posX + 15, posY + 15, posX - separacion + 15, posY + 65);
                    DibujarArbol(arbol.Izquierdo, (posX - separacion), (posY + 50), (separacion / 2));
                    
                     
                }
            }
        }


        /// <summary>
        /// Llena la tabla de los estados por medio de un data table que despues se inserta en el data grid por medio de las propiedades publicas de la clase tabla 
        /// </summary>
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
         
        /// <summary>
        /// Metodo que crea la tabla de los first las y follows por medio de las propiedades publicas de la clase tabla e insertar 
        /// los datos en un data grid 
        /// </summary>
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
 
 

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Boton para poder regresar a la pagina de cargar archivo 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1 PantallaCarga = new Form1();
            PantallaCarga.Show();
             
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Generador_Click(object sender, EventArgs e)
        {
            GeneradorDeCodigo Mostrar = new GeneradorDeCodigo();
            this.Close();
            Mostrar.Show();
             
        }
    }
}
