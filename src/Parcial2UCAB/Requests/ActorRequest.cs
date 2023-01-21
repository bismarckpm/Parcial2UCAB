using System;
using Parcial2UCAB.BussinesLogic.Enums;
namespace Parcial2UCAB.Requests
{
    public class ActorRequest
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Biografia { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public string FotoURL { get; set; }
        public TipoActor tipo {get; set;}
    }
}
