using AutoMapper;
using Car.Application.Interfaces.Cars;
using Car.Domain.Entities.Cars;
using Car.Domain.Exceptions.Cars;
using Car.Infrastracture.DTOs.Cars;
using Car.Infrastracture.Interfaces.Cars;

namespace Car.Infrastracture.Services.Cars;

public class CarService : ICarService
{
    private readonly ICarRepository _repository;
    private readonly IMapper _mapper;

    public CarService(ICarRepository repository,
        IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async ValueTask<long> CountAsync()
        => await _repository.CountAsync();

    public async ValueTask<bool> CreateAsync(CarUpdateDto dto)
    {
        if (dto is null)
            return false;

        var car = _mapper.Map<CarModel>(dto);

        var result = await _repository.CreateAsync(car);
        return result > 0;
    }

    public async ValueTask<bool> DeleteAsync(long carId)
    {
        if (carId < 0) return false;

        var result = await _repository.DeleteAsync(carId);

        // ternary if
        return result > 0 ? true : throw new CarNotFoundException();
    }

    public async ValueTask<IEnumerable<CarModel>> GetAllAsync()
        => await _repository.GetAllAsync();

    public async ValueTask<CarModel> GetByIdAsync(long carId)
    {
        var result = await _repository.GetByIdAsync(carId);

        if (result is null)
            throw new CarNotFoundException();

        return result;
    }
    public async ValueTask<bool> UpdateAsync(long carId, CarUpdateDto dto)
    {
        // Check if the apartment exists
        var existingCar = await _repository.GetByIdAsync(carId);

        if (existingCar == null)
        {
            return false;
        }

        _mapper.Map(dto, existingCar);

        // Update the UpdatedAt property
        existingCar.UpdatedAt = DateTime.UtcNow;

        // Update the apartment in the repository
        var result = await _repository.UpdateAsync(existingCar);

        return result > 0;
    }
}
