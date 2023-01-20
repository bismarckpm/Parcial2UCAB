using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Parcial2UCAB.Persistence.DAOs.Interfaces;
using Parcial2UCAB.Requests;

namespace Parcial2UCAB.Persistence.DAOs.Implementations
{
    public class PeliculaActorDAO : IPeliculaActorDAO
    {
        public Task<Guid> CreatePeliculaActor(PeliculaActorRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<PeliculaActorResponse> GetPeliculaActor(Guid PeliculaActorId)
        {
            throw new NotImplementedException();
        }

        public Task<List<PeliculaActorResponse>> GetPeliculaActorxNombre(string nombre)
        {
            throw new NotImplementedException();
        }

        public Task<Guid> UpdatePeliculaActor(PeliculaActorRequest request)
        {
            throw new NotImplementedException();
        }
    }
}