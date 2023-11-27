using MongoDB.Driver;

namespace School.Application.Data;

public class MongoDbContext<TEntity> where TEntity : class
{
    private readonly IMongoCollection<TEntity> _collection;

    public MongoDbContext(MongoDbSettings mongoDbSettings, string collectionName)
    {
        MongoClient client = new MongoClient(mongoDbSettings.ConnectionURI);
        IMongoDatabase database = client.GetDatabase(mongoDbSettings.DatabaseName);
        _collection = database.GetCollection<TEntity>(collectionName);
    }

    public IMongoCollection<TEntity> Collection => _collection;
}
