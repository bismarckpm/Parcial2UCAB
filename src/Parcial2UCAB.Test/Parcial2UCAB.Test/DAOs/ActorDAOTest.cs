using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Parcial2UCAB.Persistence.Database;
using Parcial2UCAB.Persistence.Entities;
using Parcial2UCAB.Persistence.DAOs.Implementations;
using Parcial2UCAB.Persistence.DAOs.Interfaces;
using Parcial2UCAB.BussinesLogic.Enums;
using Parcial2UCAB.Requests;
using Parcial2UCAB.Test.DataSeed;
using Bogus;
using Xunit;
using Moq;
using ActorDAO = Parcial2UCAB.Persistence.DAOs.Implementations.ActorDAO;
using Microsoft.EntityFrameworkCore;

namespace Parcial2UCAB.Test.DAOs
{
    public class ActorDAOTest
    {
        private readonly Mock<ILogger<ActorDAO>> logger;
        private readonly ActorDAO _dao;
        private readonly Mock<IParcial2DbContext> _contextMock;
        private readonly Mock<IActorDAO> _servicesMock;
        public ActorDAOTest()
        {
            var faker = new Faker();
            var log = new Mock<ILogger<ActorDAO>>();
            _contextMock = new Mock<IParcial2DbContext>();
            _dao = new ActorDAO(_contextMock.Object, log.Object);
            _contextMock.SetupDbContextData();
        }

        [Fact]
        public Task CreateActor()
        {
            _contextMock.Setup(d => d.DbContext.SaveChanges()).Returns(1);

            var actores = new ActorRequest()
            {
                    Nombre = "prueba",
                    Biografia = "biografia",
                    FechaNacimiento = DateTime.Today,
                    FotoURL = "url/tipo/carpeta/ruta",
                    tipo = TipoActor.Protagonista                
            };

            var result = _dao.CreateActor(actores);
            Assert.IsType<Guid>(result);
            return Task.CompletedTask;
        }
    }
}
