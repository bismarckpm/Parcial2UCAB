using System;
namespace Parcial2UCAB.Test.Utilities
{
	public class UtilTest
	{
        [Fact]
		public void AjustarEspacioEnBlanco()
		{
			string palabra = " ";
			string expected = string.Empty;

			string result = Parcial2UCAB.Utilities.Util.Ajustar(palabra);

			Assert.Equal(expected, result);
		}
        [Fact]
        public void AjustarSaltoDeLinea()
        {
            string palabra = "\n";
            string expected = "\n";

            string result = Parcial2UCAB.Utilities.Util.Ajustar(palabra);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void AjustarNull()
        {
            string expected = string.Empty;

            string result = Parcial2UCAB.Utilities.Util.Ajustar(null);

            Assert.Equal(expected, result);
        }
        [Fact]
        public void AjustarVacio()
        {
            string palabra = "";
            string expected = string.Empty;

            string result = Parcial2UCAB.Utilities.Util.Ajustar(palabra);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void AjustarPalabra()
        {
            string palabra = "hola\n como    estas    tu\n\n";
            string expected = "holacomoestastu\n";

            string result = Parcial2UCAB.Utilities.Util.Ajustar(palabra);

            Assert.Equal(expected, result);
        }

    }
}

