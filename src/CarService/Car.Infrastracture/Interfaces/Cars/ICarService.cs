using Car.Domain.Entities.Cars;
using Car.Infrastracture.DTOs.Cars;

namespace Car.Infrastracture.Interfaces.Cars;

public interface ICarService
{
    public ValueTask<long> CountAsync();

    public ValueTask<CarModel> GetByIdAsync(long carId);

    public ValueTask<IEnumerable<CarModel>> GetAllAsync();

    public ValueTask<bool> CreateAsync(CarCreateDto dto);

    public ValueTask<bool> UpdateAsync(long carId, CarUpdateDto dto);

    public ValueTask<bool> DeleteAsync(long carId);
}
