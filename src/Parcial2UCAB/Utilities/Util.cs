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

            if (ConNuevaLinea(palabra)) return palabra;

            if (ConEspacioONull(palabra)) return string.Empty;

            palabraajustada = ContadorDeCaracteres(palabra, palabraajustada);

            palabraajustada = ObtenePalabraEnvueltaSinEspaciosBlancoInicioLinea(palabraajustada);

            return palabraajustada;
        }

        //Extraer en un metodo el foreach del metodo Ajustar
        public static string ContadorDeCaracteres(string palabra, string palabrajustada)
        {
            var actualCount = 0;
            var _palabraajustada = palabrajustada;

            foreach (var caracter in palabra)
            {
                _palabraajustada = _palabraajustada + Convert.ToString(caracter);

                if (ConEspacioONuevaLinea(caracter)) continue;

                if (ConNuevaLinea(caracter.ToString(CultureInfo.InvariantCulture))) continue;

                actualCount++;
                _palabraajustada = TamanoDeLaPalabra(palabra, _palabraajustada, actualCount);
            }

            return _palabraajustada;
           
        }

        //Extraer en un metodo el If del metodo Contador De Caracteres
        public static string TamanoDeLaPalabra(string palabra, string palabrajustada, int actualCount)
        {
            var palabraajustada = palabrajustada;

            if (actualCount == palabra.Length)
                palabraajustada += "\n";

            return palabraajustada;
        }


        private static string ObtenePalabraEnvueltaSinEspaciosBlancoInicioLinea(string palabraajustada)
        {
            var _palabraajustada = palabraajustada;
            
            var contadorEspacios = ContadorSalida(palabraajustada);

            return _palabraajustada;
        }

        //Extraer las sentencias con if en un metodo aparte
        private static int Contador(string palabrajustada, int contadorSalida)
        {
            var palabraajustada = palabrajustada;
            var contadorEspacios = 0;

            if (ConNuevaLinea(palabraajustada[contadorSalida].ToString(CultureInfo.InvariantCulture)))
                for (var inCounter = contadorSalida + 1; inCounter < palabraajustada.Length; inCounter++)
                {
                    if (char.IsWhiteSpace(palabraajustada[inCounter]))
                        contadorEspacios++;
                    else
                        break;
                }

            return contadorEspacios;
        }
        //Extraer en un metodo el foreach del metodo Ajustar
        private static int ContadorSalida(string palabrajustada)
        {
            //var _palabraajustada = palabrajustada;
            var contadorEspacios = 0;

            for (var contadorSalida = 0; contadorSalida < palabrajustada.Length; contadorSalida++)
            {

                contadorEspacios = Contador(palabrajustada, contadorSalida);
                if (contadorEspacios <= 0) continue;

                var palabraajustada = RemoverEspaciosEnBlancoPalabraAjustada(palabrajustada, contadorSalida, contadorEspacios);

                contadorEspacios = 0;
            }


            return contadorEspacios;
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
