using System;
using System.Collections.Generic;
namespace Parcial2UCAB.Persistence.Entities
{
    public abstract class Actor : BaseEntity
    {
        public string Nombre { get; set; }
        public string Biografia { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public ICollection<PeliculaActor> PeliculasActor { get; set; }
        public string FotoURL { get; set; }
    }
}
