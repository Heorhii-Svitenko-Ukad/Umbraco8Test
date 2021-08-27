using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Linq;

namespace MongoToUmbracoConverter.DbLogic
{
    public class MongoDbService
    {
        private readonly IMongoDatabase _db;

        public MongoDbService(IOptions<MongoDbOptions> options)
        {
            var dbOptions = options.Value;
            MongoClient client = new(dbOptions.ConnectionString);

            ValidateDbName(client, dbOptions.DbName);
            _db = client.GetDatabase(dbOptions.DbName);
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
                throw new ArgumentException("Collection " + collectionName + " does not exist");
            }
        }

        private void ValidateDbName(MongoClient client, string dbName)
        {
            var names = client
                .ListDatabaseNames()
                .ToEnumerable();

            if (!names.Contains(dbName))
            {
                throw new ArgumentException("DB " + dbName + " does not exist");
            }
        }
    }
}
