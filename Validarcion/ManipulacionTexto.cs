using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.IO;
using Proyecto_Lenguajes;

namespace Proyecto_Lenguajes.Validacion
{
    class ManipulacionTexto
    {
        // variable para saber si el archivo esta correcto y pasar a la otra fase
        private bool EstadoArchivo = true;

        // variable donde se alacena el texto a evaluar
        private StreamReader TextoEvaluar;

        // contador para poder mostrar en que linea se encuentra el error
        private int contador = 0;

        // variable donde se va guardar cada linea del archivo
        private string Contenido = string.Empty;
         
        // contructor que resibe el texto del forms en forma de lista
        public ManipulacionTexto(StreamReader Texto)
        {
            TextoEvaluar = Texto;
            BuscarInicios();
       
         
        }
        //Metodo para buscar las palabras claves y merse a evaluar cada una de las secciones
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
                            EstadoArchivo = false;
                            break;
                        }

                    }

                }
               
               
            }
        }

        // Definicion de exprecion regular para sets
        private Regex ExprecionSETS = new Regex(@"^([a-zA-ZñÑ<>="";:(){}\.\[\],'\+\-_\*\.\s])+=((('([0-9a-zA-ZñÑ<>="";:(){}\.\[\],'\+\-_\*\.\s]{1})'|'([0-9a-zA-ZñÑ<>="";:(){}\.\[\],'\+\-_\*\.\s]{1})'\.\.'([0-9a-zA-ZñÑ<>="";:(){}\.\[\],'\+\-_\*\.\s]{1})')(\+('([0-9a-zA-ZñÑ<>="";:(){}\.\[\],'\+\-_\*\.\s]{1})'|'([0-9a-zA-ZñÑ<>="";:(){}\.\[\],'\+\-_\*\.\s]{1})'\.\.'([0-9a-zA-ZñÑ<>="";:(){}\.\[\],'\+\-_\*\.\s]{1})'))*)|((CHR\([0-9]+\)\.\.CHR\([0-9]+\))(\+(CHR\([0-9]+\)\.\.CHR\([0-9]+\)))*))$");
        
        // Validar el apartado de sets
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
                            EstadoArchivo = false;
                            break;
                        } 
                    } 
                }  
             }
        }


 
        // expreciones regulares para validar tokens
        private Regex ExprecionTOKENS = new Regex(@"^TOKEN([\s])+[0-9]+([\s])*=([\s])*((('([a-zA-Z0-9<>="";:(){}\.\[\],'\+\-_\*\.])')+))$");
        private Regex ExprecionTOKENS2 = new Regex(@"^TOKEN([\s])+[0-9]+([\s])*=([\s])*((('([a-zA-Z0-9<>="";:(){}\.\[\],'\+\-_\*\.])')+)([\s])*([a-zA-ZñÑ]+)([\s])*(('([a-zA-Z0-9<>="";:(){}\.\[\],'\+\-_\*\.])')+))(([\s])*\|([\s])*(('([a-zA-Z0-9<>="";:(){}\.\[\],'\+\-_\*\.])')+)([\s])*([a-zA-ZñÑ]+)([\s])*(('([a-zA-Z0-9<>="";:(){}\.\[\],'\+\-_\*\.])')+))*$");
        private Regex ExprecionTOKENS3 = new Regex(@"^TOKEN([\s])+[0-9]+([\s])*=([\s])*([a-zA-ZÑñ]+([\s])*(\+|\*|\?|\|)?)+$");
        private Regex ExprecionTOKENS4 = new Regex(@"^TOKEN([\s])+[0-9]+([\s])*=([\s])*([a-zA-ZÑñ]+([\s])*(\+|\*|\?)?)*(([\s])*((\(([\s])*[a-zA-ZÑñ]+([\s])*(\+|\*|\?|\|)?)((([\s])*[a-zA-ZÑñ]+([\s])*(\+|\*|\?|\|)?([\s])*)*\)(\+|\*|\?|\|)?)*)?(([\s])*{([\s])*[a-zA-ZÑñ]+([\s])*\(([\s])*\)([\s])*}))$");
        // Esta ultima expresion no es muy eficiente solo es para arreglar el error rapido
        private Regex ExprecionTOKENS5 = new Regex(@"^TOKEN([\s])+[0-9]+([\s])*=([\s])*([a-zA-ZÑñ]+([\s])*(\+|\*|\?)?)*(([\s])*((\(([\s])*[a-zA-ZÑñ]+([\s])*(\+|\*|\?|\|)?)((([\s])*[a-zA-ZÑñ]+([\s])*(\+|\*|\?|\|)?([\s])*)*\)(\+|\*|\?|\|)?)?)?)$");

        // Metodo para validar la seccion de tokens
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
                    if (ExprecionTOKENS4.IsMatch(Contenido) || ExprecionTOKENS2.IsMatch(Contenido) || ExprecionTOKENS3.IsMatch(Contenido) || ExprecionTOKENS.IsMatch(Contenido)|| ExprecionTOKENS5.IsMatch(Contenido))
                    {
                        Contenido = TextoEvaluar.ReadLine();
                        Contenido = QuitarEspaciosBlancoTokens(Contenido);
                        contador = contador + 1;
                    }
                    else
                    {
                        if (Contenido == "ACTIONS")
                        {
                            ValidarActions();
                            break;
                        }
                        else
                        {
                            MessageBox.Show("Error en la linea: " + contador);
                            EstadoArchivo = false;
                            break;
                        }    
                    }
                }
            }
        }

        // Expresiones regulares para el partado de accionts
        private Regex ExprecionActions = new Regex(@"^([a-zA-ZñÑ<>="";:(){}\.\[\],'\+\-_\*\.\s])+=((('([0-9a-zA-ZñÑ<>="";:(){}\.\[\],'\+\-_\*\.\s]{1})'|'([0-9a-zA-ZñÑ<>="";:(){}\.\[\],'\+\-_\*\.\s]{1})'\.\.'([0-9a-zA-ZñÑ<>="";:(){}\.\[\],'\+\-_\*\.\s]{1})')(\+('([0-9a-zA-ZñÑ<>="";:(){}\.\[\],'\+\-_\*\.\s]{1})'|'([0-9a-zA-ZñÑ<>="";:(){}\.\[\],'\+\-_\*\.\s]{1})'\.\.'([0-9a-zA-ZñÑ<>="";:(){}\.\[\],'\+\-_\*\.\s]{1})'))*)|((CHR\([0-9]+\)\.\.CHR\([0-9]+\))(\+(CHR\([0-9]+\)\.\.CHR\([0-9]+\)))*))$");
        private Regex ExprecionActions2 = new Regex(@"^[0-9]+=('([a-zA-Z0-9<>="";:(){}\.\[\],'\+\-_\*\.]+)')$");



        // validar la seccion de actions
        public void ValidarActions()
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
                    if (Contenido == "RESERVADAS()")
                    {
                        Reservadas();
                        break;
                    }
                    else
                    {
                        MessageBox.Show("Error en la linea: " + contador + "\n"+"Se esperaba RESERVADAS()");
                        EstadoArchivo = false;
                        break;
                    }
                }

            }

        } 

        //validar el apartado de la funcion reservadas
        public void Reservadas()
        {
            Contenido = TextoEvaluar.ReadLine();
            Contenido = QuitarCaracteres(Contenido);
            contador = contador + 1;
            while (Contenido != null)
            {
                if (Contenido =="")
                {
                    Contenido = TextoEvaluar.ReadLine();
                    Contenido = QuitarCaracteres(Contenido);
                    contador = contador + 1;
                }
                else
                {
                    if (Contenido=="{")
                    {
                        ValidarAdentroLlavesActions();
                        break;
                    }
                    else
                    {
                        MessageBox.Show("Error en la liena: "+contador+"\n"+"Se esperaba una {");
                        EstadoArchivo = false;
                        break;
                        
                    }
                }
            }

        }

        // Validar el codigo que viene en la parte de adentro de las llaves
        public void ValidarAdentroLlavesActions()
        {
            Contenido = TextoEvaluar.ReadLine();
            Contenido = QuitarCaracteres(Contenido);
            contador = contador + 1;
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
                    if (ExprecionActions.IsMatch(Contenido) || ExprecionActions2.IsMatch(Contenido))
                    {
                        Contenido = TextoEvaluar.ReadLine();
                        Contenido = QuitarCaracteres(Contenido);
                        contador = contador + 1;
                    }
                    else
                    {
                        if (Contenido == "}")
                        {
                            ValidarError();
                            break;
                        }
                        else
                        {
                            MessageBox.Show("Error Linea: " + contador);
                            EstadoArchivo = false;
                            break;
                        }
                    }
                }
            }
        }

        // Exprecion regular para evaluar errores 
        private Regex ExprecionErrores = new Regex(@"^([a-zA-zñÑ]+)*ERROR=[0-9]+$");

        public void ValidarError()
        {
            Contenido = TextoEvaluar.ReadLine();
            Contenido = QuitarCaracteres(Contenido);
            contador = contador + 1;
            while (Contenido != null)
            {
                if (Contenido == "")
                {
                    Contenido = TextoEvaluar.ReadLine();
                    if (Contenido != null)
                    {
                        Contenido = QuitarCaracteres(Contenido);
                        contador = contador + 1;

                    }
                    else
                    {
                        MessageBox.Show("Archivo Correcto ");
                    }


                }
                else
                {
                    if (ExprecionErrores.IsMatch(Contenido))
                    {
                        Contenido = TextoEvaluar.ReadLine();
                        if (Contenido!=null)
                        {
                            Contenido = QuitarCaracteres(Contenido);
                            contador = contador + 1;

                        }
                        else
                        {
                            MessageBox.Show("Archivo Correcto ");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Error Linea: " + contador);
                        EstadoArchivo = false;
                        break;
                    }

                }

            }
          
        }
         
        // metodo para poder quitar lo espacios en blanco unicamente para el apartado de tokens
        public string QuitarEspaciosBlancoTokens(string LieneaQuitar)
        {
            char[] CaracteresDelimitadores = { '\t', '\r'};
            string LineaNuevaTokens = LieneaQuitar.Trim(CaracteresDelimitadores);
            LineaNuevaTokens = LineaNuevaTokens.Trim();
            return LineaNuevaTokens;
        }
         
        // meto para quitar espacios en blanco usado en todos los apartados menos tikons

        public string QuitarCaracteres(string LineaEvaluar)
        {
            string LineaRetornar = string.Empty;
           
                string[] QuitrarEspacios = new string[LineaEvaluar.Length];
                // caracteres a quitar despues de quitar los caracteres no necesario
                char[] CaracteresDelimitadores = { '\t', '\r', ' ' };

                string NuevaLinea = LineaEvaluar.Trim(CaracteresDelimitadores);
                QuitrarEspacios = NuevaLinea.Split(' ');

                

                for (int i = 0; i < QuitrarEspacios.Length; i++)
                {
                    if (QuitrarEspacios[i] != " ")
                    {
                        LineaRetornar += QuitrarEspacios[i];
                    }
                }
                return LineaRetornar;
            
        }
       
        /// <summary>
        /// Metodo para poder verificar si se pasa a la fase 2 o no 
        /// </summary>
        /// <returns>un bool para poder pasar a la otra fase</returns>
        public bool AceptacionArchivo()
        {
            return EstadoArchivo;
        }






  

    }
}
