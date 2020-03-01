using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;


namespace Proyecto_Lenguajes
{
    class ArbolExprecionesSets
    {

        // Variable que contiene la exprecion regular
        string ExprecionRegularSets = @"((('t'|'t'..'t').(\+.('t'|'t'..'t')))*).#";
        
        //Lista que contiene los simbolos terminales de la exprecion regular
        List<string> SimbolosTerminales = new List<string>();

        //Lista que contiene los operadores de las expreciones regulares
        List<string> Operadores = new List<string>();

        //Cola que contiene la exprecion regular tokenizada
        Queue<string> TokensExpresionSets = new Queue<string>();

        // Pila de nodos para poder almacenar los arboles 
        Stack<Nodo> S = new Stack<Nodo>();

        //Pila de string que almacena los tokens
        Stack<string> T = new Stack<string>();

        private List<string> Texto_a_Evaluar = new List<string>();


        // constructor del arbol de expreciones
        public ArbolExprecionesSets( )
        {
            
            ConvertirExprecionaTokens(ExprecionRegularSets);
            Crear_st_op();
            Insertar_Arbol_Expreciones(TokensExpresionSets); 

            
        }

        

     

        /*Metodo para poder tokenizar la exprecion regular es decir separar por caracteres la exprecion regular*/
        public void ConvertirExprecionaTokens(string Cadena)
        {
            for (int i = 0; i < Cadena.Length; i++)
            {
                if ((Cadena.Substring(i, 1) == @"\" && Cadena.Substring(i + 1, 1) == "+") || (Cadena.Substring(i, 1) == @"." && Cadena.Substring(i + 1, 1) == "."))
                {
                    TokensExpresionSets.Enqueue(Cadena.Substring(i, 2));
                    i = i + 1;
                }
                else 
                {  
                    TokensExpresionSets.Enqueue(Cadena.Substring(i, 1));
                }


            }
        }

        //Metodo para poder inicializar los operador y simbolos terminales
        public void Crear_st_op()
        {
            
            
            Operadores.Add("*");
            Operadores.Add("+");
            Operadores.Add("?");
            Operadores.Add(".");
            Operadores.Add("|");

            SimbolosTerminales.Add("n");
            SimbolosTerminales.Add("t");
            SimbolosTerminales.Add(@"\+");
            SimbolosTerminales.Add("..");
            SimbolosTerminales.Add("'");
            SimbolosTerminales.Add("=");

            // for para agregar simbolos terminales quitando los operadores
            for (int i = 0; i < 256; i++)
            {
                var Simbolo = ("" + (char)i);
                if (Simbolo == "*"  || Simbolo == "+" || Simbolo == "?" || Simbolo == "." || Simbolo == "|" || Simbolo =="(" || Simbolo == ")")
                {


                }
                else
                {
                    SimbolosTerminales.Add(Simbolo);
                }
            }

        }



        #region ARBOL DE EXPRECIONES
        // Metodo para poder ir creando el arbol de expreciones
        public void Insertar_Arbol_Expreciones(Queue<string> TokenExpresionRegular)
        {
            // corregir error del la variable
            while (TokenExpresionRegular.Count != 0)
            {
                string TokenEvaluar = TokensExpresionSets.Dequeue();
                if (SimbolosTerminales.Contains(TokenEvaluar))
                {
                    Nodo NodoToken = new Nodo(TokenEvaluar);
                    S.Push(NodoToken);
                }
                else if (TokenEvaluar == "(")
                {
                    T.Push(TokenEvaluar);
                }
                else if (TokenEvaluar == ")")
                {
                    while (T.Count > 0 && (T.Peek() != "("))
                    {
                        if (T.Count == 0)
                        {
                            throw new Exception("faltan operandos");
                        }
                        if (S.Count < 2)
                        {
                            throw new Exception("faltan operadandos");
                        }
                        Nodo Temp = new Nodo(T.Pop());
                        Temp.Derecho = S.Pop();
                        Temp.Izquierdo = S.Pop();
                        S.Push(Temp);
                         
                    }
                    T.Pop();

                }
                else if (Operadores.Contains(TokenEvaluar))
                {
                    if (TokenEvaluar == "+" || TokenEvaluar == "?" || TokenEvaluar == "*" )
                    {
                        Nodo TokenOp = new Nodo(TokenEvaluar);

                        if (S.Count < 0)
                        {
                            throw new Exception("faltan operadandos");
                        }
                        TokenOp.Izquierdo = S.Pop();
                        S.Push(TokenOp);
                    }
                    else if (T.Count != 0 && T.Peek() != "(" && (VerificarPrecedencia(TokenEvaluar, T.Peek()) == true))
                    {
                        Nodo Temp = new Nodo(T.Pop());
                        if (S.Count < 2)
                        {
                            throw new Exception("Faltan operandos");
                        }
                        // duda sobre este else preguntas
                        else
                        {
                            Temp.Derecho = S.Pop();
                            Temp.Izquierdo = S.Pop();
                            S.Push(Temp);
                        } 
                    }

                    if (TokenEvaluar == "*" || TokenEvaluar == "." || TokenEvaluar == "|")
                    {
                        T.Push(TokenEvaluar);
                    } 
                }
                else
                {
                    throw new Exception("Token no reconocido");
                }
            }


            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////


            while (T.Count > 0)
            { 
                if (T.Peek() == "(")
                {
                    throw new Exception("Faltan operandos");
                }
                if (S.Count < 2)
                {
                    throw new Exception("Faltan operandos");
                }

                Nodo Temp = new Nodo(T.Pop());
                Temp.Derecho = S.Pop();
                Temp.Izquierdo = S.Pop();
                S.Push(Temp);
                
                if (S.Count != 1)
                {
                    throw new Exception("Faltan operandos");
                } 

            } 
        }
#endregion

        // Metodo para verficar el nivel de precedencia de un operador
        // Devuelve un verdadero si el token es menor o igual en precedencial al operador ingresado
        public bool VerificarPrecedencia(string TokenPrecedencia, string UltimoOperadorLista)
        {
            int IndexToken = Operadores.FindIndex(x => x.Equals(TokenPrecedencia));

            int IndexUltimo = Operadores.FindIndex(x => x.Equals(TokenPrecedencia));

            return IndexToken >= IndexUltimo;
        }


    }
}
