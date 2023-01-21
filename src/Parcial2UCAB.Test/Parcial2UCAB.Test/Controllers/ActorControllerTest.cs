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

        [Fact]
        public async Task CreateActor()
        {
            _daoMock.Setup(x => x.CreateActor(It.IsAny<ActorRequest>())).ReturnsAsync(new Guid());

            var result = await _controller.CreateActor(new ActorRequest());

            Assert.IsType<Guid>(result);
        }

		public async Task CreateActorException()
		{
            _daoMock.Setup(x => x.CreateActor(It.IsAny<ActorRequest>())).ThrowsAsync(new Exception());

			await Assert.ThrowsAsync<Exception>(() => _controller.CreateActor(new ActorRequest()));
		}

		[Fact]
        public async Task GetActor()
        {
            var actorId = Guid.NewGuid();
            _daoMock.Setup(x => x.GetActor(It.IsAny<Guid>())).ReturnsAsync(new ActorResponse());

            var result = await _controller.GetActor(actorId);

            Assert.IsType<ActorResponse>(result);
        }

		[Fact]
		public async Task GetActorException()
		{
			_daoMock.Setup(x => x.GetActor(It.IsAny<Guid>())).ReturnsAsync(new ActorResponse());

			await Assert.ThrowsAsync<Exception>(() => _controller.GetActor(It.IsAny<Guid>()));
		}


	}
}
