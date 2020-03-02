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
        // lista para almacenar el texto que proviene del forms
        private List<string> TextoManipular_EnLista = new List<string>();
         
        private List<string> SETS = new List<string>();

        private List<string> TOKENS = new List<string>();

        private List<string> ACTIONS = new List<string>();

        private int PosicionSets = 0;

        private int PosicionTokens = 0;

        private int PosicionActions = 0;

        // contructor que resibe el texto del forms en forma de lista
        public ManipulacionTexto(List<string> TextoDeForms)
        {
            TextoManipular_EnLista = TextoDeForms;
            QuitarCaracteres();
            ConocerPocicionPartes();
        }

        public void QuitarCaracteres()
        {
            // caracteres a quitar despues de quitar los caracteres no necesario
            char[] CaracteresDelimitadores = { '\t', '\r', ' ' };
            // lista temporal para poder guardar las lineas sin espacios y tabs
            List<string> Temp_Quitar_Caracteres = new List<string>();
            // quitar caracteres no necesario
            foreach (var item in TextoManipular_EnLista)
            {
                
                string ItemSinCaracters = item.Trim(CaracteresDelimitadores);
                Temp_Quitar_Caracteres.Add(ItemSinCaracters);
            }
            TextoManipular_EnLista.Clear();
            TextoManipular_EnLista = Temp_Quitar_Caracteres;


        }
       
        
        public void ConocerPocicionPartes()
        {
            //ver en que posicion esta la especificacion de cada seccion
            PosicionSets = TextoManipular_EnLista.FindIndex(x => x.Equals("SETS"));
            PosicionTokens = TextoManipular_EnLista.FindIndex(x => x.Equals("TOKENS"));
            PosicionActions = TextoManipular_EnLista.FindIndex(x => x.Equals("ACTIONS"));

        }










        #region codigo que puede servir
        //public void DivicionTexto(string TextoEvaluar)
        //{
        //    // caracteres a quitar despues de quitar los caracteres no necesario
        //    char[] CaracteresDelimitadores = { '\t', '\r', ' ' };

        //    // dividir el texto por enters 
        //    string[] Texto_Separdo = TextoEvaluar.Split('\n');

        //    // quitar caracteres no necesario
        //    foreach (var item in Texto_Separdo)
        //    {
        //        string ItemSinCaracters = item.Trim(CaracteresDelimitadores);
        //        TextoConEspacios.Add(ItemSinCaracters);
        //    }
        //    // quitar los espacion que quedaron en las lineas
        //    foreach (var item in TextoConEspacios)
        //    {
        //        if (item == "")
        //        {

        //        }
        //        else
        //        {
        //            TextoManipular_EnLista.Add(item);
        //        }

        //    }

        //    // validar que  en la exprecion regular este definido el apartado de token, sets y actions
        //    if (TextoManipular_EnLista.Contains("SETS") && TextoManipular_EnLista.Contains("TOKENS") && TextoManipular_EnLista.Contains("ACTIONS")) 
        //    {
        //        // ver en que posicion esta la especificacion de cada seccion
        //        int PosicionSets = TextoManipular_EnLista.FindIndex(x => x.Equals("SETS"));
        //        int PosicionTokens = TextoManipular_EnLista.FindIndex(x => x.Equals("TOKENS"));
        //        int PosicionActions = TextoManipular_EnLista.FindIndex(x => x.Equals("ACTIONS"));

        //        // comprobar que cada seccion no venga vacia
        //        for (int i = 0; i < TextoManipular_EnLista.Count; i++)
        //        {
        //            if (i==PosicionSets && TextoManipular_EnLista[i+1] == "TOKENS")
        //            {
        //                MessageBox.Show("Los SETS vinen basicios");
        //            }

        //            if (i == PosicionTokens && TextoManipular_EnLista[i + 1] == "ACTIONS")
        //            {
        //                MessageBox.Show("Los TOKENS vinen basicios");
        //            }

        //            if (i == PosicionActions && TextoManipular_EnLista[i + 1] == "RESERVADAS()" && TextoManipular_EnLista[i + 2] == "{" && TextoManipular_EnLista[i + 2] == "}")
        //            {
        //                MessageBox.Show("Los ACTIONS vinen basicios");
        //            }

        //        }





        //    }
        //    // opcion de sino viene sets
        //    else if (TextoManipular_EnLista.Contains("TOKENS") && TextoManipular_EnLista.Contains("ACTIONS"))
        //    {
        //        // ver en que posicion esta la especificacion de cada seccion 
        //        int PosicionTokens = TextoManipular_EnLista.FindIndex(x => x.Equals("TOKENS"));
        //        int PosicionActions = TextoManipular_EnLista.FindIndex(x => x.Equals("ACTIONS"));

        //        // comprobar que cada seccion no venga vacia
        //        for (int i = 0; i < TextoManipular_EnLista.Count; i++)
        //        {
        //            if (i == PosicionTokens && TextoManipular_EnLista[i + 1] == "ACTIONS")
        //            {
        //                MessageBox.Show("Los TOKENS vinen basicios");
        //            }

        //            if (i == PosicionActions && TextoManipular_EnLista[i + 1] == "RESERVADAS()" && TextoManipular_EnLista[i + 2] == "{" && TextoManipular_EnLista[i + 2] == "}")
        //            {
        //                MessageBox.Show("Los ACTIONS vinen basicios");
        //            }

        //        }
        //    }
        //    else
        //    {
        //        MessageBox.Show("El archivo no trae difinada la secicon de tokens o de acction correctmente, que no no exista enter despues de cada sección");
        //    }


        //}
        #endregion

    }
}
