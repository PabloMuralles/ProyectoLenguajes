﻿using System;
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
        public void Proceso(Nodo Raiz)
        {
            Arbol = Raiz;
            RecorridoFirstLast.Clear();
            Follows.Clear();
            RecorridoPostorden(Arbol);
            Form2 Form2 = new Form2();
            Form2.Show();

        }

        public Dictionary<int, List<int>> Follows = new Dictionary<int, List<int>>();

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
                    ContadorTerminales++;
                }
                else if (raiz.Data == "*")
                {
                    raiz.Nulable = true;
                    raiz.First = raiz.Izquierdo.First;
                    raiz.Last = raiz.Izquierdo.Last;
                    foreach (var LastC1 in raiz.Izquierdo.Last)
                    {
                        foreach (var firstC2 in raiz.Izquierdo.First)
                        {
                            Follows.FirstOrDefault(x => x.Key == LastC1).Value.Add(firstC2);
                        }

                    }
                }
                else if (raiz.Data == "+")
                {
                    raiz.First = raiz.Izquierdo.First;
                    raiz.Last = raiz.Izquierdo.Last;
                    foreach (var LastC1 in raiz.Izquierdo.Last)
                    {
                        foreach (var firstC2 in raiz.Izquierdo.First)
                        {
                            Follows.FirstOrDefault(x => x.Key == LastC1).Value.Add(firstC2);
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
                            Follows.FirstOrDefault(x => x.Key == LastC1).Value.Add(firstC2);
                        }

                    }

                }
            }
        }

      

    }
}