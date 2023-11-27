using AutoMapper;
using Tourism.Application.DTOs.Tourists;
using Tourism.Application.Interfaces.Tourits;
using Tourism.Domain.Entities.Tourists;
using Tourism.Domain.Exceptions.Tourists;
using Tourism.Infrastructure.Interfaces.Tourists;

namespace Tourism.Infrastructure.Services.Tourists;

public class TouristService : ITouristService
{
    private readonly ITouristRepository _repository;
    private readonly IMapper _mapper;

    public TouristService(ITouristRepository repository,
        IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async ValueTask<long> CountAsync()
        => await _repository.CountAsync();

    public async ValueTask<bool> CreateAsync(TouristCreateDto dto)
    {
        if (dto is null)
            return false;

        var tourist = _mapper.Map<Tourist>(dto);

        var result = await _repository.CreateAsync(tourist);
        return result > 0;
    }

    public async ValueTask<bool> DeleteAsync(long touristId)
    {
        if (touristId < 0) return false;

        var result = await _repository.DeleteAsync(touristId);

        // ternary if
        return result > 0 ? true : throw new TouristNotFoundException();
    }

    public async ValueTask<IEnumerable<Tourist>> GetAllAsync()
        => await _repository.GetAllAsync();

    public async ValueTask<Tourist> GetByIdAsync(long touristId)
    {
        var result = await _repository.GetByIdAsync(touristId);

        if (result is null)
            throw new TouristNotFoundException();

        return result;
    }

    public async ValueTask<bool> UpdateAsync(long touristId, TouristUpdateDto dto)
    {
        // Check if the tourist exists
        var existingtourist = await _repository.GetByIdAsync(touristId);

        if (existingtourist == null)
        {
            return false;
        }

        _mapper.Map(dto, existingtourist);

        // Update the UpdatedAt property
        existingtourist.UpdatedAt = DateTime.UtcNow;

        // Update the tourist in the repository
        var result = await _repository.UpdateAsync(existingtourist);

        return result > 0;
    }
}
