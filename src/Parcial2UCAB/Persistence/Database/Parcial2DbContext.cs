using Microsoft.EntityFrameworkCore;
using Parcial2UCAB.Persistence.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using System;
using static Parcial2UCAB.Persistence.Entities.Actor;

namespace Parcial2UCAB.Persistence.Database
{
    public class Parcial2DbContext : DbContext, IParcial2DbContext
    {
        public Parcial2DbContext()
        {
        }

        public Parcial2DbContext(DbContextOptions<Parcial2DbContext> options) : base(options)
        {
        }

        public DbContext DbContext
        {
            get
            {
                return this;
            }
        }

        public virtual DbSet<Actor> Actores
        {
            get; set;
        }

        public virtual DbSet<Pelicula> Peliculas
        {
            get; set;
        }

        public virtual DbSet<Genero> Generos
        {
            get; set;
        }

        public virtual DbSet<PeliculaActor> PeliculasActor
        {
            get; set;
        }

        public IDbContextTransactionProxy BeginTransaction()
        {
            return new DbContextTransactionProxy(this);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(Parcial2DbContext).Assembly);
            modelBuilder
            .Entity<Actor>()
            .Property(e => e.tipoActor)
            .HasConversion(
            v => v.ToString(),
            v => (Tipologia)Enum.Parse(typeof(Tipologia), v));
        }

        virtual public void ChangeEntityState<TEntity>(TEntity entity, EntityState state)
        {
            Entry(entity).State = state;
        }

        public async Task<bool> SaveEfContextChanges(CancellationToken cancellationToken = default)
        {
            return await SaveChangesAsync(cancellationToken) >= 0;
        }

        public async Task<bool> SaveEfContextChanges(string user, CancellationToken cancellationToken = default)
        {
            return await SaveChangesAsync(user, cancellationToken) >= 0;
        }

        public async Task<int> SaveChangesAsync(string user, CancellationToken cancellationToken = default)
        {
            var state = new List<EntityState>
            {
                EntityState.Added,
                EntityState.Modified
            };

            var entries = ChangeTracker.Entries().Where(e =>
                e.Entity is BaseEntity && state.Any(s => e.State == s)
            );

            var dt = DateTime.UtcNow;

            foreach (var entityEntry in entries)
            {
                var entity = (BaseEntity)entityEntry.Entity;

                if (entityEntry.State == EntityState.Added)
                {
                    entity.CreatedAt = dt;
                    entity.CreatedBy = user;
                    Entry(entity).Property(x => x.UpdatedAt).IsModified = false;
                    Entry(entity).Property(x => x.UpdatedBy).IsModified = false;
                }

                if (entityEntry.State == EntityState.Modified)
                {
                    entity.UpdatedAt = dt;
                    entity.UpdatedBy = user;
                    Entry(entity).Property(x => x.CreatedAt).IsModified = false;
                    Entry(entity).Property(x => x.CreatedBy).IsModified = false;
                }
            }

            return await base.SaveChangesAsync(cancellationToken);
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var state = new List<EntityState> { EntityState.Added, EntityState.Modified };

            var entries = ChangeTracker.Entries().Where(e =>
                e.Entity is BaseEntity && state.Any(s => e.State == s)
            );

            var dt = System.DateTime.UtcNow;

            foreach (var entityEntry in entries)
            {
                var entity = (BaseEntity)entityEntry.Entity;

                if (entityEntry.State == EntityState.Added)
                {
                    entity.CreatedAt = dt;
                    Entry(entity).Property(x => x.UpdatedAt).IsModified = false;
                }

                if (entityEntry.State == EntityState.Modified)
                {
                    entity.UpdatedAt = dt;
                    Entry(entity).Property(x => x.CreatedAt).IsModified = false;
                }
            }

            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}