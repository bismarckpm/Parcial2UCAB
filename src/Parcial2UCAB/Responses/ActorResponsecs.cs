using System;
using System.Collections.Generic;
using static Parcial2UCAB.Persistence.Entities.Actor;

namespace Parcial2UCAB.Responses
{
    public class ActorResponse
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public string Biografia { get; set; }
        public string Foto { get; set; }
        public TipoActor TipoActor { get; set; }
        public List<PeliculaResponse> Peliculas { get; set; }
    }
}
