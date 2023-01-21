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
        public ICollection<PeliculaActor> PeliculasActor { get; set; }
        public string FotoURL { get; set; }
        public TipoActor tipoActor { get; set; }

        /*public Actor(string nombre, string biografia, DateTime? fechaNacimiento, ICollection<PeliculaActor> peliculasActor, string fotoURL, TipoActor tipoActor)
        {
            Nombre = nombre;
            Biografia = biografia;
            FechaNacimiento = fechaNacimiento;
            PeliculasActor = peliculasActor;
            FotoURL = fotoURL;
            this.tipoActor = tipoActor;
        }*/

        public enum TipoActor
        {
            Protagonista,
            Secundario,
            Reparto,
            PequeñasPartes
        };
    }
}
