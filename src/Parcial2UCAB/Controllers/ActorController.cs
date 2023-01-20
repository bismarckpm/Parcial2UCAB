using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Parcial2UCAB.Persistence.DAOs.Interfaces;
using Parcial2UCAB.Requests;
using Parcial2UCAB.Responses;
using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace Parcial2UCAB.Controllers
{
    public class ActorController : ControllerBase
    {
        private readonly IActorDAO _actorDAO;

        public ActorController(ILogger<ActorController> logger, IActorDAO actorDAO)
        {
            _actorDAO = actorDAO;
        }

        [HttpPost]
        public async Task<Guid> CreateActor([FromBody] ActorRequest request)
        {
            Guid result = new Guid();
            try
            {
                if (request != null)
                    result = await _actorDAO.CreateActor(request);
            }
            catch (Exception)
            {
                throw;
            }
            return result;

        }

        [HttpPut]
        public async Task<Guid> UpdateActor([FromBody] ActorRequest request)
        {
            Guid result;
            try
            {
                result = await _actorDAO.UpdateActor(request);
            }
            catch (Exception)
            {
                throw;
            }
            return result;

        }

        [HttpGet("/{actorId}")]
        public async Task<ActorResponse> GetActor([Required][FromRoute] Guid actorId)
        {
            ActorResponse result = null;
            try
            {
                result = await _actorDAO.GetActor(actorId);
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }
    }
}
