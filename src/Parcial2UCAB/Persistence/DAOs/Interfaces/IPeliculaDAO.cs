using Parcial2UCAB.Requests;
using Parcial2UCAB.Responses;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;

namespace Parcial2UCAB.Persistence.DAOs.Interfaces
{
    public interface IPeliculaDAO
    {

        Task<Guid> CreatePelicula(PeliculaRequest request);

        Task<Guid> UpdatePelicula(PeliculaRequest request);

        Task<List<PeliculaResponse>> GetPeliculaxNombre(string nombre);
        //void GetPeliculaxNombre(Func<PeliculaResponse, PeliculaResponse, global::Moq.Range, PeliculaResponse> isInRange);
        // void GetPeliculaxNombre(PeliculaRequest peliculaRequest);
    }
}
