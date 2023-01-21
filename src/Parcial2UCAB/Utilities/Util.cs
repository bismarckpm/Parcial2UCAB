using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Parcial2UCAB.Utilities
{
    public static class Util
    {
        public static string Ajustar(string palabra)
        {
            var palabraajustada = string.Empty;

            if (ConNuevaLinea(palabra)) return palabra;

            if (ConEspacioONull(palabra)) return string.Empty;

            foreach (var caracter in palabra)
            {
                if (ConEspacioONuevaLinea(caracter)) continue;
                palabraajustada = palabraajustada + Convert.ToString(caracter);
            }

            return palabraajustada;
        }

        private static bool ConNuevaLinea(string palabra)
        {
            return palabra == "\n";
        }

        private static bool ConEspacioONull(string palabra)
        {
            return (string.IsNullOrEmpty(palabra)) || (string.IsNullOrWhiteSpace(palabra));
        }

        private static bool ConEspacioONuevaLinea(char wrd)
        {
            return char.IsWhiteSpace(wrd);
        }
    }
}
