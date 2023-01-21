using System.Collections.Generic;
using System;

namespace Parcial2UCAB.Requests
{
    public class PeliculaRequest
    {
        public Guid Id { get; set; }
        public string Titulo { get; set; }
        public bool EnCartelera { get; set; }
        public Transmi Transmision { get; set; }
        public DateTime FechaEstreno { get; set; }
        public List<GeneroRequest> Generos { get; set; }
        public List<PeliculaActorRequest> PeliculaActor { get; set; }

        public enum Transmi
        {
            Tipo_2D,
            Tipo_3D,
            Tipo_4DX
        }
    }
}
