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
    public class TipoPeliculaController : ControllerBase
    {
        private readonly IPeliculaDAO _TipoPeliculaDAO;

        public TipoPeliculaController(ILogger<TipoPeliculaController> logger, IPeliculaDAO TipoPeliculaDAO)
        {
            _TipoPeliculaDAO = TipoPeliculaDAO;
        }

        [HttpPost]
        public async Task<Guid> CreateTipoPelicula([FromBody] PeliculaRequest request)
        {
            Guid result;
            try
            {
                result = await _TipoPeliculaDAO.CreateTipoPelicula(request);
            }
            catch (Exception)
            {
                throw;
            }
            return result;

        }

        [HttpPut]
        public async Task<Guid> UpdateTipoPelicula([FromBody] TipoPeliculaRequest request)
        {
            Guid result;
            try
            {
                result = await _TipoPeliculaDAO.UpdateTipoPelicula(request);
            }
            catch (Exception)
            {
                throw;
            }
            return result;

        }

    }
}
