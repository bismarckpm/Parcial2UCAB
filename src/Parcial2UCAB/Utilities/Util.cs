using System;
using System.Globalization;
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
            palabra = SiContieneEspacio(palabra);
            palabra = SiContieneLinea(palabra);
            return palabra;
        }
        private static string SiContieneEspacio(string palabra)
        {
            if (palabra.Contains(" ")) return palabra.Replace(" ", "");
            return palabra;
        }
        private static string SiContieneLinea(string palabra)
        {
            if (palabra.Contains("\n")) return palabra.Replace("\n", "");
            return palabra;
        }
    }
}
