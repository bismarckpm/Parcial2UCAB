using Moq;
using Parcial2UCAB.Persistence.DAOs.Implementations;
using Parcial2UCAB.Persistence.Entities;
using Parcial2UCAB.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcial2UCAB.Test.DAOs
{
    public class ActorDAOTest
    {

       
        private readonly ActorDAO actor;

        [Fact]
        public void RegistroExitoso()
        {
            ActorRequest entrada = new ActorRequest()
        {
                Nombre = "Jhon Martinez",
              //  Apellido = "dbajdbsjdba",
                Tipologia = "Protagonista",
                Biografia = "Jhon Martinez Biografia",
                FechaNacimiento = DateTime.Parse("10-04-1980"),
                FotoURL= "xzbczbcbx"

            };

       

        //act
        var result = actor.CreateActor(entrada);


        }
        [Fact]
        public void Exception()
        {

        }
    }
}
