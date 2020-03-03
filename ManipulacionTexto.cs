using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.IO;
using Proyecto_Lenguajes;

namespace Proyecto_Lenguajes
{
    class ManipulacionTexto
    {
        private StreamReader TextoEvaluar;

        private int contador = 0;

        private string Contenido = string.Empty;

         





        // contructor que resibe el texto del forms en forma de lista
        public ManipulacionTexto(StreamReader Texto)
        {
            TextoEvaluar = Texto;
            BuscarInicios();
         
        }

        public void BuscarInicios()
        { 
            Contenido = TextoEvaluar.ReadLine();
            contador = 1;
            Contenido = QuitarCaracteres(Contenido);

            while (Contenido != null)
            {
                if (Contenido == "" && Contenido != "SETS")
                {
                    Contenido = TextoEvaluar.ReadLine();
                    Contenido = QuitarCaracteres(Contenido);
                    contador = contador + 1;
                }
                else
                {
                    if (Contenido == "SETS")
                    {
                        ValidarSets();
                        break;
                    }
                    else
                    { 
                        if (Contenido == "TOKENS")
                        {
                            ValidarTokens();
                            break;
                        }
                        else
                        {
                            MessageBox.Show("Error en la linea:   " + contador + "\n" + "Se esperaba un TOKEN");
                            break;
                        }

                    }

                }
               
               
            }
        }
       

        private Regex ExprecionSETS = new Regex(@"^([a-zA-ZñÑ\s])+=((('([0-9a-zA-ZñÑ\s]{1})'|'([0-9a-zA-ZñÑ\s]{1})'\.\.'([0-9a-zA-ZñÑ\s]{1})')(\+('([0-9a-zA-ZñÑ\s]{1})'|'([0-9a-zA-ZñÑ\s]{1})'\.\.'([0-9a-zA-ZñÑ\s]{1})'))*)|((CHR\([0-9]+\)\.\.CHR\([0-9]+\))(\+(CHR\([0-9]+\)\.\.CHR\([0-9]+\)))))$");
        public void ValidarSets()
        {
            
            Contenido = TextoEvaluar.ReadLine();
            contador = contador + 1;
            Contenido = QuitarCaracteres(Contenido);
            while (Contenido != null)
            {
                if (Contenido == "")
                {
                    Contenido = TextoEvaluar.ReadLine();
                    Contenido = QuitarCaracteres(Contenido);
                    contador = contador + 1;
                }
                else
                {
                    if (ExprecionSETS.IsMatch(Contenido))
                    {
                        Contenido = TextoEvaluar.ReadLine();
                        Contenido = QuitarCaracteres(Contenido);
                        contador = contador + 1;

                    }
                    else
                    {
                        if (Contenido == "TOKENS")
                        {
                            ValidarTokens();
                            break;
                        }
                        else
                        {
                            MessageBox.Show("Error en la linea: " + contador);
                            break;
                        } 
                    } 
                }  
             }
        }




        private Regex ExprecionTOKENS = new Regex(@"^TOKEN([\s])+[0-9]+([\s])*=([\s])*(('([a-zA-Z0-9<>=;:(){}\.\[\],])')*)$");




        public void ValidarTokens()
        {
            Contenido = TextoEvaluar.ReadLine();
            contador = contador + 1;
            Contenido = QuitarEspaciosBlancoTokens(Contenido);
            while (Contenido != null)
            {
                if (Contenido == "")
                {
                    Contenido = TextoEvaluar.ReadLine();
                    Contenido = QuitarEspaciosBlancoTokens(Contenido);
                    contador = contador + 1;
                }
                else
                {
                    if (ExprecionTOKENS.IsMatch(Contenido))
                    {
                        Contenido = TextoEvaluar.ReadLine();
                        Contenido = QuitarEspaciosBlancoTokens(Contenido);
                        contador = contador + 1;
                    }
                    else
                    {
                        MessageBox.Show("Error en la linea: " + contador);
                        break;
                    }

                }

            }


        }




        public string QuitarEspaciosBlancoTokens(string LieneaQuitar)
        {
            char[] CaracteresDelimitadores = { '\t', '\r'};
            string LineaNuevaTokens = LieneaQuitar.Trim(CaracteresDelimitadores);
            LineaNuevaTokens = LineaNuevaTokens.Trim();
            return LineaNuevaTokens;
        }





        public string QuitarCaracteres(string LineaEvaluar)
        {
            string[] QuitrarEspacios = new string[LineaEvaluar.Length];
            // caracteres a quitar despues de quitar los caracteres no necesario
            char[] CaracteresDelimitadores = { '\t', '\r', ' ' };

            string NuevaLinea = LineaEvaluar.Trim(CaracteresDelimitadores);
            QuitrarEspacios = NuevaLinea.Split(' ');

            string LineaRetornar = string.Empty;

            for (int i = 0; i < QuitrarEspacios.Length; i++)
            {
                if (QuitrarEspacios[i] != " ") 
                {
                    LineaRetornar += QuitrarEspacios[i];
                }
            }

            return LineaRetornar;
         }
       
        
         






  

    }
}
