using Apartment.Domain.Entities.Apartments;
using Apartment.Infrastructure.DTOs.Apartments;

namespace Apartment.Infrastructure.Interfaces.Apartments;

public interface IApartmentService
{
    public ValueTask<IEnumerable<ApartmentModel>> GetAllAsync();

    public ValueTask<bool> CreateAsync(ApartmentCreateDto dto);

    public ValueTask<bool> UpdateAsync(long apartmentId, ApartmentUpdateDto dto);

    public ValueTask<bool> DeleteAsync(long id);

    public ValueTask<ApartmentModel> GetByIdAsync(long id);

    public ValueTask<long> CountAsync();
}
