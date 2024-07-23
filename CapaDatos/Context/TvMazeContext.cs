using CapaDatos.AdoModelEF;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.Context
{
    public class TvMazeContext  : DbContext
    {
        public DbSet<Show> TvShows { get; set; }

        public DbSet<External> TvMazeExternals { get; set; }

        public DbSet<ScheduleDay> TvMazeSchedules { get; set; }

        public DbSet<Rating> TvMazeRatings { get; set; }

        public DbSet<Network> TvMazeNetworks { get; set; }

        public DbSet<Image> TvMazeImages { get; set; }

        public DbSet<Link> TvMazeLinks { get; set; }

        public TvMazeContext() : base("name=tvmazeEntities")
        {
        }

        // Configuración adicional del modelo
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Configuración adicional si es necesaria
         
            //modelBuilder.Entity<Show>()
            //   .Property(e => e.Genres)
            //   .HasConversion(
            //       v => string.Join(',', v),
            //       v => v.Split(',', StringSplitOptions.RemoveEmptyEntries));
            //modelBuilder.Entity<Show>()
            //    .Property(e => e.Updated)
            //    .HasConversion(
            //        v => DateTimeOffset.FromUnixTimeSeconds(v).DateTime,
            //        v => new DateTimeOffset(v).ToUnixTimeSeconds());
        }


        public void CommitAndRefreshChanges()
        {
            bool saveFailed = false;

            do
            {
                try
                {
                    base.SaveChanges();

                    saveFailed = false;

                }
                catch (DbUpdateConcurrencyException ex)
                {
                    saveFailed = true;

                    ex.Entries.ToList()
                              .ForEach(entry =>
                              {
                                  entry.OriginalValues.SetValues(entry.GetDatabaseValues());
                              });

                }
            } while (saveFailed);

        }

        public void RollbackChanges()
        {
            base.ChangeTracker.Entries()
                              .ToList()
                              .ForEach(entry => entry.State = EntityState.Unchanged);
        }

        public void Reload()
        {
            var context = ((IObjectContextAdapter)this).ObjectContext;

            var refreshableObjects =
              base.ChangeTracker.Entries()
                  .Select(c => c.Entity)
                  .ToList();

            context.Refresh(RefreshMode.StoreWins, refreshableObjects);


        }

        public void ReloadClient()
        {
            var context = ((IObjectContextAdapter)this).ObjectContext;

            var refreshableObjects =
              base.ChangeTracker.Entries()
                  .Select(c => c.Entity)
                  .ToList();

            context.Refresh(RefreshMode.ClientWins, refreshableObjects);

        }
    }
}
