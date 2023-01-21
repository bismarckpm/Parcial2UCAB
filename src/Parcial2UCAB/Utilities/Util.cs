using System;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Text;

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

            if (ConNuevaLinea(palabra)) return palabra;

            if (ConEspacioONull(palabra)) return string.Empty;

            palabraajustada = ContadorSaltoLineas(palabra);

            palabraajustada = ObtenePalabraEnvueltaSinEspaciosBlancoInicioLinea(palabraajustada);

            return palabraajustada;
        }

        private static string ContadorSaltoLineas(string palabra)
        {
            var actualCount = 0;
            var resultado = string.Empty;
            
            foreach (var caracter in palabra)
            {
                resultado = resultado + Convert.ToString(caracter);

                if (ConEspacioONuevaLinea(caracter)) continue;

                if (ConNuevaLinea(caracter.ToString(CultureInfo.InvariantCulture))) continue;

                actualCount++;

                if (actualCount == palabra.Length)
                    resultado.Insert(resultado.Length,Environment.NewLine) ;
            }
            return resultado;
        }

        private static string ObtenePalabraEnvueltaSinEspaciosBlancoInicioLinea(string palabraajustada)
        {
            var _palabraajustada = palabraajustada;
            var contadorEspacios = 0;

            for (var contadorSalida = 0; contadorSalida < palabraajustada.Length; contadorSalida++)
            {
                if (ConNuevaLinea(palabraajustada[contadorSalida].ToString(CultureInfo.InvariantCulture)))
                    contadorEspacios = ContadorEspacio(palabraajustada, contadorSalida);

                if (contadorEspacios <= 0) continue;

                _palabraajustada = RemoverEspaciosEnBlancoPalabraAjustada(palabraajustada, contadorSalida, contadorEspacios);

                contadorEspacios = 0;
            }

            return _palabraajustada;
        }

        private static int ContadorEspacio(string palabraajustada, int contadorSalida)
        {
             var resultado = 0;
                    for (var inCounter = contadorSalida + 1; inCounter < palabraajustada.Length; inCounter++)
                    {
                        if (char.IsWhiteSpace(palabraajustada[inCounter]))
                            resultado++;
                        else
                            break;
                    }
                    return resultado;
        }


        private static string RemoverEspaciosEnBlancoPalabraAjustada(string palabraajustada, int contadorSalida, int contadorEspacios)
        {
            return palabraajustada.Remove(contadorSalida + 1, contadorEspacios);
        }

        private static bool ConNuevaLinea(string palabra)
        {
            return palabra == Environment.NewLine;
        }

        private static bool ConEspacioONull(string palabra)
        {
            return (string.IsNullOrEmpty(palabra)) || (string.IsNullOrWhiteSpace(palabra));
        }

        private static bool ConEspacioONuevaLinea(char wrd)
        {
            return char.IsWhiteSpace(wrd) && (wrd == '\n');
        }
    }
}
