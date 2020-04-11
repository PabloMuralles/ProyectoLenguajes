using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Lenguajes.FirstLastsFollows
{
   
        public static class DictionaryExtensions
        {
            // Esta clase ya no se utilizo pero podra sevir para cualquier proyecto futuro los valores del diccionario los vuelve nulos
            public static Dictionary<K, V> ResetValues<K, V>(this Dictionary<K, V> dic)
            {
                dic.Keys.ToList().ForEach(x => dic[x] = default(V));
                return dic;
            }

            public static Dictionary<K, V> ResetValuesWithNewDictionary<K, V>(this Dictionary<K, V> dic)
            {
                return dic.ToDictionary(x => x.Key, x => default(V), dic.Comparer);
            }

        }
    
}
