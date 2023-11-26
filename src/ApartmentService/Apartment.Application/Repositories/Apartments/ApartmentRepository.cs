using Apartment.Application.Data;
using Apartment.Application.Interfaces.Apartments;
using Apartment.Domain.Entities.Apartments;
using Microsoft.EntityFrameworkCore;

namespace Apartment.Application.Repositories.Apartments;

public class ApartmentRepository : IApartmentRepository
{
    private readonly ApartmentDbContext _dbContext;

    public ApartmentRepository(ApartmentDbContext dbContext)
    {
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    }

    public async ValueTask<long> CountAsync()
        => await _dbContext.Apartments.LongCountAsync();

    public async ValueTask<int> CreateAsync(ApartmentModel entity)
    {
        await _dbContext.Apartments.AddAsync(entity);
        return await _dbContext.SaveChangesAsync();
    }

    public async ValueTask<int> DeleteAsync(long id)
    {
        var entity = await _dbContext
            .Apartments
            .FirstOrDefaultAsync(x => x.Id == id);

        if (entity is null)
            return 0;

        _dbContext.Apartments.Remove(entity);
        return await _dbContext.SaveChangesAsync();
    }

    public async ValueTask<ApartmentModel> GetByIdAsync(long id)
        => await _dbContext.Apartments.FirstOrDefaultAsync(x => x.Id == id);

    public async ValueTask<int> UpdateAsync(ApartmentModel entity)
    {
        _dbContext.Apartments.Update(entity);

        return await _dbContext.SaveChangesAsync();
    }
}
