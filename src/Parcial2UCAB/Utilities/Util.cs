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
            if (ConNuevaLinea(palabra)) return palabra;

            if (ConEspacioONull(palabra)) return string.Empty;

            var palabraa = ObtenerPalabraConSaltoDeLinea(palabra);            

            var palabraajustada = ObtenePalabraEnvueltaSinEspaciosBlancoInicioLinea(palabraa);

            return palabraajustada;
        }

        private static string ObtenerPalabraConSaltoDeLinea(string _palabra)
        {
            var actualCount = 0;
            var palabraajustada = string.Empty;
            var palabra = _palabra;
            foreach (var caracter in palabra)
            {
                palabraajustada = palabraajustada + Convert.ToString(caracter);

                if (ConEspacioONuevaLinea(caracter)) continue;

                if (ConNuevaLinea(caracter.ToString(CultureInfo.InvariantCulture))) continue;

                actualCount++;

                if (FinDePalabra(actualCount, palabra))
                    palabraajustada += "\n";
            }
            return palabraajustada;
        }

        private static bool FinDePalabra(int count, string palabra)
        {
            return (count == palabra.Length);         
        }

        private static string ObtenePalabraEnvueltaSinEspaciosBlancoInicioLinea(string palabraajustada)
        {
            var _palabraajustada = palabraajustada;
            var contadorEspacios = 0;
            for (var contadorSalida = 0; contadorSalida < palabraajustada.Length; contadorSalida++)
            {
                if (ConNuevaLinea(palabraajustada[contadorSalida].ToString(CultureInfo.InvariantCulture)))
                    contadorEspacios = ContadorEspacios(_palabraajustada, contadorSalida, contadorEspacios);    

                if (contadorEspacios <= 0) continue;

                _palabraajustada = RemoverEspaciosEnBlancoPalabraAjustada(palabraajustada, contadorSalida, contadorEspacios);
                contadorEspacios = 0;
            }
            return _palabraajustada;
        }

        private static int ContadorEspacios(string _palabraajustada, int contadorSalida, int contadorEspacios)
        {
            var palabraajustada = _palabraajustada;
            var _contadorEspacios = contadorEspacios;
            for (var inCounter = contadorSalida + 1; inCounter < palabraajustada.Length; inCounter++)
                    {
                        if (char.IsWhiteSpace(palabraajustada[inCounter]))
                            _contadorEspacios++;
                        else
                            break;
                    }
            return _contadorEspacios;
        }

        private static string RemoverEspaciosEnBlancoPalabraAjustada(string palabraajustada, int contadorSalida, int contadorEspacios)
        {
            return palabraajustada.Remove(contadorSalida + 1, contadorEspacios);
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
            return char.IsWhiteSpace(wrd) && (wrd == '\n');
        }
    }
}
