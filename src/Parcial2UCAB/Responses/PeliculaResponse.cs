using Parcial2UCAB.Persistence.Entities;
using System.Collections.Generic;
using System;

namespace Parcial2UCAB.Responses
{
    public class PeliculaResponse
    {
        public Guid Id { get; set; }
        public string Titulo { get; set; }
        public bool EnCartelera { get; set; }
        public string Formato { get; set; }
        public DateTime FechaEstreno { get; set; }
        public List<GeneroResponse> Generos { get; set; }
    }
}
