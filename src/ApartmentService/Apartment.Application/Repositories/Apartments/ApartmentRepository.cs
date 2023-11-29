using Apartment.Application.Data;
using Apartment.Application.Interfaces.Apartments;
using Apartment.Domain.Entities.Apartments;
using Microsoft.EntityFrameworkCore;

namespace Apartment.Application.Repositories.Apartments;

#pragma warning disable

public class ApartmentRepository : IApartmentRepository
{
    private readonly ApartmentDbContext _dbContext;

    public ApartmentRepository(ApartmentDbContext dbContext)
    {
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    }

    public async ValueTask<long> CountAsync()
        => await _dbContext.ApartmentModel.LongCountAsync();

    public async ValueTask<int> CreateAsync(ApartmentModel entity)
    {
        await _dbContext.ApartmentModel.AddAsync(entity);
        return await _dbContext.SaveChangesAsync();
    }

    public async ValueTask<int> DeleteAsync(long id)
    {
        var entity = await _dbContext
            .ApartmentModel
            .FirstOrDefaultAsync(x => x.Id == id);

        if (entity is null)
            return 0;

        _dbContext.ApartmentModel.Remove(entity);
        return await _dbContext.SaveChangesAsync();
    }

    public async ValueTask<IEnumerable<ApartmentModel>> GetAllAsync()
        => await _dbContext.ApartmentModel.ToListAsync();

    public async ValueTask<ApartmentModel> GetByIdAsync(long id)
        => await _dbContext.ApartmentModel.FirstOrDefaultAsync(x => x.Id == id);

    public async ValueTask<int> UpdateAsync(ApartmentModel entity)
    {
        _dbContext.ApartmentModel.Update(entity);

        return await _dbContext.SaveChangesAsync();
    }
}
