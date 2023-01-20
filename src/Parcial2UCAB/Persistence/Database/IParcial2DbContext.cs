using Parcial2UCAB.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Threading;

namespace Parcial2UCAB.Persistence.Database
{
    public interface IParcial2DbContext
    {
        DbContext DbContext
        {
            get;
        }

        DbSet<Actor> Actores
        {
            get; set;
        }

        DbSet<Pelicula> Peliculas
        {
            get; set;
        }

        DbSet<Genero> Generos
        {
            get; set;
        }

        DbSet<PeliculaActor> PeliculasActor
        {
            get; set;
        }


        IDbContextTransactionProxy BeginTransaction();

        void ChangeEntityState<TEntity>(TEntity entity, EntityState state);

        Task<bool> SaveEfContextChanges(string user, CancellationToken cancellationToken = default);

    }
}
