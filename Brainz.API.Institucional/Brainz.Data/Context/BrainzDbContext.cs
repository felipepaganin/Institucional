using Brainz.API.Framework.Database.EfCore.Context;
using Brainz.Domain.Entities;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace Brainz.Data.Context
{
    public class BrainzDbContext : DbContext, IBrainzDbContext
    {
        public BrainzDbContext(DbContextOptions<BrainzDbContext> options)
            : base(options)
        {
        }

        public DbContext GetDbContext()
        {
            return this;
        }

        public DbSet<Example> Example { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<ValidationResult>();
            //modelBuilder.Ignore<Event>();

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                return base.SaveChangesAsync(cancellationToken);
            }
            catch (DbUpdateConcurrencyException updateConcurrencyException)
            {
                Debug.Print("DbUpdateConcurrencyException");
                Debug.Print(updateConcurrencyException.InnerException.Message);
                throw updateConcurrencyException;
            }
            catch (DbUpdateException updateException)
            {
                Debug.Print("DbUpdateException");
                Debug.Print(updateException.InnerException.Message);
                throw updateException;
            }
        }

    }
}