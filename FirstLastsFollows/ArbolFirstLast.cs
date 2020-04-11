using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Proyecto_Lenguajes.FirstLastsFollows
{
    class ArbolFirstLast
    {
        // Variable que contiene la exprecion regular
        string ExpresionRegular = string.Empty;

        //Lista que contiene los simbolos terminales de la exprecion regular
        List<string> SimbolosTerminales = new List<string>();

        //Lista que contiene los operadores de las expreciones regulares
        List<string> Operadores = new List<string>();

        //Cola que contiene la exprecion regular tokenizada
        Queue<string> TokensExpresion = new Queue<string>();

        // lista donde se va almacenar el texto a evaluar en el arbol
        private List<string> Texto_a_Evaluar = new List<string>();
  

        Dictionary<string, int> Precedencia;

        // constructor del arbol de expreciones
        public ArbolFirstLast(string Expresion_, List<string> Terminales)
        {
             
            SimbolosTerminales = Terminales;
            SimbolosTerminales.Add("#");
            ExpresionRegular = "(" + Expresion_ + ")·#";
             
            Precedencia = new Dictionary<string, int> { { "+", 3 }, { "?", 3 }, { "*", 3 }, { "·", 2 }, { "|", 1 } };
            ConvertirExprecionaTokens();
            Crear_st_op();
            var Arbol = Insertar_Arbol_Expreciones(TokensExpresion);

            Tablas.Instance.Proceso(Arbol,Terminales,Expresion_);


        }

        /*Metodo para poder tokenizar la exprecion regular es decir separar por caracteres la exprecion regular*/
        public void ConvertirExprecionaTokens()
        {
            var ExpresionRegularDividada = ExpresionRegular.ToArray();

            var Analizador = string.Empty;

            var Nuevotoken = string.Empty;

            var ExisteComilla = false;

            var NuevoTokenComillas = string.Empty;

            var CasoEspecialComilla = false;

            for (int i = 0; i < ExpresionRegularDividada.Length; i++)
            {
                if (char.IsLetter(ExpresionRegularDividada[i]) && ExisteComilla == false)
                {
                    Nuevotoken += Convert.ToString(ExpresionRegularDividada[i]);
                    if (SimbolosTerminales.Contains(Nuevotoken))
                    {
                        TokensExpresion.Enqueue(Nuevotoken);
                        Nuevotoken = string.Empty;
                    }
                }
                else if (ExpresionRegularDividada[i] == '\'' || ExisteComilla == true)
                {

                    if (ExisteComilla == false)
                    {
                        NuevoTokenComillas += Convert.ToString(ExpresionRegularDividada[i]);
                        ExisteComilla = true;
                        if (ExpresionRegularDividada[i + 1] == '\'')
                        {
                            CasoEspecialComilla = true;
                        }

                    }
                    else
                    {
                        NuevoTokenComillas += Convert.ToString(ExpresionRegularDividada[i]);
                        
                        if (ExpresionRegularDividada[i] == '\'' && CasoEspecialComilla == false)
                        { 
                            TokensExpresion.Enqueue(NuevoTokenComillas);
                            ExisteComilla = false;
                            NuevoTokenComillas = string.Empty;
                        }
                        else if (CasoEspecialComilla == true)
                        {
                            CasoEspecialComilla = false;
                        }
                    }

                }
                else if (ExpresionRegularDividada[i] == '*' || ExpresionRegularDividada[i] == '?' || ExpresionRegularDividada[i] == '+' || ExpresionRegularDividada[i] == '|' || ExpresionRegularDividada[i] == '·' || ExpresionRegularDividada[i] == ')' || ExpresionRegularDividada[i] == '(' || ExpresionRegularDividada[i] == '#')
                {
                    TokensExpresion.Enqueue(Convert.ToString(ExpresionRegularDividada[i]));
                }
                
            }
        }

        //Metodo para poder inicializar los operador y simbolos terminales
        public void Crear_st_op()
        { 
            Operadores.Add("*");
            Operadores.Add("+");
            Operadores.Add("?");
            Operadores.Add("·");
            Operadores.Add("|");
        }

        #region ARBOL DE EXPRECIONES

        // Pila de nodos para poder almacenar los arboles 
        Stack<Nodo> S = new Stack<Nodo>();

        //Pila de string que almacena los tokens
        Stack<string> T = new Stack<string>();

        // Metodo para poder ir creando el arbol de expreciones
        public Nodo Insertar_Arbol_Expreciones(Queue<string> TokenExpresionRegular)
        {
            try
            {
                // corregir error del la variable
                while (TokenExpresionRegular.Count != 0)
                {
                    string TokenEvaluar = TokensExpresion.Dequeue();
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
                        else if (T.Count != 0)
                        {
                            while (T.Peek() != "(" && (VerificarPrecedencia(TokenEvaluar) == true))
                            {
                                Nodo Temp = new Nodo(T.Pop());
                                Temp.Padre = null;
                                if (S.Count < 2)
                                {
                                    throw new Exception("Faltan operandos");
                                }
                                else
                                {
                                    var prueba1 = VerificarPrecedencia(TokenEvaluar);
                                    Temp.Derecho = S.Pop();
                                    Temp.Derecho.Padre = Temp.Data;
                                    Temp.Izquierdo = S.Pop();
                                    Temp.Izquierdo.Padre = Temp.Data;
                                    S.Push(Temp);
                                }

                            }

                        }

                        if (TokenEvaluar == "·" || TokenEvaluar == "|")
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
                return S.Pop();
            }
            catch (Exception p )
            {

                MessageBox.Show(p.Message);

                return null;
            }
             
        }
        #endregion

        // Metodo para verficar el nivel de precedencia de un operador
        // Devuelve un verdadero si el token es menor o igual en precedencial al operador ingresado
        public bool VerificarPrecedencia(string TokenEvaluar)
        {

            Precedencia.TryGetValue(TokenEvaluar, out int TokenEvaluarValor);
            Precedencia.TryGetValue(T.Peek(), out int TokenCompararValor);
            if (TokenEvaluarValor <= TokenCompararValor)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


    }
}
