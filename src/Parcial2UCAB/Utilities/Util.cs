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

			palabraajustada = ObtenerPalabraAjuustadaRecorriendoPalabra(palabra, palabraajustada);

			palabraajustada = ObtenePalabraEnvueltaSinEspaciosBlancoInicioLinea(palabraajustada);

			return palabraajustada;
		}

		private static string ObtenerPalabraAjuustadaRecorriendoPalabra(string palabra, string palabraajustada)
		{
			var actualCount = 0;
			for (int i = 0; i < palabra.Length; i++)
			{
				palabraajustada = palabraajustada + Convert.ToString(palabra[i]);

				if (ConNuevaLinea(palabra[i].ToString(CultureInfo.InvariantCulture)))
					actualCount++;

				if (actualCount == palabra.Length)
					palabraajustada += "\n";
			}
			return palabraajustada;
		}

		private static string ObtenePalabraEnvueltaSinEspaciosBlancoInicioLinea(string palabraajustada)
		{
			var _palabraajustada = palabraajustada;

			_palabraajustada = _palabraajustada.Replace("\n ", "\n");

			return _palabraajustada;
		}

		private static bool ConNuevaLinea(string palabra)
		{
			return palabra == "\n";
		}

		private static bool ConEspacioONull(string palabra)
		{
			return (string.IsNullOrEmpty(palabra)) || (string.IsNullOrWhiteSpace(palabra));
		}
	}
}