using Microsoft.Extensions.DependencyInjection;

namespace MongoToUmbracoConverter.Services
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddMigrationServices(this IServiceCollection services) =>
            services
                .AddScoped<ApiWriter>()
                .AddScoped<DataMigrator>();
    }
}
