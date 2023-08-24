using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace Brainz.API.Institucional
{
    /// <summary>
    /// Program class
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Application Main()
        /// </summary>
        /// <param name="args">The arguments</param>
        public static void Main(string[] args)
        {           
            CreateWebHostBuilder(args).Build().Run();
        }      

        /// <summary>
        /// CreateWebHostBuilder
        /// </summary>
        /// <param name="args">The arguments</param>
        /// <returns>The WebHostBuilder</returns>
        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((hostingContext, config) =>
                {
                    var settings = config.Build();

                    config.AddAzureAppConfiguration(options =>
                    {
                        options.Connect(settings["AppConfiguration:ConnectionString"])
                        .ConfigureRefresh(refresh =>
                        {
                            refresh.Register("Sentinel:RefreshKeys", true);
                        });
                    });
                }).UseStartup<Startup>();
    }
}