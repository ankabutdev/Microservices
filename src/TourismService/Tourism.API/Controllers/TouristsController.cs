using Microsoft.AspNetCore.Mvc;
using Tourism.Application.DTOs.Tourists;
using Tourism.Infrastructure.Interfaces.Tourists;

namespace Tourism.API.Controllers;

[Route("api/tourists")]
[ApiController]
public class TouristsController : ControllerBase
{
    private readonly ITouristService _service;

    public TouristsController(ITouristService service)
    {
        _service = service;
    }

    [HttpGet]
    public async ValueTask<IActionResult> GetAllAsync()
        => Ok(await _service.GetAllAsync());

    [HttpGet("{touristId}")]
    public async ValueTask<IActionResult> GetByIdAsync(long touristId)
        => Ok(await _service.GetByIdAsync(touristId));

    [HttpGet("count")]
    public async ValueTask<IActionResult> CountAsync()
        => Ok(await _service.CountAsync());

    [HttpPost]
    public async ValueTask<IActionResult> CreateAsync(TouristCreateDto dto)
        => Ok(await _service.CreateAsync(dto));

    [HttpPut]
    public async ValueTask<IActionResult> UpdateAsync(long touristId, TouristUpdateDto dto)
        => Ok(await _service.UpdateAsync(touristId, dto));

    [HttpDelete("{touristId}")]
    public async ValueTask<IActionResult> DeleteAsync(long touristId)
        => Ok(await _service.DeleteAsync(touristId));
}
