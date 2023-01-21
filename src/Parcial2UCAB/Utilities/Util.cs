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
            var palabraajustada = string.Empty;

            switch (palabra)
            {
                case "\n": return palabra;
                case null: return string.Empty;
                case "": return string.Empty;
                case " ": return string.Empty;
                case string:
                    foreach (var caracter in palabra)
                    {
                        if (char.IsWhiteSpace(caracter) || caracter.ToString(CultureInfo.InvariantCulture) == "\n")
                            continue;
                        palabraajustada = palabraajustada + Convert.ToString(caracter);

                    }
                    return palabraajustada += "\n";    
            }
        }
    }
}
