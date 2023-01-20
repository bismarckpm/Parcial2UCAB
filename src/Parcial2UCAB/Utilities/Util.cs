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
            // Comprobamos que la palabra no sea nula o vacia
            if (string.IsNullOrEmpty(palabra) || string.IsNullOrWhiteSpace(palabra))
                return string.Empty;


            // Insertamos en la posicion limite un salto de linea
            string palabraAjustada = palabra.Insert(palabra.Length, "\n");

            // Removemos todos los espacios en blanco 
            // al inicio y al final de cada linea
            string[] lineas = palabraAjustada.Split("\n");

            foreach (string linea in lineas)
                if (linea.Length > 0) palabraAjustada = palabraAjustada.Replace(linea, linea.Trim());

            return palabraAjustada;
        }
    }
}
