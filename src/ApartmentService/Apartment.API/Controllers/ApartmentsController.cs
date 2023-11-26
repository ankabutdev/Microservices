using Apartment.Infrastructure.DTOs.Apartments;
using Apartment.Infrastructure.Interfaces.Apartments;
using Microsoft.AspNetCore.Mvc;

namespace Apartment.API.Controllers;

[ApiController]
[Route("api/apartments")]
public class ApartmentsController : ControllerBase
{
    private readonly IApartmentService _service;

    public ApartmentsController(IApartmentService service)
    {
        _service = service;
    }

    [HttpGet]
    public async ValueTask<IActionResult> GetAllAsync()
     => Ok(await _service.GetAllAsync());

    [HttpGet("{id}")]
    public async ValueTask<IActionResult> GetByIdAsync(long id)
        => Ok(await _service.GetByIdAsync(id));

    [HttpGet("count")]
    public async ValueTask<IActionResult> CountAsync()
        => Ok(await _service.CountAsync());

    [HttpPost]
    public async ValueTask<IActionResult> CreateAsync([FromForm] ApartmentCreateDto dto)
        => Ok(await _service.CreateAsync(dto));

    [HttpPut]
    public async ValueTask<IActionResult> UpdateAsnyc(long apartmentId, ApartmentUpdateDto dto)
        => Ok(await _service.UpdateAsync(apartmentId, dto));

    [HttpDelete("{apartmentId}")]
    public async ValueTask<IActionResult> DeleteAsync(long apartmentId)
        => Ok(await _service.DeleteAsync(apartmentId));
}
