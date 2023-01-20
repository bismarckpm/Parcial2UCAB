using System;
using System.Text.RegularExpressions;
using Parcial2UCAB.Persistence.Entities;

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
            return AjustePalabra.AjustarPalabra(palabra);
        }
        public static Actor ActorFactory(string rol)
        {
            switch(rol)
            {
                case "protagonista":
                    return new ActorProtagonista();
                case "secundario":
                    return new ActorSecundario();
                case "de reparto":
                    return new ActorDeReparto();
                case "pequenas partes":
                    return new ActorDePequenasPartes();
                default:
                    throw new Exception("Tipo de actor no se encuentra registrado");
            }
        }
    }
}
