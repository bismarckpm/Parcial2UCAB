using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Parcial2UCAB.Controllers;
using Parcial2UCAB.Persistence.DAOs.Interfaces;
using Moq;
using Parcial2UCAB.Requests;
using Parcial2UCAB.Responses;
using Parcial2UCAB.Persistence.Entities;

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

        [Fact (DisplayName = "Creador Actor")]
        public async Task CreateActor()
        {
            _daoMock
                .Setup(x => x.CreateActor(It.IsAny<ActorRequest>()))
                .ReturnsAsync(new Guid());

            var result = await _controller.CreateActor(new ActorRequest());

            Assert.IsType<Guid>(result);
        }

        [Fact  (DisplayName = "Obtener Actor")]
        public async Task GetActor()
        {
            var actorId = Guid.NewGuid();
            _daoMock
                .Setup(x => x.GetActor(It.IsAny<Guid>()))
                .ReturnsAsync(new ActorResponse());

            var result = await _controller.GetActor(actorId);

            Assert.IsType<ActorResponse>(result);
        }

        [Fact (DisplayName = "Actualizar Actor")]
        public async Task UpdateActor()
        {
            _daoMock
                .Setup(x => x.UpdateActor(It.IsAny<ActorRequest>()))
                .ReturnsAsync(new Guid());  
            var actor = new ActorRequest() 
                {
                    Id = new Guid("b8453690-3c39-4d33-85cf-14409e15098a"),
                    Nombre = "Ana Peña",
                    Apellido = "Pena",
                    TipoDeActor = TipoActor.Protagonista,
                    Biografia = "Biografía de Ana Peña",
                    FechaNacimiento = DateTime.Parse("12-12-1978"),
                    FotoURL = ""                    
                };   
            var result = await _controller.UpdateActor(actor);
            Assert.IsType<Guid>(result);
        }
    }
}
