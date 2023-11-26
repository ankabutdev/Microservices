using Apartment.Application.Interfaces.Apartments;
using Apartment.Domain.Entities.Apartments;
using Apartment.Infrastructure.DTOs.Apartments;
using Apartment.Infrastructure.Interfaces.Apartments;

namespace Apartment.Infrastructure.Services.Apartments;

public class ApartmentService : IApartmentService
{
    private readonly IApartmentRepository _repository;

    public ApartmentService(IApartmentRepository repository)
    {
        _repository = repository;
    }

    public async ValueTask<long> CountAsync()
        => await _repository.CountAsync();

    public ValueTask<bool> CreateAsync(ApartmentCreateDto dto)
    {
        throw new NotImplementedException();
    }

    public ValueTask<bool> DeleteAsync(long id)
    {
        throw new NotImplementedException();
    }

    public ValueTask<IEnumerable<ApartmentModel>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public ValueTask<ApartmentModel> GetByIdAsync(long id)
    {
        throw new NotImplementedException();
    }

    public ValueTask<bool> UpdateAsync(ApartmentUpdateDto dto)
    {
        throw new NotImplementedException();
    }
}
