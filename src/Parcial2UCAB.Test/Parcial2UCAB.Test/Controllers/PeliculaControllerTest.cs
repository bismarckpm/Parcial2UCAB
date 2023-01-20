using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Parcial2UCAB.Controllers;
using Parcial2UCAB.Persistence.DAOs.Interfaces;
using Parcial2UCAB.Requests;

namespace Parcial2UCAB.Test.Controllers
{
    public class PeliculaControllerTest
    {
        private readonly PeliculaController _controller;
        private readonly Mock<IPeliculaDAO> _daoMock;
        private readonly Mock<ILogger<PeliculaController>> _loggerMock;

        public PeliculaControllerTest()
        {
            _loggerMock = new Mock<ILogger<PeliculaController>>();
            _daoMock = new Mock<IPeliculaDAO>();
            _controller = new PeliculaController(_loggerMock.Object, _daoMock.Object);
            _controller.ControllerContext = new ControllerContext();
            _controller.ControllerContext.HttpContext = new DefaultHttpContext();
            _controller.ControllerContext.ActionDescriptor = new ControllerActionDescriptor();
        }

        [Fact]
        public async Task CreatePelicula()
        {
            _daoMock
                .Setup(x => x.CreatePelicula(It.IsAny<PeliculaRequest>()))
                .ReturnsAsync(new Guid());

            var result = await _controller.CreatePelicula(new PeliculaRequest());

            Assert.IsType<Guid>(result);
        }

        [Fact]
        public async Task ThrowCreatePelicula()
        {
            try
            {
                _daoMock
                    .Setup(x => x.CreatePelicula(It.IsAny<PeliculaRequest>()))
                    .ThrowsAsync(new Exception());

                var result = await _controller.CreatePelicula(new PeliculaRequest());
            }
            catch (Exception ex)
            {
                Assert.NotNull(ex);
            }
        }
    }
}
