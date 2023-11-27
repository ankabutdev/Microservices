using Tourism.Application.DTOs.Tourists;
using Tourism.Domain.Entities.Tourists;

namespace Tourism.Infrastructure.Interfaces.Tourists;

public interface ITouristService
{
    public ValueTask<long> CountAsync();

    public ValueTask<Tourist> GetByIdAsync(long touristId);

    public ValueTask<IEnumerable<Tourist>> GetAllAsync();

    public ValueTask<bool> CreateAsync(TouristCreateDto dto);

    public ValueTask<bool> UpdateAsync(long touristId, TouristUpdateDto dto);

    public ValueTask<bool> DeleteAsync(long touristId);
}
