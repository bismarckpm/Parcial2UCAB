using Parcial2UCAB.Requests;
using Parcial2UCAB.Responses;
using System.Threading.Tasks;
using System;

namespace Parcial2UCAB.Persistence.DAOs.Interfaces
{
    public interface IActorDAO
    {
        Task<Guid> CreateActor(ActorRequest request);

        Task<Guid> UpdateActor(ActorRequest request);

        Task<ActorResponse> GetActor(Guid actorId);

    }
}
