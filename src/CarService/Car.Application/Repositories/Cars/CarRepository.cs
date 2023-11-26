using Car.Application.Data;
using Car.Application.Interfaces.Cars;
using Car.Domain.Entities.Cars;
using Microsoft.EntityFrameworkCore;

namespace Car.Application.Repositories.Cars;

#pragma warning disable

public class CarRepository : ICarRepository
{
    private readonly CarDbContext _dbContext;

    public CarRepository(CarDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async ValueTask<long> CountAsync()
        => await _dbContext.Cars.LongCountAsync();

    public async ValueTask<long> CreateAsync(CarModel entity)
    {
        await _dbContext.Cars.AddAsync(entity);
        return await _dbContext.SaveChangesAsync();
    }

    public async ValueTask<long> DeleteAsync(long id)
    {
        var entity = await _dbContext
            .Cars
            .FirstOrDefaultAsync(x => x.Id == id);

        if (entity is null)
            return 0;

        _dbContext.Cars.Remove(entity);
        return await _dbContext.SaveChangesAsync();
    }

    public async ValueTask<IEnumerable<CarModel>> GetAllAsync()
        => await _dbContext.Cars.ToListAsync();

    public async ValueTask<CarModel> GetByIdAsync(long id)
        => await _dbContext.Cars.FirstOrDefaultAsync(x => x.Id == id);

    public async ValueTask<long> UpdateAsync(CarModel entity)
    {
        _dbContext.Cars.Update(entity);
        return await _dbContext.SaveChangesAsync();
    }
}
