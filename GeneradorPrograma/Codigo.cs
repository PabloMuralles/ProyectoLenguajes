﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
 


namespace Proyecto_Lenguajes.GeneradorPrograma
{
    class Codigo
    {
      
        /// <summary>
        /// Construcctor de la clase donde se realiza todo el proceso de escirtura del proyecto generico
        /// </summary>
        /// <param name="Estados_">Estados calculados un diccionario</param>
        /// <param name="Terminales_">Una lista con los terminales </param>
        /// <param name="SimboloAceptacion">El id del simbolo de aceptacion</param>
        /// <param name="NewPath">El lugar donde se quiere guardar el analizador</param>
        public Codigo(Dictionary<List<int>, Dictionary<string, List<int>>> Estados_ , List<string> Terminales_, int SimboloAceptacion, string NewPath)
        { 
            (List<string> ListaEstados, List<string> ListaEstadosAceptacion) = RecorrerEstados(Estados_, SimboloAceptacion);

            #region Escribir Ifs Case
            var DiccSet = Data.Instance.DiccionarioSets;

            var Idset = Data.Instance.IdsSets;

            var DiccCase = new Dictionary<int, List<string>>();

            int contador = 0;
            foreach (var Estados in Estados_)
            {
                var ListaIfCase = new List<string>();
                var SentenciaIF = string.Empty;
                foreach (var Transiciones in Estados.Value)
                {
                    if (Transiciones.Value.Count != 0)
                    {
                        if (Idset.Contains(Transiciones.Key))
                        {
                            DiccSet.TryGetValue(Transiciones.Key, out var Definicion);
                            var DividirDefinicion = Definicion.Split('|');

                            if (DividirDefinicion.Length == 1)
                            {
                                if (DividirDefinicion[0].Contains("~"))
                                {
                                    var Rango = DividirDefinicion[0].Split('~');
                                    if (ListaIfCase.Count != 0)
                                    {
                                        SentenciaIF += "else ";
                                    }
                                    if (Transiciones.Key != "CHARSET")
                                    {
                                        var Uno = Encoding.ASCII.GetBytes(Rango[0]);
                                        var Dos = Encoding.ASCII.GetBytes(Rango[1]);
                                        SentenciaIF += $"if(NuevaCadena[Contador] >= {Uno[0]} && NuevaCadena[Contador] <= {Dos[0]} ) \n ";

                                        SentenciaIF += "{\n";
                                        SentenciaIF += $"Estado = {ListaEstados.IndexOf(string.Join(",", Transiciones.Value))}  ;\n";
                                        SentenciaIF += "}";
                                        ListaIfCase.Add(SentenciaIF);
                                        SentenciaIF = string.Empty;

                                    }
                                    else
                                    {
                                        SentenciaIF += $"if(NuevaCadena[Contador] >= {Rango[0]} && NuevaCadena[Contador] <= {Rango[1]}) \n ";

                                        SentenciaIF += "{\n";
                                        SentenciaIF += $"Estado = {ListaEstados.IndexOf(string.Join(",", Transiciones.Value))}  ;\n";
                                        SentenciaIF += "}";
                                        ListaIfCase.Add(SentenciaIF);
                                        SentenciaIF = string.Empty;
                                    }
                                }
                                else
                                {
                                    if (ListaIfCase.Count != 0)
                                    {
                                        SentenciaIF += "else  ";
                                    }
                                    var Uno = Encoding.ASCII.GetBytes(DividirDefinicion[0]);
                                    SentenciaIF += $"if(NuevaCadena[Contador] == {Uno[0]} ) \n ";
                                    SentenciaIF += "{\n";
                                    SentenciaIF += $"Estado = {ListaEstados.IndexOf(string.Join(",", Transiciones.Value))} ;\n ";
                                    SentenciaIF += "}";
                                    ListaIfCase.Add(SentenciaIF);
                                    SentenciaIF = string.Empty;

                                }

                            }
                            else
                            {
                                if (ListaIfCase.Count != 0)
                                {
                                    SentenciaIF += "else  ";
                                }

                                for (int i = 0; i < DividirDefinicion.Length; i++)
                                {

                                    if (DividirDefinicion[i].Contains("~"))
                                    {
                                        var Rango = DividirDefinicion[i].Split('~');
                                        if (i == 0)
                                        {
                                            var Uno = Encoding.ASCII.GetBytes(Rango[0]);
                                            var Dos = Encoding.ASCII.GetBytes(Rango[1]);
                                            SentenciaIF += $"if(NuevaCadena[Contador] >= {Uno[0]} && NuevaCadena[Contador] <= {Dos[0]} ";

                                        }
                                        else
                                        {
                                            var Uno = Encoding.ASCII.GetBytes(Rango[0]);
                                            var Dos = Encoding.ASCII.GetBytes(Rango[1]);
                                            SentenciaIF += $"|| NuevaCadena[Contador] >= {Uno[0]} && NuevaCadena[Contador] <= {Dos[0]}  ";
                                        }

                                    }
                                    else
                                    {
                                        if (i == 0)
                                        {
                                            var Uno = Encoding.ASCII.GetBytes(DividirDefinicion[0]);
                                            SentenciaIF += $"if(NuevaCadena[Contador] == {Uno[0]} ";

                                        }
                                        else
                                        {
                                            var Uno = Encoding.ASCII.GetBytes(DividirDefinicion[0]);
                                            SentenciaIF += $"|| NuevaCadena[Contador] == {Uno[0]}";
                                        }


                                    }
                                    if (i == DividirDefinicion.Length - 1)
                                    {
                                        SentenciaIF += ")\n";
                                        SentenciaIF += "{\n";
                                        SentenciaIF += $"Estado = {ListaEstados.IndexOf(string.Join(",", Transiciones.Value))} ; \n ";
                                        SentenciaIF += "}";

                                        ListaIfCase.Add(SentenciaIF);
                                        SentenciaIF = string.Empty;
                                    }


                                }



                            }

                        }
                        else
                        {
                            if (ListaIfCase.Count != 0)
                            {
                                SentenciaIF += "else ";
                            }
                            var Key = Transiciones.Key.ToCharArray();
                            var NewKey = Convert.ToString(Key[1]);

                            var KeyAcii = Encoding.ASCII.GetBytes(NewKey);

                            SentenciaIF += $"if(NuevaCadena[Contador] == {KeyAcii[0]} ) \n ";
                            SentenciaIF += "{\n";
                            SentenciaIF += $"Estado = {ListaEstados.IndexOf(string.Join(",", Transiciones.Value))} ; \n ";
                            SentenciaIF += "}";
                            ListaIfCase.Add(SentenciaIF);
                            SentenciaIF = string.Empty;

                        }
                    }

                }

                if (ListaIfCase.Count != 0)
                {
                    SentenciaIF += " \n else \n { \n  ";

                    if (ListaEstadosAceptacion.Contains(string.Join(",", Estados.Key)))
                    {
                        SentenciaIF += "if (Contador != 0 )\n{\nContador--;\n}\n Estado = 0 ; \n";

                    }
                    else
                    {
                        SentenciaIF += "Error=true; \n  ";
                    }
                    SentenciaIF += "}\n";

                    ListaIfCase.Add(SentenciaIF);

                    DiccCase.Add(contador, ListaIfCase);

                }
                SentenciaIF = string.Empty;
                contador++;

            }
            #endregion

            #region Escribir Case

            var CaseEstados = string.Empty;

            CaseEstados += "switch (Estado) \n";

            CaseEstados += "{ \n";

             

            foreach (var IfCase in DiccCase)
            {
                CaseEstados += $"case {IfCase.Key} : \n ";

                foreach (var SentenciasdelCase in IfCase.Value)
                {
                    CaseEstados += $"{SentenciasdelCase}";
                }

                CaseEstados += "\n break; \n ";


            }
            CaseEstados += "} \n";


            #endregion
             
            #region EstructuraProgram
            var EstructuraProgramInicial = string.Empty;

            EstructuraProgramInicial += "using System; \nusing System.Collections.Generic; \nusing System.Linq; \nusing System.Text;\nusing System.Threading.Tasks; \n";

            EstructuraProgramInicial += "namespace Analizador \n \t { \n";

            EstructuraProgramInicial += " \t\t class Program \n \t\t\t{ \n ";

            EstructuraProgramInicial += "\t\t\t\tstatic void Main(string[] args) \n \t\t\t\t\t{ \n ";


            var EstructuraProgramFinal = string.Empty;

            EstructuraProgramFinal += "  \n \t\t\t\t} \n \t\t\t}\n }\n";

            #endregion

            

            #region CicloWhile y lectura
            var Lectura = string.Empty;
            Lectura += "var cadena = string.Empty;\n";
            Lectura += " while (!cadena.Equals(\"\\n\"))\n {\n";
            Lectura += "Console.WriteLine(\"Ingrese la cadena a validar\"); \n";
            Lectura += "cadena = Console.ReadLine();\n";
            Lectura += "MetodosEstaticos TokensCadenaEntrada = new MetodosEstaticos();\n";
            
            var diccSetsListas = GeneradorPrograma.Data.Instance.DiccionarioSetsConsusListas;

            

            if (diccSetsListas.Count != 0)
            {
                Lectura += $"var diccSets =new Dictionary<string, List<string>>();  \n";
                foreach (var Sets in diccSetsListas)
                {
                    Lectura += $"var {Sets.Key}  = new List <string>();  \n";
                    foreach (var valores in Sets.Value)
                    {
                        Lectura += $"{Sets.Key}.Add(\"{valores}\");\n";
                    }
                    Lectura += $"diccSets.Add(\"{Sets.Key}\",{Sets.Key} );  \n";
                }
            }
            var ListaTokenReservadas = Data.Instance.TokensReservada;


            if (ListaTokenReservadas.Count != 0)
            {
                Lectura += "var ListaParaTokenizar = new List <string>(); \n";

                foreach (var item in ListaTokenReservadas)
                {
                    Lectura += $"ListaParaTokenizar.Add(\"{item}\") ; \n";
                }
            }

            Lectura += "var ColaTokens = TokensCadenaEntrada.Tokenizar(cadena,ListaParaTokenizar);\n";

            var Tokens = GeneradorPrograma.Data.Instance.DiccionarioTokensReservadas;

            Lectura += " var Tokens = new Dictionary<string, string>(); \n";

            foreach (var item in Tokens)
            {
                Lectura += $"Tokens.Add(\"{item.Key}\",\"{item.Value}\");  \n";
            }
             

            Lectura += "var CadenaSinEspacios = cadena.Replace(\" \", \"\");\n";
            Lectura += "var NuevaCadena = Encoding.ASCII.GetBytes(CadenaSinEspacios);\n";
            Lectura += "int Estado = 0;\nint Contador = 0;\n bool Error = false;\n";
            Lectura += "while(Contador < NuevaCadena.Length && Error == false)\n { \n";

            var LecturaFinal = string.Empty;
            LecturaFinal += "Contador++;\n}\n";
            LecturaFinal += "if (Error == true) \n { \n Console.WriteLine(\"Cadena No Aceptada\");\n }\n else \n { \n Console.WriteLine(\" Cadena Aceptada\");\n";
            LecturaFinal += " var Mostrar = TokensCadenaEntrada.MostrarTokens(ColaTokens,Tokens,diccSets);\n ";

            LecturaFinal += " foreach (var item in Mostrar)\n {\n";

            LecturaFinal += "Console.WriteLine(item);\n }\n} \n Console.ReadKey();\n} ";


            #endregion

            string PathDebug = AppDomain.CurrentDomain.BaseDirectory;

            if (File.Exists(Path.Combine(PathDebug, "Analizador", "Program.cs")))
            {
                File.Delete(Path.Combine(PathDebug, "Analizador", "Program.cs"));
            }

            

            using (var File = new FileStream(Path.Combine(PathDebug, "Analizador", "Program.cs"), FileMode.Create))
            {
                using (var write = new StreamWriter(File))
                {
                    write.Write(EstructuraProgramInicial);
                    write.Write(Lectura);
                    write.Write(CaseEstados);
                    write.Write(LecturaFinal);
                    write.Write(EstructuraProgramFinal);
                }

            }

            var DireccionActual = Path.Combine(Environment.CurrentDirectory, "Analizador");

            CopiarSolucion(DireccionActual,NewPath);
 





        }
        /// <summary>
        /// Metodo para poder borrar una carpeta
        /// </summary>
        /// <param name="path">Recibe la direccion de donde se quiere borrar la cadena</param>
        private static void BorrarDirectorio(string path)
        {
            try
            {
                var files = Directory.GetFiles(path);
                var dirs = Directory.GetDirectories(path);

                foreach (string file in files)
                {
                    File.SetAttributes(file, FileAttributes.Normal);
                    File.Delete(file);
                }

                foreach (string dir in dirs)
                {
                    BorrarDirectorio(dir);
                }

                Directory.Delete(path, false);

            }
            catch (Exception)
            {
              
                
            }
        }

        /// <summary>
        /// Metodo para poder copiar la solucion generica en la sulucion que desee el usuario
        /// </summary>
        /// <param name="DireccionActual">Direccion de donde se cuencuenta la solucion generica</param>
        /// <param name="DireccionNueva">La nueva direccion donde se va copiar la solucion</param>
        private void CopiarSolucion(string DireccionActual, string DireccionNueva)
        {
            var Directorio = Path.Combine(DireccionNueva, "AnalizerProgram");
            if (!Directory.Exists(Directorio))
            {
                Directory.CreateDirectory(Directorio);
            }
            else
            {
                BorrarDirectorio(Directorio);
                Directory.CreateDirectory(Directorio);
            }
            try
            {
                foreach (string dir in Directory.GetDirectories(DireccionActual, "*", SearchOption.AllDirectories))
                {
                    Directory.CreateDirectory (Path.Combine(Directorio, dir.Substring(DireccionActual.Length + 1)));
               
                }
                foreach (string file_name in System.IO.Directory.GetFiles(DireccionActual, "*", System.IO.SearchOption.AllDirectories))
                {
                    System.IO.File.Copy(file_name, System.IO.Path.Combine(Directorio, file_name.Substring(DireccionActual.Length + 1)));
                }

            }
            catch (Exception)
            {
 
            }

        }
         

        /// <summary>
        /// Metodo para recorrer los estados y calcular cuales son de acetacion
        /// </summary>
        /// <param name="estados">El diccionario de estados</param>
        /// <param name="id_aceptacion">el caracter que es de aceptacion</param>
        /// <returns>una lista de todos los estados y otra donde estan dsolo los estados de aceptaccion</returns>

        private (List<string>, List<string>) RecorrerEstados(Dictionary<List<int>, Dictionary<string, List<int>>> estados, int id_aceptacion)
        {
            var ListaEstados = new List<string>();

            var ListaEstadosAceptacion = new List<string>();

            foreach (var Estados in estados)
            {
                var ListaEstado = Estados.Key;
                if (ListaEstado.Contains(id_aceptacion))
                {
                    ListaEstadosAceptacion.Add(string.Join(",", ListaEstado));
                }

                ListaEstados.Add(string.Join(",", ListaEstado));

            }
            return (ListaEstados, ListaEstadosAceptacion);

        }

        public int[,] CrearMatriz(List<string> ListaEstados,  Dictionary<List<int>, Dictionary<string, List<int>>> Estados, List<string> Terminales)
        {
            var Matriz = new int[Estados.Count, Terminales.Count + 1];

            int fila = 0;

            foreach (var Estado in Estados)
            {
                int columan = 0;

                Matriz[fila, columan] = ListaEstados.IndexOf(string.Join(",", Estado.Key));

                columan++;

                foreach (var DefinicionEstado in Estado.Value.Values)
                {
                    if (DefinicionEstado.Count != 0)
                    {
                        Matriz[fila, columan] = ListaEstados.IndexOf(string.Join(",", DefinicionEstado));
                    }
                    columan++;
 

                }
                fila++;
            }

            return Matriz;

        }




    }
}

