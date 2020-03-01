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

        private List<string> TextoManipular_EnLista = new List<string>();

        private List<string> TextoConEspacios = new List<string>();

        private List<string> SETS = new List<string>();
        public ManipulacionTexto(string Texto)
        {
            TextoManipular = Texto;
            DivicionTexto(Texto);
        }

        public void DivicionTexto(string TextoEvaluar)
        {
            // caracteres a quitar despues de quitar los caracteres no necesario
            char[] CaracteresDelimitadores = { '\t', '\r', ' ' };

            // dividir el texto por enters 
            string[] Texto_Separdo = TextoEvaluar.Split('\n');

            // quitar caracteres no necesario
            foreach (var item in Texto_Separdo)
            {
                string ItemSinCaracters = item.Trim(CaracteresDelimitadores);
                TextoConEspacios.Add(ItemSinCaracters);
            }
            // quitar los espacion que quedaron en las lineas
            foreach (var item in TextoConEspacios)
            {
                if (item == "")
                {

                }
                else
                {
                    TextoManipular_EnLista.Add(item);
                }

            }
           
            // validar que  en la exprecion regular este definido el apartado de token, sets y actions
            if (TextoManipular_EnLista.Contains("SETS") && TextoManipular_EnLista.Contains("TOKENS") && TextoManipular_EnLista.Contains("ACTIONS")) 
            {
                // ver en que posicion esta la especificacion de cada seccion
                int PosicionSets = TextoManipular_EnLista.FindIndex(x => x.Equals("SETS"));
                int PosicionTokens = TextoManipular_EnLista.FindIndex(x => x.Equals("TOKENS"));
                int PosicionActions = TextoManipular_EnLista.FindIndex(x => x.Equals("ACTIONS"));

                // comprobar que cada seccion no venga vacia
                for (int i = 0; i < TextoManipular_EnLista.Count; i++)
                {
                    if (i==PosicionSets && TextoManipular_EnLista[i+1] == "TOKENS")
                    {
                        MessageBox.Show("Los SETS vinen basicios");
                    }
                   
                    if (i == PosicionTokens && TextoManipular_EnLista[i + 1] == "ACTIONS")
                    {
                        MessageBox.Show("Los TOKENS vinen basicios");
                    }
                   
                    if (i == PosicionActions && TextoManipular_EnLista[i + 1] == "RESERVADAS()" && TextoManipular_EnLista[i + 2] == "{" && TextoManipular_EnLista[i + 2] == "}")
                    {
                        MessageBox.Show("Los ACTIONS vinen basicios");
                    }

                }
                foreach (var item in TextoManipular_EnLista)
                {

                }

                  


            }
            // opcion de sino viene sets
            else if (TextoManipular_EnLista.Contains("TOKENS") && TextoManipular_EnLista.Contains("ACTIONS"))
            {
                // ver en que posicion esta la especificacion de cada seccion 
                int PosicionTokens = TextoManipular_EnLista.FindIndex(x => x.Equals("TOKENS"));
                int PosicionActions = TextoManipular_EnLista.FindIndex(x => x.Equals("ACTIONS"));

                // comprobar que cada seccion no venga vacia
                for (int i = 0; i < TextoManipular_EnLista.Count; i++)
                {
                    if (i == PosicionTokens && TextoManipular_EnLista[i + 1] == "ACTIONS")
                    {
                        MessageBox.Show("Los TOKENS vinen basicios");
                    }

                    if (i == PosicionActions && TextoManipular_EnLista[i + 1] == "RESERVADAS()" && TextoManipular_EnLista[i + 2] == "{" && TextoManipular_EnLista[i + 2] == "}")
                    {
                        MessageBox.Show("Los ACTIONS vinen basicios");
                    }

                }
            }
            else
            {
                MessageBox.Show("El archivo no trae difinada la secicon de tokens o de acction correctmente, que no no exista enter despues de cada sección");
            }


        }

    }
}
