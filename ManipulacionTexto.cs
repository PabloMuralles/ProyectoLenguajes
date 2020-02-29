using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Lenguajes
{
    class ManipulacionTexto
    {
        private string TextoManipular = string.Empty;

        private Queue<string> TextoManipular_EnPila = new Queue<string>();

        private Queue<string> SETS = new Queue<string>();
        public ManipulacionTexto(string Texto)
        {
            TextoManipular = Texto;
            DivicionTexto(Texto);
        }

        public void DivicionTexto(string TextoEvaluar)
        {

            char[] CaracteresDelimitadores = {'\t', '\r', ' ' };
            

            string[] Texto_Separdo = TextoEvaluar.Split('\n');
            foreach (var item in Texto_Separdo)
            {
                string ItemSinCaracters = item.Trim(CaracteresDelimitadores);
                TextoManipular_EnPila.Enqueue(ItemSinCaracters);
            }
           
            // validar que  en la exprecion regular este definido el apartado de token 
            if ((TextoManipular_EnPila.Contains("SETS") && TextoManipular_EnPila.Contains("TOKENS") && TextoManipular_EnPila.Contains("ACTIONS")) ||
                (TextoManipular_EnPila.Contains("TOKENS") && TextoManipular_EnPila.Contains("ACTIONS")))
            {


            }
            else
            {
                MessageBox.Show("El archivo no trae difinada la secicon de tokens o de acction");
            }


        }

    }
}
