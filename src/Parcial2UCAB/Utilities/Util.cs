using Microsoft.VisualBasic;
using System;
using System.Globalization;
using System.Linq;
using System.Reflection;
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
            if (SiContieneEspacioONull(palabra)) return string.Empty;
            palabra = Regex.Replace(palabra, @"\n", "");
            palabra = Regex.Replace(palabra, @"\s", "");
            return palabra;
        }

        private static bool SiContieneEspacioONull(string palabra)
        {
            return (palabra == "\n" || string.IsNullOrEmpty(palabra)) || (string.IsNullOrWhiteSpace(palabra));
        }
    }
}
