using System;
using System.Collections.Generic;

namespace Parcial2UCAB.Persistence.Entities
{
    public class Pelicula : BaseEntity
    {
        public string Titulo { get; set; }
        public bool EnCartelera { get; set; }
        public DateTime FechaEstreno { get; set; }
        public ICollection<Genero> Generos { get; set; }
        public ICollection<PeliculaActor> PeliculasActores { get; set; }
        public TipoPelicula TipoDePelicula { get; set; }
    }

    public enum TipoPelicula
    {
        Formato2D = 1,
        Formato3D = 2,
        Formato4DX = 3
    }
}
