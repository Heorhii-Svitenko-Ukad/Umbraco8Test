using MongoToUmbracoConverter.DbLogic;
using System.Threading.Tasks;

namespace MongoToUmbracoConverter.Services
{
    public class DataMigrator
    {
        private readonly ApiWriter _apiWriter;
        private readonly UsersService _usersService;

        private const string UpsertUserApi = "";

        public DataMigrator(ApiWriter apiWriter, UsersService usersService)
        {
            _apiWriter = apiWriter;
            _usersService = usersService;
        }

        public async Task MigrateDataAsync()
        {
            var users = await _usersService.GetAllAsync();

            foreach (var user in users)
            {
                // todo handle response
                await _apiWriter.PutJsonAsync(UpsertUserApi, user.ToString());
            }
        }
    }
}
