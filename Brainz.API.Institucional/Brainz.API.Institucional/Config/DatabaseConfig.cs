using Brainz.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Brainz.API.Institucional.Config
{
    public static class DatabaseConfig
    {
        public static void AddDatabaseConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            var dbConnectionString = configuration.GetValue<string>("DB:ConnectionString:Institucional");

            services.AddDbContext<BrainzDbContext>(options =>
            {
                options.UseSqlServer(dbConnectionString);
            });
        }
    }
}
