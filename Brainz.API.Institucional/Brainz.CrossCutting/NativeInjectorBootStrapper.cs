using Brainz.API.Framework.Database.EfCore.Context;
using Brainz.API.Framework.Database.EfCore.Factory;
using Brainz.API.Framework.Database.EfCore.Interface;
using Brainz.API.Framework.Database.EfCore.Repository;
using Brainz.API.Framework.Interfaces;
using Brainz.API.Framework.Services;
using Brainz.Data.Context;
using Brainz.Data.Interfaces;
using Brainz.Data.Repositories;
using Brainz.Service.Interfaces;
using Brainz.Service.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Brainz.CrossCutting
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient<IApiClient, ApiClient>();
            AddServices(services);
            AddDatabase(services);
            AddRepositories(services);
        }

        public static void AddServices(IServiceCollection services)
        {
            services.AddScoped<IExampleService, ExampleService>();
            services.AddScoped<IGraphService, GraphService>();
            services.AddScoped<IRedisServiceBase, RedisServiceBase>();
            services.AddScoped<IInstitutionalService, InstitutionalService>();
            services.AddScoped<IMessagingExternalService, MessagingExternalService>();
            services.AddScoped<ITrilhasIntegrationService, TrilhasIntegrationService>();

        }

        public static void AddDatabase(IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IBrainzDbContext, BrainzDbContext>();
            services.AddScoped<Func<IBrainzDbContext>>((provider) => () => provider.GetService<BrainzDbContext>());
            services.AddScoped<IDbFactory, DbFactory>();
        }

        private static void AddRepositories(IServiceCollection services)
        {
            services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));

            services.AddScoped<IExampleRepository, ExampleRepository>();
        }
    }
}
