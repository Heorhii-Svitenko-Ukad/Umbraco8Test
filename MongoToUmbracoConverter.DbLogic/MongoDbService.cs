using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Linq;

namespace MongoToUmbracoConverter.DbLogic
{
    public class MongoDbService
    {
        private readonly IMongoDatabase _db;

        public MongoDbService(MongoDbSettings settings)
        {
            MongoClient client = new();

            ValidateDbName(client, settings.DbName);

            _db = client.GetDatabase(settings.DbName);
        }

        public IMongoCollection<BsonDocument> GetCollection(string collectionName)
        {
            ValidateCollectionName(collectionName);

            return _db.GetCollection<BsonDocument>(collectionName);
        }

        private void ValidateCollectionName(string collectionName)
        {
            var names = _db
                .ListCollectionNames()
                .ToEnumerable();

            if (!names.Contains(collectionName))
            {
                throw new ArgumentException(collectionName + " does not exist");
            }
        }

        private void ValidateDbName(MongoClient client, string dbName)
        {
            var names = client
                .ListDatabaseNames()
                .ToEnumerable();

            if (!names.Contains(dbName))
            {
                throw new ArgumentException(dbName + " does not exist");
            }
        }
    }
}
