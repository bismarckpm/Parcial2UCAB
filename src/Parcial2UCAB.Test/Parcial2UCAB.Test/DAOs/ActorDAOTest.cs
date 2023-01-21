using Microsoft.EntityFrameworkCore;
using Moq;
using Parcial2UCAB.Persistence.DAOs.Implementations;
using Parcial2UCAB.Persistence.Database;
using Parcial2UCAB.Persistence.Entities;
using Parcial2UCAB.Requests;
using Parcial2UCAB.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Parcial2UCAB.Test.DAOs
{
    public class ActorDAOTest
    {

        Mock<IParcial2DbContext> context;

        private readonly ActorDAO actor;

        [Fact]
        public void RegistroExitoso()
        {

            var entity = new ActorRequest
            {
                Nombre = "Jhon Martinez",
                Apellido = "dbajdbsjdba",
                Tipologia = "Protagonista",
                Biografia = "Jhon Martinez Biografia",
                FechaNacimiento = DateTime.Parse("10-04-1980"),
                FotoURL = "xzbczbcbx"
            };




            //act
            var result = actor.CreateActor(entity);


        }
        [Fact]
        public void Exception()
        {

            var entity = new ActorRequest
            {

                Nombre = "Jhon Martinez",
                Apellido = "dbajdbsjdba",
                Tipologia = "Protagonista",
                Biografia = "Jhon Martinez Biografia",
                FechaNacimiento = DateTime.Parse("10-1980"),
                FotoURL = "xzbczbcbx"

            };
            context.Setup(set => set.DbContext.SaveChanges()).Throws(new Exception());
            Assert.Throws<Exception>(() => actor.CreateActor(entity));
        }


        [Fact]
        public async Task ExceptionGET()
        {
            var ex = await Assert.ThrowsAsync<NullReferenceException>(() => actor.GetActor(It.IsAny<Guid>()));

            Assert.IsType<NullReferenceException>(ex);
            Assert.Contains("Nombre de la pelicula requerido.", ex.Message);
        }
    }
}
