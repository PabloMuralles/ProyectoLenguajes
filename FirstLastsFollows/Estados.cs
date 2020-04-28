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
        /// <summary>
        /// variables globales de la clase
        /// </summary>

        private Dictionary<int, List<int>> Follows;

        private List<string> Terminales = new List<string>();

        private List<string> TerminalesArbol = new List<string>();



        /// <summary>
        /// Constructor de la clase que resive de la clase tablas
        /// </summary>
        /// <param name="follows"> resive los follows de la clase donde se calculan</param>
        /// <param name="terminales">se pasan los terminales para poder calcualar los estados</param>
        /// <param name="arbol">se manda el arbol para poder obtener el first</param>
        /// <param name="terminalesArbol"> se pasan todas las hojas del arbol es decir los simbolos</param>
        public Estados(Dictionary<int, List<int>> follows, List<string> terminales, Nodo arbol, List<string> terminalesArbol)
        {
            Follows = new Dictionary<int, List<int>>(follows);

            int posicion = terminales.Count();

            terminales.RemoveAt(posicion - 1);

            Terminales = terminales;

            TerminalesArbol = terminalesArbol;

             
  
        }

        private Dictionary<List<int>, Dictionary<string, List<int>>> TablaEstados = new Dictionary<List<int>, Dictionary<string, List<int>>>();
         
        /// <summary>
        /// Metodo para crear los estados utiliza diccinarios de diccinarios para poder crearlos
        /// </summary>
        /// <returns>retorna un diccionaro de diccionarios que serian los estados creados</returns>
        public Dictionary<List<int>, Dictionary<string, List<int>>> CrearEstados(Nodo Arbol)
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

                    ListaFollows.AddRange(follows.Except(ListaFollows));
                     
                }
                ListaFollows = ListaFollows.OrderBy(x => x).ToList();
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

                        ListaFollows.AddRange(follows.Except(ListaFollows));

                    }
                    ListaFollows = ListaFollows.OrderBy(x => x).ToList();
                    diccModificarNoInicial.Add(Simbolo, ListaFollows);
                    if (!EstadosAprobar.Any(c => c.SequenceEqual(ListaFollows)) && !EstadosHistorial.Any(c => c.SequenceEqual(ListaFollows)) && ListaFollows.Count != 0)
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
