using Microsoft.EntityFrameworkCore;
using Tourism.Application.Data;
using Tourism.Application.Interfaces.Tourits;
using Tourism.Domain.Entities.Tourists;

public class TouristRepository : ITouristRepository
{
    private readonly TouristDbContext _dbContext;

    public TouristRepository(TouristDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async ValueTask<long> CountAsync()
    {
        return await _dbContext.Tourists.LongCountAsync();
    }

    public async ValueTask<long> CreateAsync(Tourist entity)
    {
        await _dbContext.Tourists.AddAsync(entity);
        await _dbContext.SaveChangesAsync();
        return entity.Id;
    }

    public async ValueTask<long> DeleteAsync(long id)
    {
        var tourist = await _dbContext.Tourists.FirstOrDefaultAsync(x => x.Id == id);

        if (tourist is null)
            return 0;

        _dbContext.Tourists.Remove(tourist);
        return await _dbContext.SaveChangesAsync();
    }

    public async ValueTask<IEnumerable<Tourist>> GetAllAsync()
    {
        return await _dbContext.Tourists.ToListAsync();
    }

    public async ValueTask<Tourist> GetByIdAsync(long id)
    {
        return await _dbContext.Tourists.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async ValueTask<long> UpdateAsync(Tourist entity)
    {
        _dbContext.Tourists.Update(entity);
        return await _dbContext.SaveChangesAsync();
    }
}
