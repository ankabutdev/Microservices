using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using School.Application.Data;
using School.Application.Interfaces.Schools;
using School.Domain.Entities.Students;

namespace School.Application.Repositories.Schools;

public class SchoolRepository : ISchoolRepository
{
    private readonly MongoDbContext<SchoolModel> _schoolDbContext;
    private readonly MongoDbContext<CounterModel> _counterDbContext;

    public SchoolRepository(
        MongoDbContext<SchoolModel> schoolDbContext,
        MongoDbContext<CounterModel> counterDbContext)
    {
        _schoolDbContext = schoolDbContext;
        _counterDbContext = counterDbContext;
    }

    public async ValueTask<long> CountAsync()
        => await _schoolDbContext.Collection.CountDocumentsAsync(FilterDefinition<SchoolModel>.Empty);

    public async ValueTask<long> CreateAsync(SchoolModel entity)
    {
        await _schoolDbContext.Collection.InsertOneAsync(entity);
        return 1;
    }

    public async ValueTask<long> DeleteAsync(long id)
    {
        var filter = Builders<SchoolModel>.Filter.Eq(x => x.Id, id);
        var result = await _schoolDbContext.Collection.DeleteOneAsync(filter);
        return result.DeletedCount;
    }

    public async ValueTask<IEnumerable<SchoolModel>> GetAllAsync()
    {
        return await _schoolDbContext.Collection.Find(_ => true).ToListAsync();
    }

    public async ValueTask<SchoolModel> GetByIdAsync(long id)
    {
        var filter = Builders<SchoolModel>.Filter.Eq(x => x.Id, id);
        return await _schoolDbContext.Collection.Find(filter).FirstOrDefaultAsync();
    }

    public async ValueTask<long> UpdateAsync(SchoolModel entity)
    {
        var filter = Builders<SchoolModel>.Filter.Eq(x => x.Id, entity.Id);
        var result = await _schoolDbContext.Collection.ReplaceOneAsync(filter, entity);
        return result.ModifiedCount;
    }

    public async ValueTask<long> IncrementCounterAsync()
    {
        var filter = Builders<CounterModel>.Filter.Empty;
        var update = Builders<CounterModel>.Update.Inc(x => x.Value, 1);

        var options = new FindOneAndUpdateOptions<CounterModel, CounterModel>
        {
            IsUpsert = true,
            ReturnDocument = ReturnDocument.After
        };

        var result = await _counterDbContext
            .Collection
            .FindOneAndUpdateAsync(filter, update, options);

        return result.Value;
    }
}
