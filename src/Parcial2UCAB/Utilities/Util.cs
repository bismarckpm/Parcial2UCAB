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
            var NewPalabra = string.Empty;

            if (NewLinea(palabra)) return palabra;

            if (ConEspacioONull(palabra)) return string.Empty;

            foreach (var caracter in palabra)
            {
                NewPalabra = NewPalabra + Convert.ToString(caracter);

                if (ConEspacioONuevaLinea(caracter)) continue;

                if (NewLinea(caracter.ToString(CultureInfo.InvariantCulture))) continue;

                actualCount++;

                if (actualCount == palabra.Length)
                    NewPalabra += "\n";
            }

            NewPalabra = PalabraSinEspacios(NewPalabra);

            return NewPalabra;
        }

        private static string PalabraSinEspacios(string NewPalabra)
        {
            var _NewPalabra = NewPalabra;
            var contadorEspacios = 0;

            for (var contadorSalida = 0; contadorSalida < NewPalabra.Length; contadorSalida++)
            {
                if (NewLinea(NewPalabra[contadorSalida].ToString(CultureInfo.InvariantCulture)))
                    for (var inCounter = contadorSalida + 1; inCounter < NewPalabra.Length; inCounter++)
                    {
                        if (char.IsWhiteSpace(NewPalabra[inCounter]))
                            contadorEspacios++;
                        else
                            break;
                    }

                if (contadorEspacios <= 0) continue;

                _NewPalabra = QuitarEspacios(NewPalabra, contadorSalida, contadorEspacios);

                contadorEspacios = 0;
            }

            return _NewPalabra;
        }

        private static string QuitarEspacios(string NewPalabra, int contadorSalida, int contadorEspacios)
        {
            return NewPalabra.Remove(contadorSalida + 1, contadorEspacios);
        }

        private static bool NewLinea(string palabra)
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
