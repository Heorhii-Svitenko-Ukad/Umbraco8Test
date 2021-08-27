using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MongoToUmbracoConverter.DbLogic;
using MongoToUmbracoConverter.Services;
using System;
using System.Threading.Tasks;

namespace MongoToUmbracoConverter.ConsoleApp
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            var logger = host.Services.GetRequiredService<ILogger<Program>>();

            DataMigrator migrator;

            try
            {
                migrator = host.Services.GetRequiredService<DataMigrator>();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Startup error");

                return;
            }

            await migrator.MigrateDataAsync();
        }

        private static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((context, services) =>
                    services
                        .AddMigrationServices()
                        .AddDbLogic()
                        .Configure<ApiOptions>(context.Configuration.GetSection(nameof(ApiOptions)))
                        .Configure<MongoDbOptions>(context.Configuration.GetSection(nameof(MongoDbOptions))));
    }
}
