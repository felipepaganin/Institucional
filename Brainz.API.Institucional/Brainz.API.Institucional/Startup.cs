using Brainz.API.Institucional.Config;
using Brainz.API.Framework.StartupBase;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Globalization;

namespace Brainz.API.Institucional
{
    public class Startup : RestStartupBase
    {
        public IConfiguration Configuration { get; }   

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public override void ConfigureServices(IServiceCollection services)
        {
            base.ConfigureServices(services);

            services.AddHttpContextAccessor();

            services.AddControllers();

            //Cors
            services.AddCorsConfiguration(Configuration);

            // Setting EF Core DBContext
            services.AddDatabaseConfiguration(Configuration);

            //AutoMapper
            services.AddAutoMapperConfiguration();

            // .NET Native DI Abstraction
            services.AddDependencyInjectionConfiguration();

            //Application Insights
            services.AddApplicationInsightsTelemetry();

            //MemoryCache
            services.AddMemoryCache();

            //Redis Cache
            services.AddDistributedRedisCache(options =>
            {
                options.Configuration = Configuration.GetValue<string>("Redis:ConnectionString:Value");
                options.InstanceName = Configuration.GetValue<string>("Redis:InstanceName:Value");
            });
        }

        public override void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            base.Configure(app, env);

            var cultureInfo = new CultureInfo("pt-BR");

            CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
            CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
            }

            app.UseCorsConfig();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}