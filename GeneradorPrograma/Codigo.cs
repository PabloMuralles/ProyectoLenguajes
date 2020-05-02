using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.CSharp;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Microsoft.VisualBasic;
using System.Globalization;
using System.CodeDom.Compiler;



namespace Proyecto_Lenguajes.GeneradorPrograma
{
    class Codigo
    {
      
        public Codigo(Dictionary<List<int>, Dictionary<string, List<int>>> Estados_ , List<string> Terminales_, int SimboloAceptacion)
        { 
            (List<string> ListaEstados, List<string> ListaEstadosAceptacion) = RecorrerEstados(Estados_, SimboloAceptacion);

            //var Matriz = CrearMatriz(ListaEstados, Estados_, Terminales_);

            #region Escribir Ifs Case
            var DiccSet = Data.Instance.DiccionarioSets;

            var Idset = Data.Instance.IdsSets;

            var DiccCase = new Dictionary<int, List<string>>();

            int contador = 0;
            foreach ( var Estados  in Estados_)
            {
                var ListaIfCase = new List<string>();
                var SentenciaIF = string.Empty;
                foreach (var Transiciones in Estados.Value)
                {
                    if (Transiciones.Value.Count != 0 )
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

                                    SentenciaIF += $"if(NuevaCadena[Contador] >= {Convert.ToInt32(Convert.ToChar(int.Parse(Rango[0])))} && NuevaCadena[Contador] <= {Convert.ToInt32(Convert.ToChar(int.Parse(Rango[1])))} ) \n ";

                                    SentenciaIF += "{\n";
                                    SentenciaIF+=$"Estado = {ListaEstados.IndexOf(string.Join(",",Transiciones.Value))}  ;\n";
                                    SentenciaIF += "}";
                                    ListaIfCase.Add(SentenciaIF);
                                    SentenciaIF = string.Empty;
                                    
                                }
                                else
                                {
                                    if (ListaIfCase.Count != 0)
                                    {
                                        SentenciaIF += "else  ";
                                    }
                                    SentenciaIF += $"if(NuevaCadena[Contador] == {Convert.ToInt32(Convert.ToChar(DividirDefinicion[0]))} ) \n ";
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
                                    SentenciaIF += "else  " ;
                                }

                                for (int i = 0; i < DividirDefinicion.Length; i++)
                                {

                                    if (DividirDefinicion[i].Contains("~"))
                                    {
                                        var Rango = DividirDefinicion[i].Split('~');
                                        if (i == 0)
                                        {
                                             
                                            SentenciaIF += $"if(NuevaCadena[Contador] >= {Convert.ToInt32(Convert.ToChar(Rango[0]))} && NuevaCadena[Contador] <= {Convert.ToInt32(Convert.ToChar(Rango[1]))} ";
                                             
                                        }
                                        else
                                        {
                                            var joa = (Convert.ToChar(Rango[0]));
                                            SentenciaIF += $"|| NuevaCadena[Contador] >= {Convert.ToInt32(Convert.ToChar(Rango[0]))} && NuevaCadena[Contador] <= {Convert.ToInt32(Convert.ToChar(Rango[1]))}  ";
                                        }

                                    }
                                    else
                                    {
                                        if (i == 0)
                                        {
                                             

                                            SentenciaIF += $"if(NuevaCadena[Contador] == {Convert.ToInt32(Convert.ToChar(DividirDefinicion[0]))} ";

                                        }
                                        else
                                        {
                                            var Rango = DividirDefinicion[0].Split('~');

                                            SentenciaIF += $"|| NuevaCadena[Contador] == {Convert.ToInt32(Convert.ToChar(DividirDefinicion[i]))}";

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
                            var NewKey = Key[1];
                         

                            SentenciaIF += $"if(NuevaCadena[Contador] == {Convert.ToInt32(Convert.ToChar(NewKey))} ) \n ";
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

                    if (ListaEstadosAceptacion.Contains(string.Join(",",Estados.Key)))
                    {
                        SentenciaIF += "Contador--;\n Estado = 0 ; \n";

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

            EstructuraProgramInicial += "namespace Analizador \n  { \n";

            EstructuraProgramInicial += "  class Program \n { \n ";

            EstructuraProgramInicial += "static void Main(string[] args) \n { \n ";


            var EstructuraProgramFinal = string.Empty;

            EstructuraProgramFinal += "  \n } \n }\n }\n";


            #endregion

           

            #region CicloWhile y lectura
            var Lectura = string.Empty;
            Lectura += "Console.WriteLine(\"Ingrese la cadena a validar\"); \n";
            Lectura += "var cadena = Console.ReadLine();\n";
            Lectura += "var CadenaSinEspacios = cadena.Replace(\" \", \"\");\n";
            Lectura += "var NuevaCadena = Encoding.ASCII.GetBytes(CadenaSinEspacios);\n";
            Lectura += "int Estado = 0;\nint Contador = 0;\n bool Error = false;\n";
            Lectura += "while(Contador < NuevaCadena.Length && Error == false)\n { \n";
            var LecturaFinal = string.Empty;
            LecturaFinal += "Contador++;\n}\n";
            LecturaFinal += "if (Error == true) \n { \n Console.WriteLine(\"No aceptada\");\n }\n else \n { \n Console.WriteLine(\" aceptada\");\n }\n Console.ReadKey();\n ";

            

            #endregion

            string PathDebug = AppDomain.CurrentDomain.BaseDirectory;

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

