using System;
using System.Collections.Generic;

namespace Parcial2UCAB.Persistence.Entities
{
    public class Pelicula : BaseEntity
    {
        public string Titulo { get; set; }
        public FormatoPeli Formato { get; set; }
        public bool EnCartelera { get; set; }
        public DateTime FechaEstreno { get; set; }
        public ICollection<Genero> Generos { get; set; }
        public ICollection<PeliculaActor> PeliculasActores { get; set; }
    }


    public enum FormatoPeli
    {
        Peli2D,
        Peli3D,
        Peli4DX,
    }
}
