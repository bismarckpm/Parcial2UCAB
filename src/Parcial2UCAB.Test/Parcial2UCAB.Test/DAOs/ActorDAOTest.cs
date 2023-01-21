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
            public async Task CreateActor_Exception()
            {
                var request = new ActorRequest();
                _mockActorDAO.Setup(x => x.CreateActor(request)).Throws(new
                Exception());
                await Assert.ThrowsAsync<Exception>(() =>
                _controller.CreateActor(request));
            }
            [Fact]
            public async Task CreateActor_Returns_Guid()
            {
                var request = new ActorRequest();
                var expected = new Guid();
                _mockActorDAO.Setup(x => x.CreateActor(request)).ReturnsAsync
                (expected);
                var result = await _controller.CreateActor(request);
                Assert.Equal(expected, result);
            }
            [Fact]
            public async Task CreateActor_Null()
            {
                ActorRequest request = null;
                var expected = new Guid();
                _mockActorDAO.Setup(x => x.CreateActor(request)).ReturnsAsync
                (expected);
                var result = await _controller.CreateActor(request);
                Assert.Equal(expected, result);
            }
            [Fact]
            public async Task UpdateActor_Guid()
            {
                var request = new ActorRequest();
                var expected = new Guid();
                _mockActorDAO.Setup(x => x.UpdateActor(request)).ReturnsAsync
                (expected);
                var result = await _controller.UpdateActor(request);
                Assert.Equal(expected, result);
            }
            [Fact]
            public async Task UpdateActor_Exception()
            {
                var request = new ActorRequest();
                _mockActorDAO.Setup(x => x.UpdateActor(request)).Throws(new
                Exception());
                await Assert.ThrowsAsync<Exception>(() =>
                _controller.UpdateActor(request));
            }
            [Fact]
            public async Task GetActor_Response()
            {
                var actorId = new Guid();
                var expected = new ActorResponse();
                _mockActorDAO.Setup(x => x.GetActor(actorId)).ReturnsAsync
                (expected);
                var result = await _controller.GetActor(actorId);
                Assert.Equal(expected, result);
            }
            [Fact]
            public async Task GetActor_Exception()
            {
                var actorId = new Guid();
                _mockActorDAO.Setup(x => x.GetActor(actorId)).Throws(new
                Exception());
                await Assert.ThrowsAsync<Exception>(() => _controller.GetActor
                (actorId));
            }
            [Fact]
            public async Task GetActor_Null()
            {
                var actorId = new Guid();
                _mockActorDAO.Setup(x => x.GetActor(actorId)).ReturnsAsync
                ((ActorResponse)null);
                var result = await _controller.GetActor(actorId);
                Assert.Null(result);
            }
    }

}
