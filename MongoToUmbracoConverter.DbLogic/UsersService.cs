using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MongoToUmbracoConverter.DbLogic
{
    public class UsersService
    {
        private const string CollectionName = "users";

        private readonly IMongoCollection<BsonDocument> _collection;

        public UsersService(MongoDbService dbService)
        {
            _collection = dbService.GetCollection(CollectionName);
        }

        public async Task<IEnumerable<BsonDocument>> GetAllAsync()
        {
            return (await _collection.FindAsync(new BsonDocument())).ToEnumerable();
        }
    }
}
