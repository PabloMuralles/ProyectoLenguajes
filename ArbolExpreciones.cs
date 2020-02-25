using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;


namespace Proyecto_Lenguajes
{
    class ArbolExpreciones
    {

        static string ExprecionRegularSets = string.Empty;

        List<string> SimbolosTerminales = new List<string>();
        List<string> Operadores = new List<string>();
        List<string> TokensExpresionSets = new List<string>();
        Stack<Nodo> S = new Stack<Nodo>();
        Stack<string> T = new Stack<string>();
                           
        public void ConvertirExprecionaTokens(string Cadena)
        {
            for (int i = 0; i < Cadena.Length; i++)
            {
                TokensExpresionSets.Add(ExprecionRegularSets.Substring(i, 1));
            }
        }
        
        
        public  void InsertarExprecionRegular()
        {
            foreach (var item in TokensExpresionSets)
            {
                Insertar_Arbol_Expreciones(item);
            }
           
             

        }

        public void Crear_st_op()
        {
            Operadores.Add("*");
            Operadores.Add("+");
            Operadores.Add("?");
            Operadores.Add(".");
            Operadores.Add("|");

            SimbolosTerminales.Add("ID");
        }
       
        

        

        public void Insertar_Arbol_Expreciones(string TokenExpresionRegular)
        {
            if (SimbolosTerminales.Contains(TokenExpresionRegular))
            {
                Nodo NodoToken = new Nodo(TokenExpresionRegular);
                S.Push(NodoToken);
            }
            if (TokenExpresionRegular == "(")
            {
                T.Push(TokenExpresionRegular);
            }
            if (TokenExpresionRegular == ")")
            {
                while (T.Count > 0 && (T.Pop() != "("))
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
            if (Operadores.Contains(TokenExpresionRegular))
            {
                if (TokenExpresionRegular=="+" || TokenExpresionRegular == "." || TokenExpresionRegular == "*" || TokenExpresionRegular == "?")
                {
                    Nodo TokenOp = new Nodo(TokenExpresionRegular);
                    // duda si esto es menor porque no tiene sentido
                    if (S.Count == 0)
                    {
                        throw new Exception("faltan operadandos");
                    }
                    TokenOp.Izquierdo = S.Pop();
                    S.Push(TokenOp);
                    if (true)
                    {

                    }
                   
                }
                else
                {
                    T.Push(TokenExpresionRegular);
                        
                }

            }

        }
        

    }
}
