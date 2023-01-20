using Moq;
using MockQueryable.Moq;
using Parcial2UCAB.Persistence.Database;
using Parcial2UCAB.Persistence.Entities;

namespace Parcial2UCAB.Test.DataSeed
{
    public static class DataSeed
    {
        public static void SetupDbContextData(this Mock<IParcial2DbContext> _mockContext)
        {
            var actores = new List<Actor>
            {
                new Actor
                {
                    Id = new Guid("47929024-b86e-41cd-b459-733687123d98"),
                    Nombre = "Jhon Martinez",
                    Biografia = "Jhon Martinez Biografia",
                    FechaNacimiento = DateTime.Parse("10-04-1980"),
                    PeliculasActor = new List<PeliculaActor>()
                    {
                        new PeliculaActor
                        {
                            Id = new Guid("316bc1c0-9ac5-43f1-8f6d-d649572e28f9"),
                            ActorId= new Guid("47929024-b86e-41cd-b459-733687123d98"),
                            PeliculaId = new Guid("5c4b2c90-d9ea-41ec-93d4-1e4abb42f561"),
                            Personaje = "Pedro",
                            Orden = 1,
                            Pelicula = new Pelicula
                            {
                                Id= new Guid("5c4b2c90-d9ea-41ec-93d4-1e4abb42f561"),
                                Titulo = "La mascara de pedro",
                                EnCartelera = true,
                                FechaEstreno =  DateTime.Parse("12-12-2021"),
                                Generos = new List<Genero>()
                                {
                                    new Genero()
                                    {
                                        Id= new Guid("4276db87-8d81-486a-be75-140505d87eba"),
                                        Nombre = "Comedia"
                                    },
                                    new Genero()
                                    {
                                        Id= new Guid("30a151c0-b6d7-4cd1-9034-a0441cb96a6f"),
                                        Nombre = "Acción"
                                    },
                                    new Genero()
                                    {
                                        Id= new Guid(),
                                        Nombre = "Drama"
                                    }
                                }
                            }
                        },
                        new PeliculaActor
                        {
                            Id = new Guid("5ea69156-ccbc-483f-a94a-55bc3375a2da"),
                            ActorId = new Guid("47929024-b86e-41cd-b459-733687123d98"),
                            PeliculaId = new Guid("870b6445-cf05-4b87-9ef8-96a759666a8c"),
                            Personaje = "Katherina",
                            Orden = 1,
                            Pelicula = new Pelicula
                            {
                                Id= new Guid("870b6445-cf05-4b87-9ef8-96a759666a8c"),
                                Titulo = "The true",
                                EnCartelera = false,
                                FechaEstreno =  DateTime.Parse("12-12-2019"),
                                Generos = new List<Genero>()
                                {
                                    new Genero()
                                    {
                                        Id= new Guid("0cb56acf-7878-450c-874a-c4b28d3ede2e"),
                                        Nombre = "Suspenso"
                                    }
                                }
                            }
                        },
                        new PeliculaActor
                        {
                            Id = new Guid("e9419802-31e6-4228-a1bb-fcfb0924724b"),
                            ActorId = new Guid("47929024-b86e-41cd-b459-733687123d98"),
                            PeliculaId = new Guid("a0b34ab6-3fb7-4d3b-ad33-065521a528eb"),
                            Personaje = "La Bestia",
                            Orden = 1,
                            Pelicula = new Pelicula
                            {
                                Id= new Guid("a0b34ab6-3fb7-4d3b-ad33-065521a528eb"),
                                Titulo = "La Bella y la Bestia",
                                EnCartelera = false,
                                FechaEstreno =  DateTime.Parse("12-12-1980"),
                                Generos = new List<Genero>()
                                {
                                    new Genero()
                                    {
                                        Id= new Guid("4276db87-8d81-486a-be75-140505d87eba"),
                                        Nombre = "Comedia"
                                    },
                                    new Genero()
                                    {
                                        Id= new Guid("2045c371-eb3c-413f-b2d6-c80544308eec"),
                                        Nombre = "Infantil"
                                    }
                                }
                            }
                        }
                    }
                },
                new Actor
                {
                    Id = new Guid("b8453690-3c39-4d33-85cf-14409e15098a"),
                    Nombre = "Ana Peña",
                    Biografia = "Biografía de Ana Peña",
                    FechaNacimiento = DateTime.Parse("12-12-1978"),
                    PeliculasActor = new List<PeliculaActor>()
                    {
                        new PeliculaActor
                        {
                            Id = new Guid("17fd04c2-82a6-4d74-b34e-8db219c30720"),
                            ActorId= new Guid("b8453690-3c39-4d33-85cf-14409e15098a"),
                            PeliculaId = new Guid("c0556a2f-c581-49d6-9914-cafe90ad179c"),
                            Personaje = "Maria",
                            Orden = 1,
                            Pelicula = new Pelicula
                            {
                                Id= new Guid("c0556a2f-c581-49d6-9914-cafe90ad179c"),
                                Titulo = "En busqueda de la gloria",
                                EnCartelera = true,
                                FechaEstreno =  DateTime.Parse("12-12-2022"),
                                Generos = new List<Genero>()
                                {
                                    new Genero()
                                    {
                                        Id= new Guid("4276db87-8d81-486a-be75-140505d87eba"),
                                        Nombre = "Comedia"
                                    },
                                    new Genero()
                                    {
                                        Id= new Guid("2045c371-eb3c-413f-b2d6-c80544308eec"),
                                        Nombre = "Infantil"
                                    }
                                }
                            }
                        }
                    }
                }
            };


            var peliculasActor = actores.SelectMany(q => q.PeliculasActor).Concat(new List<PeliculaActor>
            {
            });

            var peliculas = peliculasActor.Select(q => q.Pelicula).Concat(new List<Pelicula>
            {
            });

            var generos = peliculas.SelectMany(q => q.Generos).Concat(new List<Genero>
            {
            });

            _mockContext.Setup(c => c.Actores).Returns(actores.AsQueryable().BuildMockDbSet().Object);
            _mockContext.Setup(c => c.PeliculasActor).Returns(peliculasActor.AsQueryable().BuildMockDbSet().Object);
            _mockContext.Setup(c => c.Generos).Returns(generos.AsQueryable().BuildMockDbSet().Object);
            _mockContext.Setup(c => c.Peliculas).Returns(peliculas.AsQueryable().BuildMockDbSet().Object);
            _mockContext.Setup(cx => cx.SaveEfContextChanges(It.IsAny<string>(), It.IsAny<CancellationToken>())).ReturnsAsync(true);

        }
    }
}