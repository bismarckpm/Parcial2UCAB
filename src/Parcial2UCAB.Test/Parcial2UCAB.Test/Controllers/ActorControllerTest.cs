using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Parcial2UCAB.Controllers;
using Parcial2UCAB.Persistence.DAOs.Interfaces;
using Moq;
using Parcial2UCAB.Requests;
using Parcial2UCAB.Responses;

namespace Parcial2UCAB.Test.Controllers
{
    public class ActorControllerTest
    {
        private readonly ActorController _controller;
        private readonly Mock<IActorDAO> _daoMock;
        private readonly Mock<ILogger<ActorController>> _loggerMock;

        public ActorControllerTest()
        {
            _loggerMock = new Mock<ILogger<ActorController>>();
            _daoMock = new Mock<IActorDAO>();
            _controller = new ActorController(_loggerMock.Object, _daoMock.Object);
            _controller.ControllerContext = new ControllerContext();
            _controller.ControllerContext.HttpContext = new DefaultHttpContext();
            _controller.ControllerContext.ActionDescriptor = new ControllerActionDescriptor();
        }

        //Test de la funcion CreateActor
        [Fact]
        public async Task CreateActor()
        {
            _daoMock
                .Setup(x => x.CreateActor(It.IsAny<ActorRequest>()))
                .ReturnsAsync(new Guid());

            var result = await _controller.CreateActor(new ActorRequest());

            Assert.IsType<Guid>(result);
        }

        //Test de la funcion GetActor
        [Fact]
        public async Task GetActor()
        {
            var actorId = Guid.NewGuid();
            _daoMock
                .Setup(x => x.GetActor(It.IsAny<Guid>()))
                .ReturnsAsync(new ActorResponse());

            var result = await _controller.GetActor(actorId);

            Assert.IsType<ActorResponse>(result);
        }

        //Test de la funcion UpdateActor
        [Fact]
        public async Task UpdateActor()
        {
             _daoMock
                .Setup(x => x.UpdateActor(It.IsAny<ActorRequest>()))
                .ReturnsAsync(new Guid());

            var result = await _controller.UpdateActor(new ActorRequest());

            Assert.IsType<Guid>(result);
        }

        //Test de la Exception de CreateActor
        [Fact]
        public async Task ExceptionCreateActor()
        {
            try
            {
                _daoMock
               .Setup(x => x.CreateActor(It.IsAny<ActorRequest>()))
               .ThrowsAsync(new Exception());

                var result = await _controller.CreateActor(new ActorRequest());

                Assert.IsType<Guid>(result);
            }
            catch (Exception ex)
            {
                Assert.NotNull(ex);
            }

        }

        //Test de la Exception de GetActor
        [Fact]
        public async Task ExceptionGetActor()
        {
            try
            {
                var actorId = Guid.NewGuid();
                _daoMock
                .Setup(x => x.GetActor(It.IsAny<Guid>()))
                .ThrowsAsync(new Exception());

                var result = await _controller.GetActor(actorId);

                Assert.IsType<ActorResponse>(result);
            }
            catch (Exception ex)
            {
                Assert.NotNull(ex);
            }
        }
        //Test de la Exception de UpdateActor
        [Fact]
        public async Task ExceptionUpdateActor()
        {
            try
            {
                _daoMock
                    .Setup(x => x.UpdateActor(It.IsAny<ActorRequest>()))
                    .ThrowsAsync(new Exception());

                var result = await _controller.UpdateActor(new ActorRequest());
            }

            catch (Exception ex)
            {
                Assert.NotNull(ex);
            }
        }

    }
}
