using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;


namespace Parcial2UCAB.Utilities
{
    public static class Util
    {
        public static bool IsValidEmail(string email)
        {
            var regex = new Regex(@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
            return regex.IsMatch(email.Trim());
        }

        public static string Ajustar(string palabra)
        {
            if (EsSaltoLinea(palabra)) return palabra;

            if (EsNullOVacio(palabra)) return string.Empty;

            var palabraajustada = BorrarEspaciosIncioLinea(palabra);
            palabraajustada = palabra.Contains("\n") ? palabra : palabra.Insert(palabraajustada.Length, "\n");

            return palabraajustada;
        }

        private static string BorrarEspaciosIncioLinea(string palabraajustada)
        {
            var lineas = palabraajustada.Split("\n").ToList();
            var palabraAjustada = lineas[0];
            for (var i= 1; i<lineas.Count; i++)
            {
                palabraAjustada += (i < lineas.Count - 1) ? "\n" + lineas[i] : "\n" + lineas[i].TrimStart();
            }
            return palabraAjustada;
        }

        private static bool EsSaltoLinea(string palabra)
        {
            return palabra == "\n";
        }

        private static bool EsNullOVacio(string palabra)
        {
            return string.IsNullOrWhiteSpace(palabra);
        }
    }
}