using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

       
        public Dictionary<string, string> DiccionarioSets = new Dictionary<string, string>();
        public List<string> IdsSets = new List<string>();
        public Dictionary<int, string> DiccionarioTokensReservadas = new Dictionary<int, string>();
        public Dictionary<string, List<string>> DiccionarioSetsConsusListas = new Dictionary<string, List<string>>();

        public List<string> TokensExpresionesRegulares = new List<string>();
      

        private List<string> Terminales = new List<string>();

        public List<string> TokensReservada = new List<string>();
        public void GuardarInformacion(List<string> sets, List<string> tokens, List<string> actions)
        { 
            IdsSets.Clear();
            DiccionarioSets.Clear();
            DiccionarioTokensReservadas.Clear();
            DiccionarioSetsConsusListas.Clear();
           

            ObtenerDiccionarioSets(sets);
            ObtenerDiccionarioListaSets();
            ListaLexemas(tokens, actions);
            ObtenerLista();
 
        }
        

        // encontrar para que sirbe este metodo
        public void ObtenerTerminales(List<string> Terminales)
        { 
            this.Terminales.AddRange(Terminales);
        }
        /// <summary>
        /// Metodo para obtener una lista donde esten las reservada y los tokens pero unicamente aquellos que no sean expresiones regulares
        /// </summary>
        private void ObtenerLista()
        {
            TokensReservada.Clear();
            foreach (var Caracteres in DiccionarioTokensReservadas)
            {
                var Encontrado = IdsSets.Find(y => Caracteres.Value.Contains(y));
                if (Encontrado == null )
                {
                    var NuevoElemento = Caracteres.Value;
                    var ElementoSinComillas = NuevoElemento.Replace("'", "");
                    TokensReservada.Add(ElementoSinComillas);

                }
          
            }

        }

        /// <summary>
        /// Se genera un diccionario con el id del set y su fefinicion
        /// </summary>
        /// <param name="sets_">Recibe una lista con los sets</param>
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

        /// <summary>
        /// Metodo para obtener un diccionario con los sets y sus definiciones solo que la definiciones estaran con sus lista de cuales valores puede tener
        /// </summary>
        
        private void ObtenerDiccionarioListaSets()
        {
            foreach (var set in DiccionarioSets)
            {
                var ListaDefinicion = new List<string>();
                var DefinicionPorPartes = set.Value.Split('|');

                foreach (var Rango in DefinicionPorPartes)
                {
                    if (Rango.Contains("~"))
                    {
                        var Rango2 = Rango.Split('~');

                        var Representacion1 = Encoding.ASCII.GetBytes(Rango2[0]);
                        var Representacion2 = Encoding.ASCII.GetBytes(Rango2[1]);

                        if (Convert.ToInt32(Representacion1[0]) > Convert.ToInt32(Representacion2[0]))
                        {
                            var Fin = Convert.ToInt32(Representacion2[0]);
                            var Comienzo = Convert.ToInt32(Representacion1[0]);
                            for (int i = Comienzo; i > Fin; i--)
                            {
                                ListaDefinicion.Add(Convert.ToString(Convert.ToChar(i)));
                            }
                        }
                        else
                        {
                            var Fin = Convert.ToInt32(Representacion2[0]);
                            var Comienzo = Convert.ToInt32(Representacion1[0]);
                            for (int i = Comienzo; i < Fin; i++)
                            {
                                ListaDefinicion.Add(Convert.ToString(Convert.ToChar(i)));
                            }
                        }
                    }
                    else
                    {
                        ListaDefinicion.Add(Rango);
                    }
                }

                DiccionarioSetsConsusListas.Add(set.Key, ListaDefinicion);
                 
            } 
        }

        /// <summary>
        /// Se obtiene una lista con los token y las reservadas 
        /// </summary>
        /// <param name="tokens">Lista donde estan los tokens</param>
        /// <param name="actions">Lista donde estan las actions</param>
        private void ListaLexemas(List<string> tokens, List<string> actions)
        {
            Terminales.Clear();
            try
            {
                foreach (var token in tokens)
                {
                    var id = string.Empty;
                    var Definicion = string.Empty;
                    var NuevoToken = token.Replace("TOKEN", "");
                    var TomarCaracteres = false;
                    foreach (var caracter in NuevoToken)
                    {


                        var NuvoCaracter = Convert.ToString(caracter);


                        if (NuvoCaracter != "=" && TomarCaracteres == false)
                        {
                            id += NuvoCaracter;
                        }
                        else if (NuvoCaracter == "=" && TomarCaracteres == false)
                        {
                            TomarCaracteres = true;

                        }
                        else if (TomarCaracteres == true)
                        {
                            Definicion += NuvoCaracter;
                        }

                    }
                    if (Definicion.Contains("'"))
                    {
                        var DefinicionArreglo = Definicion.ToCharArray();
                        for (int i = 0; i < DefinicionArreglo.Length; i++)
                        {
                            if (DefinicionArreglo[i] == '\'')
                            {
                                DefinicionArreglo[i] = ' ';
                                DefinicionArreglo[i + 2] = ' ';
                                i = i + 2;

                            }
                        }
                        Definicion = string.Empty;
                        for (int i = 0; i < DefinicionArreglo.Length; i++)
                        {
                            Definicion += DefinicionArreglo[i];

                        }
                     

                    }


                    DiccionarioTokensReservadas.Add(Convert.ToInt32(id), Convert.ToString(Definicion));
                }

                foreach (var action in actions)
                {
                    var NewAction = Convert.ToString(action);
                    var id = string.Empty;
                    var Definicion = string.Empty;
                    var TomarCaracteres = false;

                    foreach (var Caracter in NewAction)
                    {
                        var NuvoCaracter = Convert.ToString(Caracter);


                        if (NuvoCaracter != "=" && TomarCaracteres == false)
                        {
                            id += NuvoCaracter;
                        }
                        else if (NuvoCaracter == "=")
                        {
                            TomarCaracteres = true;

                        }
                        else if (TomarCaracteres == true)
                        {
                            Definicion += NuvoCaracter;
                        }

                    }
                    Definicion = Definicion.TrimStart('\'');
                    Definicion = Definicion.TrimEnd('\'');
                    DiccionarioTokensReservadas.Add(Convert.ToInt32(id), Convert.ToString(Definicion));
                    Terminales.Add(Definicion);
                }


            }
            catch (Exception)
            {
                MessageBox.Show("Existe tokens o actions con el mismo id");
            }
        }    

    }
}
