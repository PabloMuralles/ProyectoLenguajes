using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Proyecto_Lenguajes.FirstLastsFollows;

namespace Proyecto_Lenguajes
{
    public partial class Form2 : Form
    {
        public Form2( )
        {
            InitializeComponent();
            LLenarTabla();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public void LLenarTabla()
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

            EstadosDg.DataSource = Tablas.Instance.Estado;
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
