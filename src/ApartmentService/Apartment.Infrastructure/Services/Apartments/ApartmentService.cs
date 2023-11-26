using Apartment.Application.Interfaces.Apartments;
using Apartment.Domain.Entities.Apartments;
using Apartment.Domain.Exceptions.Apartments;
using Apartment.Infrastructure.DTOs.Apartments;
using Apartment.Infrastructure.Interfaces.Apartments;
using AutoMapper;

namespace Apartment.Infrastructure.Services.Apartments;

public class ApartmentService : IApartmentService
{
    private readonly IApartmentRepository _repository;
    private readonly IMapper _mapper;

    public ApartmentService(IApartmentRepository repository,
        IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async ValueTask<long> CountAsync()
        => await _repository.CountAsync();

    public async ValueTask<bool> CreateAsync(ApartmentCreateDto dto)
    {
        if (dto is null)
            return false;

        var apartment = _mapper.Map<ApartmentModel>(dto);

        var result = await _repository.CreateAsync(apartment);
        return result > 0;
    }

    public async ValueTask<bool> DeleteAsync(long id)
    {
        if (id < 0) return false;

        var result = await _repository.DeleteAsync(id);

        // ternary if
        return result > 0 ? true : throw new ApartmentNotFoundException();
    }

    public async ValueTask<IEnumerable<ApartmentModel>> GetAllAsync()
        => await _repository.GetAllAsync();

    public async ValueTask<ApartmentModel> GetByIdAsync(long id)
    {
        var result = await _repository.GetByIdAsync(id);

        if (result is null)
            throw new ApartmentNotFoundException();

        return result;
    }

    public async ValueTask<bool> UpdateAsync(long apartmentId, ApartmentUpdateDto dto)
    {
        // Check if the apartment exists
        var existingApartment = await _repository.GetByIdAsync(apartmentId);

        if (existingApartment == null)
        {
            return false;
        }

        _mapper.Map(dto, existingApartment);

        // Update the UpdatedAt property
        existingApartment.UpdatedAt = DateTime.UtcNow;

        // Update the apartment in the repository
        var result = await _repository.UpdateAsync(existingApartment);

        return result > 0;
    }
}
