using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Parcial2UCAB.Persistence.DAOs.Interfaces;
using Parcial2UCAB.Persistence.Database;
using Parcial2UCAB.Persistence.Entities;
using Parcial2UCAB.Requests;
using Parcial2UCAB.Responses;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Parcial2UCAB.Persistence.DAOs.Implementations
{
    public class ActorDAO : IActorDAO
    {
        public readonly IParcial2DbContext _context;
        private readonly ILogger<ActorDAO> _logger;

        public ActorDAO(Parcial2DbContext context, ILogger<ActorDAO> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<Guid> CreateActor(ActorRequest request)
        {
            using var transaction = _context.BeginTransaction();
            var result = Guid.Empty;
            try
            {
                
                 var entity = new Actor()
                   {
                       Nombre = request.Nombre + " " + request.Apellido,
                       Biografia = request.Biografia,
                       //Tipologia =request.
                       FechaNacimiento = request.FechaNacimiento,
                       FotoURL = request.FotoURL
                   };

                _context.Actores.Add(entity);
                result = entity.Id;
                await _context.SaveEfContextChanges("APPUSER");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error Creating Actor {@ActorRequest}. {Message}", request,
                    ex.Message);
                transaction.Rollback();
                throw;
            }
            return result;
        }

       


        public async Task<Guid> UpdateActor(ActorRequest request)
        {
            using var transaction = _context.BeginTransaction();
            Guid result;
            try
            {
                var entity = new Actor()
                {
                    Id = request.Id,
                    Nombre = request.Nombre + " " + request.Apellido,
                    Biografia = request.Biografia,
                    FechaNacimiento = request.FechaNacimiento,
                    FotoURL = request.FotoURL
                };

                _context.Actores.Update(entity);
                result = entity.Id;
                await _context.SaveEfContextChanges("APPUSER");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error Updating Actor {@ActorRequest}. {Message}", request,
                    ex.Message);
                transaction.Rollback();
                throw;
            }
            return result;
        }


        public async Task<ActorResponse> GetActor(Guid actorId)
        {
            try
            {
                var data = _context
                  .Actores
                  .Where(a => a.Id == actorId)
                  .Select(x => new ActorResponse
                  {
                      Id = x.Id,
                      Nombre = x.Nombre,
                      Biografia = x.Biografia,
                      Foto = x.FotoURL
                  });

                return await data.SingleAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error Getting Actor {@Actor ID}. {Message}", actorId,
                    ex.Message);
                throw;
            }
        }
    }
}
