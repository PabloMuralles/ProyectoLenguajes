using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Lenguajes.Validacion
{
    class Nodo
    {
        public string Padre { get; set; }
        public Nodo Izquierdo { get; set; }
        public Nodo Derecho { get; set; }
        public string Data { get; set; }

        public Nodo(string data)
        {
            Data = data;
            Derecho = null;
            Izquierdo = null;
           
        }

        

    }
}
