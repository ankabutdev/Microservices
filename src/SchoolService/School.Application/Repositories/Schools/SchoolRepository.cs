using Microsoft.EntityFrameworkCore;
using School.Application.Data;
using School.Application.Interfaces.Schools;
using School.Domain.Entities.Students;

namespace School.Application.Repositories.Schools;

#pragma warning disable

public class SchoolRepository : ISchoolRepository
{
    private readonly SchoolDbContext _dbContext;

    public SchoolRepository(SchoolDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async ValueTask<long> CountAsync()
        => await _dbContext.Schools.LongCountAsync();

    public async ValueTask<long> CreateAsync(SchoolModel entity)
    {
        await _dbContext.Schools.AddAsync(entity);
        return await _dbContext.SaveChangesAsync();
    }

    public async ValueTask<long> DeleteAsync(long id)
    {
        var entity = await _dbContext
            .Schools
            .FirstOrDefaultAsync(x => x.Id == id);

        if (entity is null)
            return 0;

        _dbContext.Schools.Remove(entity);
        return await _dbContext.SaveChangesAsync();
    }

    public async ValueTask<IEnumerable<SchoolModel>> GetAllAsync()
        => await _dbContext.Schools.ToListAsync();

    public async ValueTask<SchoolModel> GetByIdAsync(long id)
        => await _dbContext.Schools.FirstOrDefaultAsync(x => x.Id == id);

    public async ValueTask<long> UpdateAsync(SchoolModel entity)
    {
        _dbContext.Schools.Update(entity);
        return await _dbContext.SaveChangesAsync();
    }
}