using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using School.Application.Data;
using School.Application.Interfaces.Schools;
using School.Domain.Entities.Students;

public class SchoolRepository : ISchoolRepository
{
    private readonly IMongoCollection<SchoolModel> _schoolCollection;
    private readonly IMongoCollection<CounterModel> _counterCollection;

    public SchoolRepository(IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("MongoDbConnection");
        var databaseName = "SchoolDb";

        var client = new MongoClient(connectionString);
        var database = client.GetDatabase(databaseName);

        _schoolCollection = database.GetCollection<SchoolModel>("schools");
        _counterCollection = database.GetCollection<CounterModel>("schoolscounters");
    }

    public async ValueTask<long> CountAsync()
    {
        return await _schoolCollection
            .CountDocumentsAsync(FilterDefinition<SchoolModel>.Empty);
    }

    public async ValueTask<long> CreateAsync(SchoolModel entity)
    {
        var counter = await _counterCollection.FindOneAndUpdateAsync(
            Builders<CounterModel>.Filter.Eq(c => c.Id, "productCounter"),
            Builders<CounterModel>.Update.Inc(c => c.Value, 1),
            new FindOneAndUpdateOptions<CounterModel, CounterModel>
            {
                IsUpsert = true,
                ReturnDocument = ReturnDocument.After
            });
        
        entity.Id = counter.Value;

        await _schoolCollection.InsertOneAsync(entity);
        return 1;
    }

    public async ValueTask<long> DeleteAsync(long id)
    {
        var filter = Builders<SchoolModel>.Filter.Eq(x => x.Id, id);
        var result = await _schoolCollection.DeleteOneAsync(filter);
        return result.DeletedCount;
    }

    public async ValueTask<IEnumerable<SchoolModel>> GetAllAsync()
    {
        return await _schoolCollection.Find(_ => true).ToListAsync();
    }

    public async ValueTask<SchoolModel> GetByIdAsync(long id)
    {
        var filter = Builders<SchoolModel>.Filter.Eq(x => x.Id, id);
        return await _schoolCollection.Find(filter).FirstOrDefaultAsync();
    }

    public async ValueTask<long> UpdateAsync(SchoolModel entity)
    {
        var filter = Builders<SchoolModel>.Filter.Eq(x => x.Id, entity.Id);
        var result = await _schoolCollection.ReplaceOneAsync(filter, entity);
        return result.ModifiedCount;
    }
}
