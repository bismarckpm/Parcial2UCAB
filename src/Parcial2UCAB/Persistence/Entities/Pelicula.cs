using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Parcial2UCAB.Persistence.Entities
{
    public enum FormatoPelicula
    {
        [EnumMember(Value = "2D")]
        DosD,
        [EnumMember(Value = "3D")]
        TresD,
        [EnumMember(Value = "4DX")]
        CuatroDX,
    }
    public class Pelicula : BaseEntity
    {
        public string Titulo { get; set; }
        public bool EnCartelera { get; set; }
        public FormatoPelicula formato { get; set; }
        public DateTime FechaEstreno { get; set; }
        public ICollection<Genero> Generos { get; set; }
        public ICollection<PeliculaActor> PeliculasActores { get; set; }
    }
}
