using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Lenguajes.FirstLastsFollows
{
    class Nodo
    {
        public string Padre { get; set; }
        public Nodo Izquierdo { get; set; }
        public Nodo Derecho { get; set; }
        public string Data { get; set; }

        public List<int> First = new List<int>();

        public List<int> Last = new List<int>();
        public int Numero { get; set; }

        public bool Nulable = false;

        public Nodo(string data)
        {
            Data = data;
            Derecho = null;
            Izquierdo = null;

        }

        public bool Eshoja => Derecho == null && Izquierdo == null;







    }

}
