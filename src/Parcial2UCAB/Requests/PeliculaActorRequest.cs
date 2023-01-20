using Parcial2UCAB.Persistence.Entities;

namespace Parcial2UCAB.Requests
{
    public class PeliculaActorRequest
    {
        public string Personaje { get; set; }
        public int Orden { get; set; }

        public TipoActor Tipo { get; set; }
    }
}
