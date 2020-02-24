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

        string[] TokensExpresionSets = new string[ExprecionRegularSets.Length];
                           
        public void ConvertirExprecionaTokens(string Cadena)
        {
            for (int i = 0; i < Cadena.Length; i++)
            {
                TokensExpresionSets[i] = ExprecionRegularSets.Substring(i, 1);
            }
        }
        
        
        public  void InsertarExprecionRegular()
        {
            for (int i = 0; i < TokensExpresionSets.Length; i++)
            {
                Insertar(TokensExpresionSets[i]);
            }

        }
       
        
        Dictionary<int, string> st = new Dictionary<int, string>();
        
        Dictionary<int, string> op = new Dictionary<int, string>();

        List<string> st = new str
        //public void CrearDiccionario()
        //{ 
            
        //    op.Add(1, "+");
        //    op.Add(3, "|");
        //    op.Add(4, "?");
        //    op.Add(5, "*");
          

        //    st.Add(1, "ID");

        //}

        public void Insertar(string token)
        {
            for (int i = 0; i < TokensExpresionSets.Length; i++)
            {
                if (token)
                {

                }
            }

        }
        

    }
}
