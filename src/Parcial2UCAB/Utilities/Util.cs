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
            var actualCount = 0;   //inicializa el contador
            var palabraajustada = string.Empty;     //inicializa la variable que almacena la palabra ajustada

            if (ConNuevaLinea(palabra)) return palabra;                         //si se topa con una nueva linea, retorna la palabra como es

            if (ConEspacioONull(palabra)) return string.Empty;                  //si se topa con un espacio o esta en nulo, retorna un string vacio

            foreach (var caracter in palabra)                                //recorre cada caracter en la palabra
            {
                palabraajustada = palabraajustada + Convert.ToString(caracter);           //va introduciendo los caracteres de la palabra a la variable de la palabra ajustada

                if (ConEspacioONuevaLinea(caracter)) continue;                            //si se topa con un espacio o una nueva linea, continua

                if (ConNuevaLinea(caracter.ToString(CultureInfo.InvariantCulture))) continue;      //si se topa con una nueva linea, continua

                actualCount++;                 //incrementa el contador

                if (actualCount == palabra.Length)              //si el contador es mayor que la longitud de la palabra
                    palabraajustada += "\n";                    //se le agrega un salto de linea
            }

            palabraajustada = ObtenerPalabraSinEspacios(palabraajustada);           //ajusta la palabra quitandole los espacios en blanco

            return palabraajustada;              //retorna la palabra ajustada
        }

        private static string ObtenerPalabraSinEspacios(string palabraajustada)
        {
            var _palabraajustada = palabraajustada;        //inicializa la variable de la palabra ajustada
            var contadorEspacios = 0;                      //inicializa el contador de espacios

            for (var contadorSalida = 0; contadorSalida < palabraajustada.Length; contadorSalida++)       //para cada caracter en la palabra ajustada, recorre
            {
                if (ConNuevaLinea(palabraajustada[contadorSalida].ToString(CultureInfo.InvariantCulture)))      //si se topa con una nueva linea,
                    for (var inCounter = contadorSalida + 1; inCounter < palabraajustada.Length; inCounter++)  //recorre a partir del proximo caracter
                    {
                        if (char.IsWhiteSpace(palabraajustada[inCounter]))                    //si se encuentra con un espacio en blanco,
                            contadorEspacios++;                                               //aumenta el contador de espacios,
                        else                                                                  //de lo contrario,
                            break;                                                            //termina el ciclo
                    }

                if (contadorEspacios <= 0) continue;                                          //si el contador de espacios es menor o igual que 0, continua

                _palabraajustada = RemoverEspacios(palabraajustada, contadorSalida, contadorEspacios);      //quita los espacios en blanco de la palabra ajustada

                contadorEspacios = 0;
            }

            return _palabraajustada;
        }

        private static string RemoverEspacios(string palabraajustada, int contadorSalida, int contadorEspacios)
        {
            return palabraajustada.Remove(contadorSalida + 1, contadorEspacios);       //quita el espacio en blanco de la posicion indicada
        }

        private static bool ConNuevaLinea(string palabra)
        {
            return palabra == "\n";               //valida si es o no una nueva linea
        }

        private static bool ConEspacioONull(string palabra)
        {
            return (string.IsNullOrEmpty(palabra)) || (string.IsNullOrWhiteSpace(palabra));       //valida si es nula la palabra o si es un espacio en blanco
        }

        private static bool ConEspacioONuevaLinea(char wrd)
        {
            return char.IsWhiteSpace(wrd) && (wrd == '\n');            //valida si es un espacio en blanco o un salto de linea
        }
    }
}
