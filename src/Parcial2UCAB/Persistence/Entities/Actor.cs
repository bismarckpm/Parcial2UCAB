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
        public DateTime? FechaNacimiento { get; set; }

        public TipoActor Tipologia { get; set; }
        public ICollection<PeliculaActor> PeliculasActor { get; set; }
        public string FotoURL { get; set; }
        //Tipo de Actores


        public enum TipoActor
        {
            [EnumMember(Value = "Protagonista")]
            Protagonista,
            [EnumMember(Value = "Secundario")]
            Secundario,
            [EnumMember(Value = "DeReparto")]
            DeReparto,
            [EnumMember(Value = "DePequenaPartes")]
            DePequenaPartes
        }

    }
}
