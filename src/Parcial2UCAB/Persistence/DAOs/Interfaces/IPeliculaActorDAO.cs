using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Parcial2UCAB.Requests;

namespace Parcial2UCAB.Persistence.DAOs.Interfaces
{
    public interface IPeliculaActorDAO
    {
        Task<Guid> CreatePeliculaActor(PeliculaActorRequest request);
        Task<Guid> UpdatePeliculaActor(PeliculaActorRequest request);
        Task<List<PeliculaActorResponse>> GetPeliculaActorxNombre(string nombre);
        Task<PeliculaActorResponse> GetPeliculaActor(Guid PeliculaActorId);
    }
}