using Microsoft.Extensions.Logging;
using Moq;
using Parcial2UCAB.Controllers;
using Parcial2UCAB.Persistence.DAOs.Interfaces;
using Parcial2UCAB.Requests;
using Parcial2UCAB.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcial2UCAB.Test.DAOs
{
    public class ActorDAOTest
    {
                
            private readonly ActorController _controller;
            private readonly Mock<IActorDAO> _mockActorDAO;
            private readonly ILogger<ActorController> _mockLogger;
            public ActorDAOTest()
            {
                _mockActorDAO = new Mock<IActorDAO>();
                _mockLogger = new Mock<ILogger<ActorController>>().Object;
                _controller = new ActorController(_mockLogger,
                _mockActorDAO.Object);
            }
            [Fact]
            public async Task CrearActor()
            {
                var respuesta = new ActorRequest();
                _mockActorDAO.Setup(x => x.CreateActor(respuesta)).Throws(new
                Exception());
                await Assert.ThrowsAsync<Exception>(() =>
                _controller.CreateActor(respuesta));
            }
            [Fact]
            public async Task CreateActor_ID()
            {
                var respuesta = new ActorRequest();
                var expecion = new Guid();
                _mockActorDAO.Setup(x => x.CreateActor(respuesta)).ReturnsAsync
                (expecion);
                var resultado = await _controller.CreateActor(respuesta);
                Assert.Equal(expecion, resultado);
            }
           
            [Fact]
            public async Task ActualizarActor()
            {
                var respuesta = new ActorRequest();
                var expecion = new Guid();
                _mockActorDAO.Setup(x => x.UpdateActor(respuesta)).ReturnsAsync
                (expecion);
                var resultado = await _controller.UpdateActor(respuesta);
                Assert.Equal(expecion, resultado);
            }
            [Fact]
            public async Task ActualizarActorExcepcion()
            {
                var respuesta = new ActorRequest();
                _mockActorDAO.Setup(x => x.UpdateActor(respuesta)).Throws(new
                Exception());
                await Assert.ThrowsAsync<Exception>(() =>
                _controller.UpdateActor(respuesta));
            }
            [Fact]
            public async Task Actor()
            {
                var actorId = new Guid();
                var expecion = new ActorResponse();
                _mockActorDAO.Setup(x => x.GetActor(actorId)).ReturnsAsync
                (expecion);
                var respuesta = await _controller.GetActor(actorId);
                Assert.Equal(expecion, respuesta);
            }
            [Fact]
            public async Task ExepciondeActor()
            {
                var actorId = new Guid();
                _mockActorDAO.Setup(x => x.GetActor(actorId)).Throws(new
                Exception());
                await Assert.ThrowsAsync<Exception>(() => _controller.GetActor
                (actorId));
            }
        

    }
}
