using Microsoft.Extensions.Logging;
using Parcial2UCAB.Persistence.DAOs.Interfaces;
using Parcial2UCAB.Persistence.Database;
using Parcial2UCAB.Persistence.Entities;
using Parcial2UCAB.Requests;
using Parcial2UCAB.Responses;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Parcial2UCAB.Utilities;

namespace Parcial2UCAB.Persistence.DAOs.Implementations
{
    public class PeliculaDAO : IPeliculaDAO
    {
        public readonly IParcial2DbContext _context;
        private readonly ILogger<PeliculaDAO> _logger;

        public PeliculaDAO(IParcial2DbContext context, ILogger<PeliculaDAO> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<Guid> CreatePelicula(PeliculaRequest request)
        {
            using var transaction = _context.BeginTransaction();
            var result = Guid.Empty;
            try
            {
                var entity = new Pelicula();
                entity.Titulo = Util.Ajustar(request.Titulo);
                entity.EnCartelera = request.EnCartelera;
                entity.Formato = request.Formato; 
                var generos = new List<Genero>();
                foreach (var gen in request.Generos)
                {
                    var value = new Genero();
                    value.Nombre = gen.Nombre;
                    generos.Add(value);
                }
                entity.Generos = generos;
                _context.Peliculas.Add(entity);
                result = entity.Id;
                await _context.SaveEfContextChanges("APPUSER");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error Creating Pelicula {@PeliculaRequest}. {Message}", request,
                    ex.Message);
                transaction.Rollback();
                throw;
            }
            return result;
        }

        public async Task<Guid> UpdatePelicula(PeliculaRequest request)
        {
            using var transaction = _context.BeginTransaction();
            Guid result;
            try
            {
                var entity = new Pelicula();
                entity.Id = request.Id;
                entity.Titulo = request.Titulo;
                entity.EnCartelera = request.EnCartelera;
                entity.Formato = request.Formato;
                _context.Peliculas.Update(entity);
                result = entity.Id;
                await _context.SaveEfContextChanges("APPUSER");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error Updating Pelicula {@PeliculaRequest}. {Message}", request,
                    ex.Message);
                transaction.Rollback();
                throw;
            }
            return result;
        }


        public async Task<List<PeliculaResponse>> GetPeliculaxNombre(string nombre)
        {
            try
            {
                if (string.IsNullOrEmpty(nombre))
                    throw new NullReferenceException("Nombre de la pelicula requerido.");
                var data = _context
                  .Peliculas
                  .Where(p => p.Titulo == nombre)
                  .Select(x => new PeliculaResponse
                  {
                      Id = x.Id,
                      Titulo = x.Titulo,
                      EnCartelera = x.EnCartelera,
                      Formato = x.Formato,
                      Generos = x.Generos.Select(k => new GeneroResponse
                      {
                          Nombre = k.Nombre
                      }).ToList()
                  });

                return await data.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error Getting Peliculas por Nombre {@Nombre }. {Message}", nombre,
                    ex.Message);
                throw;
            }
        }
    }
}
