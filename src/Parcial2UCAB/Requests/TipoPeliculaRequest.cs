using System.Collections.Generic;
using System;

namespace Parcial2UCAB.Requests
{
    public class TipoPeliculaRequest
    {
        public Guid Id { get; set; }
        public string Titulo { get; set; }
        public bool EnCartelera { get; set; }
        public DateTime FechaEstreno { get; set; }
        public List<GeneroRequest> Generos { get; set; }
        public List<PeliculaActorRequest> PeliculaActor { get; set; }
    }
}
