using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Lenguajes.GeneradorPrograma
{
    class Data
    {
        /// <summary>
        /// metodo para poder implementar singleton
        /// </summary>
        private static Data _instance = null;
        public static Data Instance
        {
            get
            {
                if (_instance == null) _instance = new Data();
                return _instance;
            }
        }

        //List<string> sets = new List<string>();
        //List<string> tokens = new List<string>();
        //List<string> actions = new List<string>();
        public Dictionary<string, string> DiccionarioSets = new Dictionary<string, string>();
        public List<string> IdsSets = new List<string>();
        public Dictionary<int, string> DiccionarioTokensReservadas = new Dictionary<int, string>();

        public void GuardarInformacion(List<string> sets, List<string> tokens, List<string> actions)
        {
            //this.sets.Clear();
            //this.tokens.Clear();
            //this.actions.Clear();

            //this.sets = sets;
            //this.tokens = tokens;
            //this.actions = actions;
            IdsSets.Clear();
            DiccionarioSets.Clear();
            DiccionarioTokensReservadas.Clear();

            ObtenerDiccionarioSets(sets);
            //ListaLexemas(ti);
 
        }


        private void ObtenerDiccionarioSets( List<string> sets_)
        {
          
            foreach (var item in sets_)
            {
                var TomarDefinicion = false;
                var NuevoItem = item.Replace("'", "");
                var id = string.Empty;
                var Definicion = string.Empty;
              
                foreach (var  caracteres in NuevoItem)
                {
                    var CaracteresString = Convert.ToString(caracteres);
                     
                    if (CaracteresString != "=" && TomarDefinicion == false)
                    {
                        id += caracteres;
                    }
                    else if (CaracteresString == "=")
                    {

                        TomarDefinicion = true;
                    }
                    else
                    {
                        if (TomarDefinicion == true)
                        {
                            Definicion += CaracteresString;
                        } 
                    }
                }

                Definicion = Definicion.Replace("..", "~");
                Definicion = Definicion.Replace("+", "|");
                if (Definicion.Contains("CHR")) 
                {
                    Definicion = Definicion.Replace("CHR", "");
                    Definicion = Definicion.Replace("(", "");
                    Definicion = Definicion.Replace(")", "");
                }
                IdsSets.Add(id);
                DiccionarioSets.Add(id,Definicion);
                 
            }
 
             
        }

        private void ListaLexemas(List<string> tokens, List<string> actions)
        {
            //    foreach (var token in tokens)
            //    {
            //        var NuevoToken = token.Replace("TOKEN", "");
            //        foreach (var caracter in token)
            //        {
            //            var TomarCaracteres = false;
            //            var Definicion = string.Empty;
            //            var NuvoCaracter = Convert.ToString(caracter);
            //            var id = string.Empty;

            //            if (NuvoCaracter != "=")
            //            {
            //                id += NuvoCaracter;
            //            }
            //            else if(NuvoCaracter == "=")
            //            {
            //                TomarCaracteres = true;

            //            }
            //            else if (TomarCaracteres == true)
            //            {
            //                Definicion += NuvoCaracter;
            //            }

            //            DiccionarioTokensReservadas.Add(id, Definicion);
            //        }
            //    }

        }

    }
}
