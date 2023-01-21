using System.Collections.Generic;
using System;
using Parcial2UCAB.Persistence.Entities;

namespace Parcial2UCAB.Requests
{
    public class PeliculaRequest
    {
        public Guid Id { get; set; }
        public string Titulo { get; set; }
        public string FormatoPeli { get; set; }
        public bool EnCartelera { get; set; }
        public DateTime FechaEstreno { get; set; }
        public List<GeneroRequest> Generos { get; set; }
        public List<PeliculaActorRequest> PeliculaActor { get; set; }
    }
}
