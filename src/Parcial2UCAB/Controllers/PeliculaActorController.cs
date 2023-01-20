using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Parcial2UCAB.Persistence.DAOs.Interfaces;
using Parcial2UCAB.Requests;

namespace Parcial2UCAB.Controllers
{
    public class PeliculaActorController : ControllerBase
    {
        private readonly IPeliculaActorDAO _PeliculaActorDAO;
        
        public PeliculaActorController(ILogger<PeliculaActorController> logger, IPeliculaActorDAO PeliculaActorDAO)
        {
            _PeliculaActorDAO = PeliculaActorDAO;
        }

        [HttpPost]
        public async Task<Guid> CreatePeliculaActor([FromBody] PeliculaActorRequest request)
        {
            Guid result = new Guid();
            try
            {
                if (request != null)
                    result = await _PeliculaActorDAO.CreatePeliculaActor(request);
            }
            catch (Exception)
            {
                throw;
            }
            return result;

        }

        [HttpPut]
        public async Task<Guid> UpdatePeliculaActor([FromBody] PeliculaActorRequest request)
        {
            Guid result;
            try
            {
                result = await _PeliculaActorDAO.UpdatePeliculaActor(request);
            }
            catch (Exception)
            {
                throw;
            }
            return result;

        }

        [HttpGet("/{PeliculaActorId}")]
        public async Task<PeliculaActorResponse> GetPeliculaActor([Required][FromRoute] Guid PeliculaActorId)
        {
            PeliculaActorResponse result = null;
            try
            {
                result = await _PeliculaActorDAO.GetPeliculaActor(PeliculaActorId);
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }
    }
}
