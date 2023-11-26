using Car.Domain.Entities.Cars;

namespace Car.Application.Interfaces.Cars;

public interface ICarRepository : IRepository<CarModel>
{
}
