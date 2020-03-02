using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Proyecto_Lenguajes
{
    class ManipulacionTexto
    {
        private StreamReader TextoEvaluar;

    
 

 

        // contructor que resibe el texto del forms en forma de lista
        public ManipulacionTexto(StreamReader Texto)
        {
            TextoEvaluar = Texto;
            BuscarInicios();
         
        }

        public void BuscarInicios()
        {
            
            string Contenido = TextoEvaluar.ReadLine();
            int contador = 1;
            Contenido = QuitarCaracteres(Contenido);

            while (Contenido != null && Contenido != "SETS")
            {
                if (Contenido == "")
                {
                    Contenido = TextoEvaluar.ReadLine();
                    Contenido = QuitarCaracteres(Contenido);
                    contador = contador + 1;
                }
                else
                {
                    break;
                }               
               
            }

            if (Contenido == "TOKENS")
            {

            }
            else
            {
                MessageBox.Show("Error en la linea:   "+ contador);
            }

             





        }

        public string QuitarCaracteres(string LineaEvaluar)
        {
            // caracteres a quitar despues de quitar los caracteres no necesario
            char[] CaracteresDelimitadores = { '\t', '\r', ' ' };

            string NuevaLinea = LineaEvaluar.Trim(CaracteresDelimitadores);

            return NuevaLinea;
         }
       
        
         






  

    }
}
