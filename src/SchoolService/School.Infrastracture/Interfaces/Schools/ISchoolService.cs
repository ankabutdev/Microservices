using School.Domain.Entities.Students;
using School.Infrastracture.DTOs.Schools;

namespace School.Infrastracture.Interfaces.Schools;

public interface ISchoolService
{
    public ValueTask<long> CountAsync();

    public ValueTask<SchoolModel> GetByIdAsync(long schoolId);

    public ValueTask<IEnumerable<SchoolModel>> GetAllAsync();

    public ValueTask<bool> CreateAsync(SchoolCreateDto dto);

    public ValueTask<bool> UpdateAsync(long schoolId, SchoolUpdateDto dto);

    public ValueTask<bool> DeleteAsync(long schoolId);
}
