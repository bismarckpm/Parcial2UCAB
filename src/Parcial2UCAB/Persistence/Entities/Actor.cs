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
        public Tipologia tipoActor { get; set; }
        public string FotoURL { get; set; }

        //public Actor(string nombre, string biografia, DateTime? fechaNacimiento, ICollection<PeliculaActor> peliculasActor, Tipologia _tipoActor, string fotoURL)
        //{
        //    Nombre = nombre;
        //    Biografia = biografia;
        //    FechaNacimiento = fechaNacimiento;
        //    PeliculasActor = peliculasActor;
        //    tipoActor = _tipoActor;
        //    FotoURL = fotoURL;
        //}

        public enum Tipologia
        {
            
            Protagonista,            
            Secundario,
            DeReparto,
            DePequenasPartes

        }

    }

}
