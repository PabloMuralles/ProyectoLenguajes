using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Proyecto_Lenguajes.FirstLastsFollows
{
    class GenerarExpresion
    {

        /// <summary>
        /// varibles globales de la clase
        /// </summary>
        
        private StreamReader Texto;

        private List<string> Tokens = new List<string>();

        private List<string> Sets = new List<string>();

        bool ArchivoCorrecto = true;

        private List<string> Terminales = new List<string>();

        /// <summary>
        /// constructor de la clase
        /// </summary>
        /// <param name="Archivo">recibe el archivo para poder relizar los calculos</param>
        public GenerarExpresion(StreamReader Archivo)
        {
            
            Texto = Archivo;
            IdentificarSets();
            var idsets = IdSets();
            var definicion = QuitarEspaciosBlancoTokens(DefinicionTokens());
            var Expresion = ExpresionRegular(idsets, definicion);
     
            if (ArchivoCorrecto == true)
            {
                ArbolFirstLast arbol = new ArbolFirstLast(Expresion, Terminales);
            }
            else
            {
                Form1 form = new Form1();
                form.Show();
            }
           
        }

        /// <summary>
        /// metodo para identificar los sets
        /// </summary>
        private void IdentificarSets()
        {
            var Contenido = Texto.ReadLine();

            Contenido = QuitarCaracteres_EspaciosBlancos(Contenido);

            while (Contenido != null)
            {
                if (Contenido == "SETS")
                {
                    GuardarSets();
                    break;
                }
                else
                {
                    if (Contenido =="TOKENS")
                    {
                        GuardarTokens();
                        break;
                    }
                }

                Contenido = Texto.ReadLine();
                Contenido = QuitarCaracteres_EspaciosBlancos(Contenido);
            }

        }

        /// <summary>
        /// metodo para guardar los sets y posteriormente guardar los ids
        /// </summary>
        private void GuardarSets()
        {
            var Contenido = Texto.ReadLine();
            Contenido = QuitarCaracteres_EspaciosBlancos(Contenido);

            while (Contenido != null)
            {
                if (Contenido != "TOKENS")
                {
                    Sets.Add(Contenido);
                }
                else if (Contenido == "TOKENS")
                {
                    GuardarTokens();
                    break;
                }
                Contenido = Texto.ReadLine();
                Contenido = QuitarCaracteres_EspaciosBlancos(Contenido);
            }

        }

        /// <summary>
        /// Metodo que guardar los tokens 
        /// </summary>
        private void GuardarTokens()
        {
            
            var Contenido = Texto.ReadLine();
            Contenido = QuitarCaracteres_EspaciosBlancos(Contenido);

            while (Contenido != null)
            {
                if (Contenido != "ACTIONS")
                {
                    Tokens.Add(Contenido);
                }
                else 
                {
                    break;
                }

                Contenido = Texto.ReadLine();
                Contenido = QuitarCaracteres_EspaciosBlancos(Contenido);
            }

            Contenido = Texto.ReadLine();
             
        }
 
        /// <summary>
        /// metodo que quita los caracteres especiale y espacios en blanco
        /// </summary>
        /// <param name="LineaEvaluar">recibe una linea de codigo para poder relizar el poceso</param>
        /// <returns>devuelve la cade o lines sin esos caracteres </returns>
        public string QuitarCaracteres_EspaciosBlancos(string LineaEvaluar)
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
        /// guarda unicamente los id de los sets
        /// </summary>
        /// <returns>Retorna una lista solo con los ids</returns>
        private List<string> IdSets()
        {
            var IdSets = new List<string>();

            foreach (var item in Sets)
            {
                IdSets.Add(ObtenerID(item));
            }

            return IdSets;

        }

        /// <summary>
        /// Metodo que quita todo lo que esta despues del igual 
        /// </summary>
        /// <param name="Cadena"> recibe una linea de los sets</param>
        /// <returns>retorna el id de los sets para poder guardarlos</returns>
        private string ObtenerID(string Cadena)
        {
            var CadenaDividda = Cadena.ToCharArray();

            var CadenaNueva = string.Empty;

            for (int i = 0; i < Cadena.Length; i++)
            {
                if (CadenaDividda[i] != '=')
                {
                    CadenaNueva += Convert.ToString(CadenaDividda[i]);
                }
                else  
                {
                    break;
                }

            }
            return CadenaNueva;
             
        }

        /// <summary>
        /// Metido que guarda la definicion de los tokens
        /// </summary>
        /// <returns>retorna una lista con la definicion de los tokens</returns>
        private List<string> DefinicionTokens()
        {
            var Definicion = new List<string>();

            foreach (var item in Tokens)
            {
                Definicion.Add(ObtenerDefinicionTokens(item));
            }

            return Definicion;
        }

        /// <summary>
        /// Metodo para quitar todo lo que esta despues del igual de los tokens
        /// </summary>
        /// <param name="Cadena">recibe una linea de los tokens</param>
        /// <returns>devuelve la definicion de los tokens </returns>
        private string ObtenerDefinicionTokens(string Cadena)
        {
            var EmpezarGuardar = false;

            var CadenaDividida = Cadena.ToArray();

            var CadenaNueva = string.Empty;

            for (int i = 0; i < CadenaDividida.Length; i++)
            {
               
                if (EmpezarGuardar == true )
                {
                    CadenaNueva += Convert.ToString(CadenaDividida[i]);
                }
                if (CadenaDividida[i] == '=')
                {
                    EmpezarGuardar = true;
                }
            }

            return CadenaNueva;

        }

        /// <summary>
        /// Metodo para quitar los espacions en blanco es decir posicion de la lsita en blanco de la decinicion de los tokens
        /// </summary>
        /// <param name="DefinicionTokens">recibe una lista con la decinicion de los tokens</param>
        /// <returns>retorna esa lista solo que son esas posiciones en blanco</returns>
        public List<string> QuitarEspaciosBlancoTokens(List<string> DefinicionTokens)
        {
            var NuevaLista = new List<string>();
            foreach (var item in DefinicionTokens)
            {
                if (item != "")
                {
                    NuevaLista.Add(item);
                }
            }
            return NuevaLista;
        }

        /// <summary>
        /// Metodo que construye la expresion regular en base a los tokens
        /// </summary>
        /// <param name="IDsets_">recibe una lista de los ids de sets</param>
        /// <param name="DefinicionTokens_">Recibe una lista con la decinicion de los tokens</param>
        /// <returns></returns>
        private string ExpresionRegular(List<string> IDsets_ , List<string>DefinicionTokens_)
        {
            var Expresion = string.Empty;

            var Contador = 1;

            foreach (var item in DefinicionTokens_)
            {    
                var NuevoItem = ValidarConcatenacion(item, IDsets_);
 

                Expresion += NuevoItem;
                if (Contador < DefinicionTokens_.Count)
                {
                    Expresion += "|";
                         
                }
                Contador++;
                  
            }

            return Expresion;
             
        }
         
        /// <summary>
        /// Metodo para ver cuando se debe de poner concatenacion en la expresion regular
        /// </summary>
        /// <param name="Cadena">linea de la definicion de los tokens</param>
        /// <param name="Sets_">lista de los ids </param>
        /// <returns>retorna la linea de la definicion concatenada</returns>
        private string ValidarConcatenacion(string Cadena, List<string> Sets_)
        {
            var CadenaDivida = Cadena.ToArray();

            var TomarCaracteres = false;

            var ExisteComilla = false;

            var Analizador = string.Empty;

            var CadenaNueva = string.Empty;

            var CasoEspecialComilla = false;

            var ExisteParentesis = false;

            var Terminal = string.Empty;

            for (int i = 0; i < CadenaDivida.Length; i++)
            {
                if ((char.IsLetter(CadenaDivida[i]) == true && ExisteComilla == false) || (ExisteParentesis == true && char.IsLetter(CadenaDivida[i]) == true))
                {
                    if (TomarCaracteres == false)
                    {
                        TomarCaracteres = true;

                        Analizador += Convert.ToString(CadenaDivida[i]);

                        if (Sets_.Contains(Analizador) == true)
                        {
                            TomarCaracteres = false;
                            CadenaNueva += Analizador;
                            if (!Terminales.Contains(Analizador))
                            {
                                Terminales.Add(Analizador);

                            }
                            if (i != CadenaDivida.Length)
                            {
                                CadenaNueva += "·";

                            }
                            Analizador = string.Empty;

                        }

                    }
                    else
                    {
                        Analizador += Convert.ToString(CadenaDivida[i]);
                        if (Sets_.Contains(Analizador) == true)
                        {
                            TomarCaracteres = false;
                            CadenaNueva += Analizador;
                            if (!Terminales.Contains(Analizador))
                            {
                                Terminales.Add(Analizador);

                            }
                            if (i != CadenaDivida.Length)
                            {
                                CadenaNueva += "·";

                            }
                            Analizador = string.Empty;

                        }
                    }
                }
                else if ((TomarCaracteres == false && CadenaDivida[i] == '\'') || ExisteComilla == true)
                { 

                    if (ExisteComilla == false)
                    {
                        CadenaNueva += Convert.ToString(CadenaDivida[i]);
                        Terminal += Convert.ToString(CadenaDivida[i]);
                        ExisteComilla = true;
                        if (CadenaDivida[i + 1] == '\'')
                        {
                            CasoEspecialComilla = true;
                        }

                    }
                    else
                    {
                        CadenaNueva += Convert.ToString(CadenaDivida[i]);
                        Terminal += Convert.ToString(CadenaDivida[i]);
                        if (CadenaDivida[i] == '\'' && CasoEspecialComilla == false)
                        {
                            if (!Terminales.Contains(Terminal))
                            {
                              Terminales.Add(Terminal);
                            }
                            CadenaNueva += "·";
                            ExisteComilla = false;
                            Terminal = string.Empty;
                        }
                        else if (CasoEspecialComilla == true)
                        {
                            CasoEspecialComilla = false;
                        }                          
                    }

                }
                else if (CadenaDivida[i] == '|' && ExisteComilla == false)
                {

                    if (CadenaNueva.Substring(CadenaNueva.Length - 1, 1) == "·")
                    { 
                        CadenaNueva = CadenaNueva.Remove(CadenaNueva.Length - 1, 1); 
                    }

                    CadenaNueva += Convert.ToString(CadenaDivida[i]);
                }
                else if ((CadenaDivida[i] == '*' || CadenaDivida[i] == '?' || CadenaDivida[i] == '+') && ((ExisteComilla == false && TomarCaracteres == false) || ExisteParentesis == true))
                {
                    if (CadenaNueva.Substring(CadenaNueva.Length - 1, 1) == "·")
                    {
                        CadenaNueva = CadenaNueva.Remove(CadenaNueva.Length - 1, 1);
                        CadenaNueva += Convert.ToString(CadenaDivida[i]);
                    }
                    else
                    {
                        CadenaNueva += Convert.ToString(CadenaDivida[i]);
                        CadenaNueva += "·";

                    }

                }
                else if (CadenaDivida[i] == '(' || CadenaDivida[i] == ')')
                {
                    if (CadenaDivida[i] == '(')
                    {
                        ExisteParentesis = true;
                        CadenaNueva += Convert.ToString(CadenaDivida[i]);
                    }
                    else
                    {
                        ExisteParentesis = false;
                        if (CadenaNueva.Substring(CadenaNueva.Length - 1, 1) == "·")
                        {
                            CadenaNueva = CadenaNueva.Remove(CadenaNueva.Length - 1, 1);
                        }
                        CadenaNueva += Convert.ToString(CadenaDivida[i]);
                    }

                }
                else if (CadenaDivida[i] == '{' && CadenaDivida[i] != '\'')
                {
                    break;
                }
                else if (char.IsLetter(CadenaDivida[i]) == false &&  TomarCaracteres == true)
                {
                    ArchivoCorrecto = false;
                    MessageBox.Show("La palabra no existe en sets");

                    
                }
                 
            }
            CadenaNueva = CadenaNueva.TrimEnd('·');

            return CadenaNueva;
        }

       

        
       
         


    }
}
