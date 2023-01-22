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
    }
}


public class Respuesta<T>
{
    public string Estatus { get; set; }
    public string Codigo { get; set; }
    public string  Mensaje { get; set; }
    public T Data { get; set; }
}