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
            var actualCount = 0;
            var palabraajustada = string.Empty;
            var tamanopalabra = palabra.Length;

            if (palabra == "\n") return palabra;

            if ((string.IsNullOrEmpty(palabra)) || (string.IsNullOrWhiteSpace(palabra))) return string.Empty;

            foreach (var caracter in palabra)
            {
                palabraajustada = palabraajustada + Convert.ToString(caracter);

                if ( char.IsWhiteSpace(caracter) && (caracter == '\n')) continue;

                if (caracter.ToString(CultureInfo.InvariantCulture) == "\n") continue;

                actualCount++;

                if (actualCount == tamanopalabra)
                    palabraajustada += "\n";
            }

            palabraajustada = ObtenerPalabraEnvuelta(palabraajustada);

            return palabraajustada;
        }

        #region Metodos Privados

        private static string ObtenerPalabraEnvuelta(string palabraajustada)
        {
            var _palabraajustada = palabraajustada;
            var contadorEspacios = 0;

            for (var contadorSalida = 0; contadorSalida < palabraajustada.Length; contadorSalida++)
            {
                if (palabraajustada[contadorSalida].ToString(CultureInfo.InvariantCulture) == "\n")
                    for (var inCounter = contadorSalida + 1; inCounter < palabraajustada.Length; inCounter++)
                    {
                        if (char.IsWhiteSpace(palabraajustada[inCounter]))
                            contadorEspacios++;
                        else
                            break;
                    }

                if (contadorEspacios <= 0) continue;

                _palabraajustada = palabraajustada.Remove(contadorSalida + 1, contadorEspacios);

                contadorEspacios = 0;
            }

            return _palabraajustada;
        }

        #endregion
    }
}
