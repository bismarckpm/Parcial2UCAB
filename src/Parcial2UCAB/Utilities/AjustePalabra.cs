namespace Parcial2UCAB.Utilities
{
    public class AjustePalabra
    {
        public static string AjustarPalabra(string palabra)
        {
            //ESTA FUNCIÓN ELIMINA LOS ESPACIOS EN BLANCOS Y LOS SALTOS DE LÍNEA DE LA PALABRA RECIBIDA POR PARÁMETRO
            //POR EJEMPLO SI SE RECIBE: El Señor De Los Anillos, ESTA FUNCIÓN RETORNARÍA ElSeñorDeLosAnillos.
            string _palabraAjustada = palabra;
            if (!PalabraEsVacia(_palabraAjustada))
            {
                if (ContieneNuevaLinea(_palabraAjustada))
                    _palabraAjustada = RemoverNuevaLinea(palabra);
                if (ContieneEspacios(_palabraAjustada))
                    _palabraAjustada = RemoverEspaciosEnBlanco(_palabraAjustada);
            }
            return _palabraAjustada;
        }
        private static string RemoverEspaciosEnBlanco(string palabraAjustada)
        {
            return palabraAjustada.Replace(" ", string.Empty);
        }
        private static string RemoverNuevaLinea(string palabraAjustada)
        {
            return palabraAjustada.Replace("\n", string.Empty);
        }
        private static bool ContieneNuevaLinea(string palabra)
        {
            return palabra.IndexOf("\n") > 0;
        }
        private static bool ContieneEspacios(string palabra)
        {
            return palabra.IndexOf(" ") > 0;
        }
        private static bool PalabraEsVacia(string palabra)
        {
            return string.IsNullOrWhiteSpace(palabra);
        }
    }
}