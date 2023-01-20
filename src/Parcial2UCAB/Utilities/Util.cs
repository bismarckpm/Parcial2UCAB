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

            palabraajustada = palabra + "\n";

            palabraajustada = ObtenePalabraEnvueltaSinEspaciosBlancoInicioLinea(palabraajustada);

            return palabraajustada;
        }


        private static string ObtenePalabraEnvueltaSinEspaciosBlancoInicioLinea(string palabraajustada)
        {
            var _palabraajustada = palabraajustada;
            var contadorEspacios = 0;
            int contadorSalida;

            for (contadorSalida = 0; contadorSalida < palabraajustada.Length; contadorSalida++)

            {
                if (char.IsWhiteSpace(palabraajustada[contadorSalida]))
                {
                    contadorEspacios++;
                }
                else
                    break;
                _palabraajustada = RemoverEspaciosEnBlancoPalabraAjustada(palabraajustada, contadorSalida, contadorEspacios);

                contadorEspacios = 0;
            }

            return _palabraajustada;
        }


        private static string RemoverEspaciosEnBlancoPalabraAjustada(string palabraajustada, int contadorSalida, int contadorEspacios)
        {
            return palabraajustada.Remove(contadorSalida, contadorEspacios);
        }


       
    }
}
