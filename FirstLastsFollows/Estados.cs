using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Lenguajes.FirstLastsFollows
{
    class Estados
    {

        private Dictionary<int, List<int>> Follows;

        private List<string> Terminales = new List<string>();

        private List<string> TerminalesArbol = new List<string>();

        private Nodo Arbol;
        public Estados(Dictionary<int, List<int>> follows, List<string> terminales, Nodo arbol, List<string> terminalesArbol)
        {
            Follows = new Dictionary<int, List<int>>(follows);

            int posicion = terminales.Count();

            terminales.RemoveAt(posicion - 1);

            Terminales = terminales;

            TerminalesArbol = terminalesArbol;

            Arbol = arbol;
  
        }

        private Dictionary<List<int>, Dictionary<string, List<int>>> TablaEstados = new Dictionary<List<int>, Dictionary<string, List<int>>>();
         

        public Dictionary<List<int>, Dictionary<string, List<int>>> CrearEstados()
        { 
            Queue<List<int>> EstadosAprobar = new Queue<List<int>>();

            List<List<int>> EstadosHistorial = new List<List<int>>();
             

            var diccModificar = new Dictionary<string, List<int>>();

            var EstadoInicial = Arbol.First;

            EstadosHistorial.Add(EstadoInicial);

            foreach (var Simbolo in Terminales)
            {
                var ListaConcordancia = new List<int>();

                var ListaFollows = new List<int>();

                foreach (var item in EstadoInicial)
                {
                    var SimbolosArbol = TerminalesArbol[item - 1];
                    if (Simbolo==SimbolosArbol)
                    {
                        ListaConcordancia.Add(item);
                    }
                }

                foreach (var SimblosItem in ListaConcordancia)
                {
                    Follows.TryGetValue(SimblosItem, out var follows);

                    ListaFollows.AddRange(follows);
                     
                }
                diccModificar.Add(Simbolo, ListaFollows);
                if (!EstadosAprobar.Any(c=>c.SequenceEqual(ListaFollows)) && !EstadosHistorial.Any(c => c.SequenceEqual(ListaFollows)) && ListaFollows.Count != 0)
                {
                    EstadosAprobar.Enqueue(ListaFollows);
                }
                 
            }
            TablaEstados.Add(EstadoInicial, diccModificar);

            while (EstadosAprobar.Count() != 0)
            {
                var diccModificarNoInicial = new Dictionary<string, List<int>>();

                var Estado = EstadosAprobar.Dequeue();

                EstadosHistorial.Add(Estado);

                foreach (var Simbolo in Terminales)
                {
                    var ListaConcordancia = new List<int>();

                    var ListaFollows = new List<int>();

                    foreach (var item in Estado)
                    {
                        var SimbolosArbol = TerminalesArbol[item - 1];
                        if (Simbolo == SimbolosArbol)
                        {
                            ListaConcordancia.Add(item);
                        }
                    }

                    foreach (var SimblosItem in ListaConcordancia)
                    {
                        Follows.TryGetValue(SimblosItem, out var follows);

                        ListaFollows.AddRange(follows);

                    }
                    diccModificarNoInicial.Add(Simbolo, ListaFollows);
                    if (!EstadosAprobar.Any(c => c.SequenceEqual(ListaFollows)) && !EstadosHistorial.Any(c => c.SequenceEqual(ListaFollows)))
                    {
                        EstadosAprobar.Enqueue(ListaFollows);
                    }
                    

                }
                TablaEstados.Add(Estado, diccModificarNoInicial);
                 
            }

            return TablaEstados;

 
          




        }

    }
}
