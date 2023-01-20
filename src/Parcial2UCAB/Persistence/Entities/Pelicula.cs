using System;
using System.Collections.Generic;

namespace Parcial2UCAB.Persistence.Entities
{
    public class Pelicula : BaseEntity
    {
        public enum TipoFormato
        {
            Pelicula2D,
            Pelicula3D,
            Pelicula4DX
        }


        public string Titulo { get; set; }
        public bool EnCartelera { get; set; }
        public DateTime FechaEstreno { get; set; }
        public ICollection<Genero> Generos { get; set; }
        public ICollection<PeliculaActor> PeliculasActores { get; set; }

        public TipoFormato FormatoPelicula { get; set; } 
    }
}
