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
        private static Tablas _instance = null;
        public static Tablas Instance
        {
            get
            {
                if (_instance == null) _instance = new Tablas();
                return _instance;
            }
        }

        private Nodo Arbol;

        public List<Nodo> RecorridoFirstLast = new List<Nodo>();
        public void Proceso(Nodo Raiz,List<string> Terminales)
        {
            Arbol = Raiz;
            RecorridoFirstLast.Clear();
            Follows.Clear();
            RecorridoPostorden(Arbol);
            DiccionarioTerminales(Terminales);
            CrearEstados();
            Form2 Form2 = new Form2();
            Form2.Show();

        }

        public Dictionary<int, List<int>> Follows = new Dictionary<int, List<int>>();

        private List<string> Terminales = new List<string>();
         
        int ContadorTerminales = 1;
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
                    Follows.Add(ContadorTerminales, new List<int>());
                    Terminales.Add(raiz.Data);
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
                            Follows.FirstOrDefault(x => x.Key == LastC1).Value.Add(firstC1);
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
                            Follows.FirstOrDefault(x => x.Key == LastC1).Value.Add(firstC1);
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
                            if (!valor.Contains(firstC2))
                            {
                                Follows.FirstOrDefault(x => x.Key == LastC1).Value.Add(firstC2);

                            }
                             
                        }

                    }

                }
            }
        }


        public Dictionary<List<int>, Dictionary<string, string> >TablaEstados = new Dictionary<List<int>, Dictionary<string, string>>();

        Dictionary<string, string> DiccionarioSimbolos  ;


        public void DiccionarioTerminales(List<string> terminales)
        {
            var dicc = new Dictionary<string, string>();
            foreach (var item in terminales)
            {
                dicc.Add(item, );
            }

            DiccionarioSimbolos = new Dictionary<string, string>(dicc);

        }

        public  Dictionary<string, string> CopiaDiccionario()
        {
            Dictionary<string, string> dicc = new Dictionary<string, string> (DiccionarioSimbolos);
            return dicc;
        }


        private Queue<List<int>> EstadosAprobar = new Queue<List<int>>();

        private List<List<int>> EstadosAprobarHistorial = new List<List<int>>();


        private Queue<List<int>> EstadosYaProbados = new Queue<List<int>>();
        public void CrearEstados( )
        {


            var diccModificar = new Dictionary<string, string>(CopiaDiccionario());
          
            EstadosAprobarHistorial.Add(Arbol.First);

            foreach (var ItemsEstadosInicial in Arbol.First)
            {
                var Simbolo = Terminales[ItemsEstadosInicial - 1];
                Follows.TryGetValue(ItemsEstadosInicial, out var follows);

                diccModificar.TryGetValue(Simbolo, out var Contenido);
                var NuevoContenido = new List<string>();
                foreach (var followsDelitem in follows)
                {
 
                        var ContenidoDividido = Contenido.Split(',');
                     
                        if (!ContenidoDividido.Contains(Convert.ToString(followsDelitem)) && !NuevoContenido.Contains(Convert.ToString(followsDelitem)))
                        {
                            NuevoContenido.Add(Convert.ToString(followsDelitem));
                         
                        }
 
                }
                var ContenidoAnterior = Contenido.Split(',');
                var Contenidolisto = string.Empty;
                foreach (var item in ContenidoAnterior)
                {
                    if (item !="")
                    {
                        Contenidolisto += Convert.ToString(item);
                        Contenidolisto += ",";
                    }
                     
                }
                foreach (var item in NuevoContenido)
                {
                    Contenidolisto += item;
                    Contenidolisto += ",";
                }
                diccModificar.FirstOrDefault(x=>x.Key==Simbolo).Value.

            }

            TablaEstados.TryGetValue(Arbol.First, out var DiccionarioValidarEstados);
             
            //foreach (var item in DiccionarioValidarEstados.Values)
            //{
            //    if (!Arbol.First.Equals(item) && item.Count != 0 )
            //    {
            //        EstadosAprobar.Enqueue(item);
            //        EstadosAprobarHistorial.Add(item);
            //    }
            //    EstadosAprobarHistorial.Add(item);
            //}

            while (EstadosAprobar.Count != 0)
            {

               
                //var Estado = EstadosAprobar.Dequeue();
                ////TablaEstados.Add(Estado, diccbase);
                //EstadosYaProbados.Enqueue(Estado);
                //EstadosAprobarHistorial.Add(Estado);

                //foreach (var item in Estado)
                //{

                //    var Simbolo = Terminales[item - 1];
                //    Follows.TryGetValue(item, out var follows);

                //    foreach (var item1 in follows)
                //    {
                //        TablaEstados.TryGetValue(Estado, out var Diccionario);
                //        Diccionario.TryGetValue(Simbolo, out var Contenido);
                //        if (!Contenido.Contains(item1))
                //        {
                //            TablaEstados.FirstOrDefault(x => x.Key == Estado).Value.FirstOrDefault(y => y.Key == Simbolo).Value.Add(item1);

                //        }

                //    }

                //}

                //foreach (var EstadosAnteriores in EstadosYaProbados)
                //{
                //    TablaEstados.TryGetValue(EstadosAnteriores, out var EstadosValidar);

                //    foreach (var item in EstadosValidar.Values)
                //    {
                //        if (!Estado.Equals(item) && item.Count != 0 && !EstadosAprobarHistorial.Contains(item))
                //        {
                //            EstadosAprobar.Enqueue(item);
                //            EstadosAprobarHistorial.Add(item);
                //        }
                //    }

                //}




            }

            

        }


















    }
}
