using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Lenguajes.FirstLastsFollows
{
    class Nodo
    {
        /// <summary>
        /// Todas las propiedades del nodo para poder calcular los first, last y follows
        /// </summary>
        public string Padre { get; set; }
        public Nodo Izquierdo { get; set; }
        public Nodo Derecho { get; set; }
        public string Data { get; set; }

        public List<int> First = new List<int>();

        public List<int> Last = new List<int>();
        public int Numero { get; set; }

        public bool Nulable = false;
        /// <summary>
        /// Construcctor del nodo
        /// </summary>
        /// <param name="data">resive el contenido del arbol</param>
        public Nodo(string data)
        {
            Data = data;
            Derecho = null;
            Izquierdo = null;

        }

        /// <summary>
        /// linq para verificar si el nodo es hoja y poder agregarle su id 
        /// </summary>
        public bool Eshoja => Derecho == null && Izquierdo == null;







    }

}
