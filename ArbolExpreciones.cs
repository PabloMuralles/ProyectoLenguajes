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
        // Variable que contiene la exprecion regular
        static string ExprecionRegularSets = string.Empty;

        // Lista que contiene los simbolos terminales de la exprecion regular
        List<string> SimbolosTerminales = new List<string>();

        //Lista que contiene los operadores de las expreciones regulares
        List<string> Operadores = new List<string>();

        // Lista que contiene la exprecion regular tokenizada
        List<string> TokensExpresionSets = new List<string>();

        // Pila de nodos para poder almacenar los arboles 
        Stack<Nodo> S = new Stack<Nodo>();

        //Pila de string que almacena los tokens
        Stack<string> T = new Stack<string>();

        /*Metodo para poder tokenizar la exprecion regular es decir separar por caracteres la exprecion regular*/                   
        public void ConvertirExprecionaTokens(string Cadena)
        {
            for (int i = 0; i < Cadena.Length; i++)
            {
                TokensExpresionSets.Add(ExprecionRegularSets.Substring(i, 1));
            }
        }
        
        // Metodo que sirve para ir insertando los datos al metodo de creacion de arbol para irlo creando
        public  void InsertarExprecionRegular()
        {
             
            foreach (var item in TokensExpresionSets)
            {
                Insertar_Arbol_Expreciones(item);
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

            SimbolosTerminales.Add("ID");
        }



        #region ARBOL DE EXPRECIONES
        // Metodo para poder ir creando el arbol de expreciones
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
                if (TokenExpresionRegular == "+" || TokenExpresionRegular == "?" || TokenExpresionRegular == "*" )
                {
                    Nodo TokenOp = new Nodo(TokenExpresionRegular);
                   
                    if (S.Count < 0)
                    {
                        throw new Exception("faltan operadandos");
                    }
                    TokenOp.Izquierdo = S.Pop();
                    S.Push(TokenOp);  
                }
                else if (T.Count != 0 && T.Peek()!="(" && (VerificarPrecedencia(TokenExpresionRegular,T.Peek()) == true))
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

                if (TokenExpresionRegular != "*"|| TokenExpresionRegular != ".")
                {
                    T.Push(TokenExpresionRegular);
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
