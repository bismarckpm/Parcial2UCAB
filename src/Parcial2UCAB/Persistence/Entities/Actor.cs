using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Parcial2UCAB.Persistence.Entities
{
    public class Actor : BaseEntity
    {
        public string Nombre { get; set; }
        public string Biografia { get; set; }
        public string Tipologia { get; set; }    
        public DateTime? FechaNacimiento { get; set; }
        public ICollection<PeliculaActor> PeliculasActor { get; set; }
        public string FotoURL { get; set; }


    }
}
