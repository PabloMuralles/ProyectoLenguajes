using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Proyecto_Lenguajes.FirstLastsFollows
{
    class GenerarExpresion
    {
        private StreamReader Texto;

        private List<string> Tokens = new List<string>();

        private List<string> Sets = new List<string>();

        public GenerarExpresion(StreamReader Archivo)
        {
            Texto = Archivo;
            IdentificarSets();
            var idsets = IdSets();
            var definicion = DefinicionTokens();
            ExpresionRegular(idsets, definicion);

        }
        private void IdentificarSets()
        {
            var Contenido = Texto.ReadLine();

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
            }

        }

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

        private List<string> IdSets()
        {
            var IdSets = new List<string>();

            foreach (var item in Sets)
            {
                IdSets.Add(ObtenerID(item));
            }

            return IdSets;

        }

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

        private List<string> DefinicionTokens()
        {
            var Definicion = new List<string>();

            foreach (var item in Tokens)
            {
                Definicion.Add(ObtenerDefinicionTokens(item));
            }

            return Definicion;
        }

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

        private void ExpresionRegular(List<string> IDTokens_ , List<string>DefinicionTokens_)
        {
            var Expresion = string.Empty;

            var Contador = 0;

            foreach (var item in DefinicionTokens_)
            {
                var NuevoItem = ValidarO(item);

                Expresion += NuevoItem;
                if (Contador < DefinicionTokens_.Count - 1)
                { 
                    Expresion += "|";
                    Contador++;
                }
 
                 
            }




        }

        private string ValidarO(string Cadena)
        {
            if (Cadena.Contains("|"))
            {
                Cadena = "(" + Cadena + ")";
                 
            }
            return Cadena;
        }

















    }
}
