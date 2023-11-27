using Microsoft.AspNetCore.Mvc;
using School.Domain.Entities.Students;
using School.Infrastracture.DTOs.Schools;
using School.Infrastracture.Interfaces.Schools;

namespace School.API.Controllers;

[Route("api/schools")]
[ApiController]
public class SchoolsController : ControllerBase
{
    private readonly ISchoolService _service;

    public SchoolsController(ISchoolService service)
    {
        _service = service;
    }

    [HttpGet]
    public async ValueTask<IActionResult> GetAllAsync()
        => Ok(await _service.GetAllAsync());

    [HttpGet("{schoolId}")]
    public async ValueTask<IActionResult> GetByIdAsync(long schoolId)
        => Ok(await _service.GetByIdAsync(schoolId));

    [HttpGet("count")]
    public async ValueTask<IActionResult> CountAsync()
        => Ok(await _service.CountAsync());

    [HttpPost]
    public async ValueTask<IActionResult> CreateAsync(SchoolCreateDto dto)
        => Ok(await _service.CreateAsync(dto));

    [HttpPut]
    public async ValueTask<IActionResult> UpdateAsync(long schoolId, SchoolUpdateDto dto)
        => Ok(await _service.UpdateAsync(schoolId, dto));

    [HttpDelete("{schoolId}")]
    public async ValueTask<IActionResult> DeleteAsync(long schoolId)
        => Ok(await _service.DeleteAsync(schoolId));
}
