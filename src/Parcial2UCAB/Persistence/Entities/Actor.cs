using System;
using System.Collections.Generic;

namespace Parcial2UCAB.Persistence.Entities
{
    public class Actor : BaseEntity
    {
        public string Nombre { get; set; }
        public string Biografia { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public ICollection<PeliculaActor> PeliculasActor { get; set; }
        public string FotoURL { get; set; }

        public ActorType Tipo { get; set; }

    }
        public enum ActorType
        {
            Protagonista,
            Secundario, 
            Reparto,
            PequeñasPartes 
         }
}
