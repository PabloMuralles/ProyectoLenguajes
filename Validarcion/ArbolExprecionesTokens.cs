﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Lenguajes.Validacion
{
    class ArbolExprecionesTokens
    {
        // Variable que contiene la exprecion regular
        string ExprecionRegularSets = @"(a.=.(((('.t.'|'.t.'.(..).'.t.').(\+.('.t.'|'.t.'.(..).'.t.')))*)|((C.H.R.\(.a.\).(..).C.H.R.\(.a.\)).(\+.((C.H.R.\(.a.\).(..).C.H.R.\(.a.\))))*))).#";

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

        // lista donde se va almacenar el texto a evaluar en el arbol
        private List<string> Texto_a_Evaluar = new List<string>();

        private Nodo Arbol;

        List<Nodo> ContenidoArbol = new List<Nodo>();
         
        // constructor del arbol de expreciones
        public ArbolExprecionesTokens()
        {

            ConvertirExprecionaTokens(ExprecionRegularSets);
            Crear_st_op();
            Insertar_Arbol_Expreciones(TokensExpresionSets);
            RecorridoInorden(Arbol);


        }
         
        /*Metodo para poder tokenizar la exprecion regular es decir separar por caracteres la exprecion regular*/
        public void ConvertirExprecionaTokens(string Cadena)
        {
            for (int i = 0; i < Cadena.Length; i++)
            {
                if ((Cadena.Substring(i, 1) == @"\" && Cadena.Substring(i + 1, 1) == "+") || (Cadena.Substring(i, 1) == @"." && Cadena.Substring(i + 1, 1) == ".") ||
                    (Cadena.Substring(i, 1) == @"\" && Cadena.Substring(i + 1, 1) == "(") || (Cadena.Substring(i, 1) == @"\" && Cadena.Substring(i + 1, 1) == ")"))
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

            SimbolosTerminales.Add("..");
            SimbolosTerminales.Add("t");
            SimbolosTerminales.Add(@"\+");
            SimbolosTerminales.Add("'");
            SimbolosTerminales.Add("#");
            SimbolosTerminales.Add(@"\(");
            SimbolosTerminales.Add(@"\)");
            SimbolosTerminales.Add("C");
            SimbolosTerminales.Add("H");
            SimbolosTerminales.Add("R");
            SimbolosTerminales.Add("a");
            SimbolosTerminales.Add("=");

            // for para agregar simbolos terminales quitando los operadores
            //for (int i = 0; i < 256; i++)
            //{
            //    var Simbolo = ("" + (char)i);
            //    if (Simbolo == "*"  || Simbolo == "+" || Simbolo == "?" || Simbolo == "." || Simbolo == "|" || Simbolo =="(" || Simbolo == ")")
            //    {


            //    }
            //    else
            //    {
            //        SimbolosTerminales.Add(Simbolo);
            //    }
            //}

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
                    NodoToken.Padre = null;
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
                        Temp.Padre = null;
                        Temp.Derecho = S.Pop();
                        Temp.Derecho.Padre = Temp.Data;
                        Temp.Izquierdo = S.Pop();
                        Temp.Izquierdo.Padre = Temp.Data;
                        S.Push(Temp);

                    }
                    T.Pop();

                }
                else if (Operadores.Contains(TokenEvaluar))
                {
                    if (TokenEvaluar == "+" || TokenEvaluar == "?" || TokenEvaluar == "*")
                    {
                        Nodo TokenOp = new Nodo(TokenEvaluar);
                        TokenOp.Padre = null;

                        if (S.Count < 0)
                        {
                            throw new Exception("faltan operadandos");
                        }
                        TokenOp.Izquierdo = S.Pop();
                        TokenOp.Izquierdo.Padre = TokenOp.Data;
                        S.Push(TokenOp);
                    }
                    else if (T.Count != 0 && T.Peek() != "(" && (VerificarPrecedencia(TokenEvaluar, T.Peek()) == true))
                    {
                        Nodo Temp = new Nodo(T.Pop());
                        Temp.Padre = null;
                        if (S.Count < 2)
                        {
                            throw new Exception("Faltan operandos");
                        }
                        // duda sobre este else preguntas
                        else
                        {
                            Temp.Derecho = S.Pop();
                            Temp.Derecho.Padre = Temp.Data;
                            Temp.Izquierdo = S.Pop();
                            Temp.Izquierdo.Padre = Temp.Data;
                            S.Push(Temp);
                        }
                    }

                    if (TokenEvaluar == "." || TokenEvaluar == "|")
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
                Temp.Padre = null;
                Temp.Derecho = S.Pop();
                Temp.Derecho.Padre = Temp.Data;
                Temp.Izquierdo = S.Pop();
                Temp.Izquierdo.Padre = Temp.Data;
                S.Push(Temp);

                if (S.Count != 1)
                {
                    throw new Exception("Faltan operandos");
                }

            }
            Arbol = S.Pop();
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

        public void RecorridoInorden(Nodo raiz)
        {

            if (raiz != null)
            {
                RecorridoInorden(raiz.Izquierdo);
                ContenidoArbol.Add(raiz);
                RecorridoInorden(raiz.Derecho);

            }

        }

         



        
    }
}
