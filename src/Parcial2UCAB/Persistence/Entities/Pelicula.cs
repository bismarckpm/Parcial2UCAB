using System;
using System.Collections.Generic;

namespace Parcial2UCAB.Persistence.Entities
{
    public class Pelicula : BaseEntity
    {
        
        public string Titulo { get; set; }
        public bool EnCartelera { get; set; }
        public Transmi Transmision { get; set; }
        public DateTime FechaEstreno { get; set; }
        public ICollection<Genero> Generos { get; set; }
        public ICollection<PeliculaActor> PeliculasActores { get; set; }

        public enum Transmi
        {
            Tipo_2D,
            Tipo_3D,
            Tipo_4DX
        }
    }

}