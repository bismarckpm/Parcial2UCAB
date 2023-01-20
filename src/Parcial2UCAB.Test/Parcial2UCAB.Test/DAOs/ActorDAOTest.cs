using Microsoft.Extensions.Logging;
using Moq;
using Parcial2UCAB.Persistence.DAOs.Implementations;
using Parcial2UCAB.Persistence.DAOs.Interfaces;
using Parcial2UCAB.Persistence.Database;
using Parcial2UCAB.Test.DataSeed;

namespace Parcial2UCAB.Test.DAOs
{
    public class ActorDAOTest
    {
        private readonly IActorDAO _dao;
        private readonly Mock<IParcial2DbContext> _contextMock;
        private readonly Mock<ILogger<ActorDAO>> _mockLogger;

        public ActorDAOTest()
        {
            _contextMock = new Mock<IParcial2DbContext>();
            _mockLogger = new Mock<ILogger<ActorDAO>>();
            _dao = new ActorDAO(_contextMock.Object, _mockLogger.Object);
            _contextMock.SetupDbContextData();
        }

        [Fact]
        public async Task ShouldCreateNewActor()
        { 

        }


    }

       

}
