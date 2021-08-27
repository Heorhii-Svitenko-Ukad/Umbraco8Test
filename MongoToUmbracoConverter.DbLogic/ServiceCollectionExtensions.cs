using Microsoft.Extensions.DependencyInjection;

namespace MongoToUmbracoConverter.DbLogic
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDbLogic(this IServiceCollection services) =>
            services
                .AddScoped<MongoDbService>()
                .AddScoped<UsersService>();
    }
}
