using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Parcial2UCAB.Utilities
{
    public static class Util
    {
        
        public static string Ajustar(string palabra)
        {
            var count = 0;
            var p_ajustada = string.Empty;
            
            if (NuevaLinea(palabra)) return palabra;

            if (EspacioONull(palabra)) return string.Empty;

            foreach (var caracter in palabra)
            {
                p_ajustada = p_ajustada + Convert.ToString(caracter);

                if (Espacio_NLinea(caracter)) continue;

                if (NuevaLinea(caracter.ToString(CultureInfo.InvariantCulture))) continue;

                count++;

                if (count == palabra.Length)
                    p_ajustada += "\n";
            }

            p_ajustada = ObtenePalabraValida(p_ajustada);

            return p_ajustada;
        }

        private static string ObtenePalabraValida(string p_ajustada)
        {
            var _p = p_ajustada;
            var Espacios = 0;

            for (var Salida = 0; Salida < p_ajustada.Length; Salida++)
            {
                if (NuevaLinea(p_ajustada[Salida].ToString(CultureInfo.InvariantCulture)))
                    for (var i = Salida + 1; i < p_ajustada.Length; i++)
                    {
                        if (char.IsWhiteSpace(p_ajustada[i]))
                            Espacios++;
                        else
                            break;
                    }

                if (Espacios <= 0) continue;

                _p = RemoverEspacios(p_ajustada, Salida, Espacios);

                Espacios = 0;
            }

            return _p;
        }

        private static string RemoverEspacios(string p_ajustada, int Salida, int Espacios)
        {
            return p_ajustada.Remove(Salida + 1, Espacios);
        }

        private static bool NuevaLinea(string palabra)
        {
            return palabra == "\n";
        }

        private static bool EspacioONull(string palabra)
        {
            return (string.IsNullOrEmpty(palabra)) || (string.IsNullOrWhiteSpace(palabra));
        }

        private static bool Espacio_NLinea(char wrd)
        {
            return char.IsWhiteSpace(wrd) && (wrd == '\n');
        }
        
    }
}
