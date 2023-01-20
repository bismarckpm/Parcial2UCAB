using System;
using System.Collections.Generic;

namespace Parcial2UCAB.Responses
{
    public class ActorResponse
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public string Biografia { get; set; }
        public string Foto { get; set; }
        public List<PeliculaResponse> Peliculas { get; set; }
    }
}
