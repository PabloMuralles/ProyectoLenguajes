using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Data;


namespace Proyecto_Lenguajes.FirstLastsFollows
{
    class Tablas
    {
        /// <summary>
        /// metodo para poder implementar singleton
        /// </summary>
        private static Tablas _instance = null;
        public static Tablas Instance
        {
            get
            {
                if (_instance == null) _instance = new Tablas();
                return _instance;
            }
        }

        public Nodo Arbol; 

        /// <summary>
        /// esta lista se utiliza para poder crear la tabla de los firts y last en el forms
        /// </summary>
        public List<Nodo> RecorridoFirstLast = new List<Nodo>();

        public string Expresion_ = string.Empty;

        /// <summary>
        /// Metodo simila al constructor 
        /// </summary>
        /// <param name="Raiz"> recibe el arbol generado pr la clase arbilfirstlast para realzar los calculos</param>
        /// <param name="Terminales_">Recibe los terminales en una lista para realizar calculos</param>
        /// <param name="Expresion">recibe la expresion regular para poder mostrarla en el forms2</param>
        public void Proceso(Nodo Raiz,List<string> Terminales_,string Expresion)
        {
            Arbol = Raiz;
            
            RecorridoFirstLast.Clear();
            Follows.Clear();
            EstadosT.Clear();
            TerminalesArbol.Clear();
 
            RecorridoPostorden(Arbol);

            Estados NuevoEstados = new Estados(Follows, Terminales_, Arbol, TerminalesArbol);

            EstadosT = NuevoEstados.CrearEstados(Arbol);
            Expresion_ = Expresion;
            ContadorTerminales = 1;

            Form2 Form2 = new Form2();
            Form2.Show();

            var CaracterAceptacion = CalcularCaracterAceptacion(Follows);

            GeneradorPrograma.Codigo Generador = new GeneradorPrograma.Codigo(EstadosT,Terminales_,CaracterAceptacion);

        }

        private int CalcularCaracterAceptacion(Dictionary<int, List<int>> Follows)
        { 
            foreach (var item in Follows)
            {
                if (item.Value.Count == 0)
                {
                    return item.Key;
                }

            }

            return default;
 
        }

        public Dictionary<List<int>, Dictionary<string, List<int>>>  EstadosT = new Dictionary<List<int>, Dictionary<string, List<int>>>();

        public Dictionary<int, List<int>> Follows = new Dictionary<int, List<int>>();
         
        private List<string> TerminalesArbol = new List<string>();
         
        int ContadorTerminales = 1;

        /// <summary>
        /// Metodo de recorridopost orden donde se calculan los first, last y follow
        /// </summary>
        /// <param name="raiz">recibe el arbol para poder realizar los calculos</param>
        private void RecorridoPostorden(Nodo raiz)
        {
            if (raiz != null)
            {
                RecorridoPostorden(raiz.Izquierdo);
                RecorridoPostorden(raiz.Derecho);
                RecorridoFirstLast.Add(raiz);

                if (raiz.Eshoja == true)
                {
                    raiz.Numero = ContadorTerminales;
                    raiz.First.Add(ContadorTerminales);
                    raiz.Last.Add(ContadorTerminales);
                    // inicializo el diccionario con los simbolos de los terminales y las listas las inicializo
                    Follows.Add(ContadorTerminales, new List<int>());
                    TerminalesArbol.Add(raiz.Data);
                    ContadorTerminales++;
                }
                else if (raiz.Data == "*")
                {
                    raiz.Nulable = true;
                    raiz.First = raiz.Izquierdo.First;
                    raiz.Last = raiz.Izquierdo.Last;
                    foreach (var LastC1 in raiz.Izquierdo.Last)
                    {
                        foreach (var firstC1 in raiz.Izquierdo.First)
                        {
                            Follows.TryGetValue(LastC1, out var followexistentes);

                            if (!followexistentes.Contains(firstC1))
                            {
                                Follows.FirstOrDefault(x => x.Key == LastC1).Value.Add(firstC1);
                            }
                        }

                    }
                }
                else if (raiz.Data == "+")
                {
                    raiz.First = raiz.Izquierdo.First;
                    raiz.Last = raiz.Izquierdo.Last;
                    foreach (var LastC1 in raiz.Izquierdo.Last)
                    {
                        foreach (var firstC1 in raiz.Izquierdo.First)
                        {
                            Follows.TryGetValue(LastC1, out var followsexistentes);

                            if (!followsexistentes.Contains(firstC1))
                            {
                                Follows.FirstOrDefault(x => x.Key == LastC1).Value.Add(firstC1);

                            }
                        }

                    }
                }
                else if (raiz.Data == "?")
                {
                    raiz.Nulable = true;
                    raiz.First = raiz.Izquierdo.First;
                    raiz.Last = raiz.Izquierdo.Last;
                }
                else if (raiz.Data == "|")
                {
                    if (raiz.Izquierdo.Nulable == true || raiz.Derecho.Nulable == true)
                    {
                        raiz.Nulable = true;
                    }
                    foreach (var item in raiz.Izquierdo.First)
                    {
                        raiz.First.Add(item);
                    }
                    foreach (var item in raiz.Derecho.First)
                    {
                        raiz.First.Add(item);
                    }

                    foreach (var item in raiz.Izquierdo.Last)
                    {
                        raiz.Last.Add(item);
                    }
                    foreach (var item in raiz.Derecho.Last)
                    {
                        raiz.Last.Add(item);
                    }

                }
                else if (raiz.Data == "·")
                {
                    if (raiz.Izquierdo.Nulable == true && raiz.Derecho.Nulable == true)
                    {
                        raiz.Nulable = true;
                    }
                    if (raiz.Izquierdo.Nulable == true)
                    {
                        foreach (var item in raiz.Izquierdo.First)
                        {
                            raiz.First.Add(item);
                        }
                        foreach (var item in raiz.Derecho.First)
                        {
                            raiz.First.Add(item);
                        }
                    }
                    else
                    {
                        foreach (var item in raiz.Izquierdo.First)
                        {
                            raiz.First.Add(item);
                        }
                    }
                    if (raiz.Derecho.Nulable == true)
                    {
                        foreach (var item in raiz.Izquierdo.Last)
                        {
                            raiz.Last.Add(item);
                        }
                        foreach (var item in raiz.Derecho.Last)
                        {
                            raiz.Last.Add(item);
                        }
                    }
                    else
                    {
                        foreach (var item in raiz.Derecho.Last)
                        {
                            raiz.Last.Add(item);
                        }
                    }
                    foreach (var LastC1 in raiz.Izquierdo.Last)
                    {
                        foreach (var firstC2 in raiz.Derecho.First)
                        {
                            
                            Follows.TryGetValue(LastC1 , out var valor);
                            // se valido que si el count es 0 no da error al verificar si lo contine
                            if (!valor.Contains(firstC2))
                            {
                                Follows.FirstOrDefault(x => x.Key == LastC1).Value.Add(firstC2);

                            }
                             
                        }

                    }

                }
            }
        }

 
        
     
 
 
    }
}
