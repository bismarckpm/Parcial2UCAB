using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Parcial2UCAB.Persistence.Entities
{
    public class Genero : BaseEntity
    {
        public string Nombre { get; set; }
        public ICollection<Pelicula> Peliculas { get; set; }
    }
}
