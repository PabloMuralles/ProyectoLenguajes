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

            ObtenerDiccionarioSets(sets);
 
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
                IdsSets.Add(id);
                DiccionarioSets.Add(id,Definicion);
                 
            }
 
             
        }


    }
}
