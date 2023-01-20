using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System;
using Parcial2UCAB.Persistence.DAOs.Interfaces;
using Parcial2UCAB.Requests;
using Parcial2UCAB.Responses;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Parcial2UCAB.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PeliculaController : ControllerBase
    {
        private readonly IPeliculaDAO _peliculaDAO;

        public PeliculaController(ILogger<PeliculaController> logger, IPeliculaDAO peliculaDAO)
        {
            _peliculaDAO = peliculaDAO;
        }

        [HttpPost]
        public async Task<Guid> CreatePelicula([FromBody] PeliculaRequest request)
        {
            Guid result;
            try
            {
                result = await _peliculaDAO.CreatePelicula(request);
            }
            catch (Exception)
            {
                throw;
            }
            return result;

        }

        [HttpPut]
        public async Task<Guid> UpdatePelicula([FromBody] PeliculaRequest request)
        {
            Guid result;
            try
            {
                result = await _peliculaDAO.UpdatePelicula(request);
            }
            catch (Exception)
            {
                throw;
            }
            return result;

        }

        [HttpGet("pelicula/{nombre}")]
        public async Task<List<PeliculaResponse>> GetPelicula([Required][FromRoute] string nombre)
        {
            List<PeliculaResponse> result = null;
            try
            {
                result = await _peliculaDAO.GetPeliculaxNombre(nombre);
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }
    }
}
