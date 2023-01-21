using System;

namespace Parcial2UCAB.Persistence.Entities
{
    public class PeliculaActor : BaseEntity
    {
        public Guid PeliculaId { get; set; }
        public Guid ActorId { get; set; }
        public string Personaje { get; set; }
        public int Orden { get; set; }

       public enum tipoActor
        {
            Protagonista,
            Secundario,
            De_reparto,
            De_pequeñas_partes
        }

        public Pelicula Pelicula { get; set; }
        public Actor Actor { get; set; }
    }
}
