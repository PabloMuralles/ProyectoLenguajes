﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Lenguajes.GeneradorPrograma
{
    class Codigo
    {


        public Codigo(Dictionary<List<int>, Dictionary<string, List<int>>> Estados_ , List<string> Terminales_, int SimboloAceptacion)
        {

            (List<string> ListaEstados, List<string> ListaEstadosAceptacion) = RecorrerEstados(Estados_, SimboloAceptacion);

            var Matriz = new int[ListaEstados.Count, Terminales_.Count];

            
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

        //public int[,] CrearMatriz(List<string> ListaEstados, List<string> ListaEstadosAceptacion, Dictionary<List<int>, Dictionary<string, List<int>>> Estados, List<string> Terminales)
        //{
        //    var Matriz = new int[ListaEstados.Count, Terminales.Count];

        //    for (int i = 0; i < ListaEstados.Count; i++)
        //    {
        //        for (int j = 0; j < Terminales.Count; j++)
        //        {
        //            Matriz[]
        //        }

        //    }


        //}


    }
}