using Microsoft.Extensions.Logging;
using Moq;
using Parcial2UCAB.Persistence.DAOs.Implementations;
using Parcial2UCAB.Persistence.DAOs.Interfaces;
using Parcial2UCAB.Persistence.Database;
using Parcial2UCAB.Test.DataSeed;

namespace Parcial2UCAB.Test.DAOs
{
    public class PeliculaDAOTest
    {
        private readonly IPeliculaDAO _dao;
        private readonly Mock<IParcial2DbContext> _contextMock;
        private readonly Mock<ILogger<PeliculaDAO>> _mockLogger;

        public PeliculaDAOTest()
        {
            _contextMock = new Mock<IParcial2DbContext>();
            _mockLogger = new Mock<ILogger<PeliculaDAO>>();
            _dao = new PeliculaDAO(_contextMock.Object, _mockLogger.Object);
            _contextMock.SetupDbContextData();
        }

        [Fact]
        public async Task ShouldReturnGetPeliculasxNombre()
        {
            var nombre = "La mascara de pedro";
            var result = await _dao.GetPeliculaxNombre(nombre);
            var data = result;
            Assert.True(data.Any());
        }

        [Fact]
        public async Task ShouldThrowGetPeliculasxNombre()
        {
            var ex = await Assert.ThrowsAsync<NullReferenceException>(() => _dao.GetPeliculaxNombre(null));

            Assert.IsType<NullReferenceException>(ex);
            Assert.Contains("Nombre de la pelicula requerido.", ex.Message);
        }
    }
}
