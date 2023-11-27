using AutoMapper;
using School.Application.Interfaces.Schools;
using School.Domain.Entities.Students;
using School.Domain.Exceptions.Schools;
using School.Infrastracture.DTOs.Schools;
using School.Infrastracture.Interfaces.Schools;

namespace School.Infrastracture.Services.Schools;

public class SchoolService : ISchoolService
{
    private readonly ISchoolRepository _repository;
    private readonly IMapper _mapper;

    public SchoolService(ISchoolRepository repository,
        IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async ValueTask<long> CountAsync()
        => await _repository.CountAsync();

    public async ValueTask<bool> CreateAsync(SchoolCreateDto dto)
    {
        if (dto is null)
            return false;

        var school = _mapper.Map<SchoolModel>(dto);

        var result = await _repository.CreateAsync(school);
        return result > 0;
    }

    public async ValueTask<bool> DeleteAsync(long schoolId)
    {
        if (schoolId < 0) return false;

        var result = await _repository.DeleteAsync(schoolId);

        // ternary if
        return result > 0 ? true : throw new SchoolNotFoundException();
    }

    public async ValueTask<IEnumerable<SchoolModel>> GetAllAsync()
        => await _repository.GetAllAsync();

    public async ValueTask<SchoolModel> GetByIdAsync(long schoolId)
    {
        var result = await _repository.GetByIdAsync(schoolId);

        if (result is null)
            throw new SchoolNotFoundException();

        return result;
    }

    public async ValueTask<bool> UpdateAsync(long schoolId, SchoolUpdateDto dto)
    {
        // Check if the school exists
        var existingschool = await _repository.GetByIdAsync(schoolId);

        if (existingschool == null)
        {
            return false;
        }

        _mapper.Map(dto, existingschool);

        // Update the UpdatedAt property
        existingschool.UpdatedAt = DateTime.UtcNow;

        // Update the school in the repository
        var result = await _repository.UpdateAsync(existingschool);

        return result > 0;
    }
}
