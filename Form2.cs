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

        }
    }
}
