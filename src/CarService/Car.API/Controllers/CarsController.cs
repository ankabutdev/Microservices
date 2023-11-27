using Car.Infrastracture.DTOs.Cars;
using Car.Infrastracture.Interfaces.Cars;
using Microsoft.AspNetCore.Mvc;

namespace Car.API.Controllers;

[Route("api/cars")]
[ApiController]
public class CarsController : ControllerBase
{
    private readonly ICarService _service;

    public CarsController(ICarService service)
    {
        _service = service;
    }

    [HttpGet]
    public async ValueTask<IActionResult> GetAllAsync()
        => Ok(await _service.GetAllAsync());

    [HttpGet("{carId}")]
    public async ValueTask<IActionResult> GetByIdAsync(long carId)
        => Ok(await _service.GetByIdAsync(carId));

    [HttpGet("count")]
    public async ValueTask<IActionResult> CountAsync()
        => Ok(await _service.CountAsync());

    [HttpPost]
    public async ValueTask<IActionResult> CreateAsync(CarCreateDto dto)
        => Ok(await _service.CreateAsync(dto));

    [HttpPut]
    public async ValueTask<IActionResult> UpdateAsync(long carId, CarUpdateDto dto)
        => Ok(await _service.UpdateAsync(carId, dto));

    [HttpDelete("{carId}")]
    public async ValueTask<IActionResult> DeleteAsync(long carId)
        => Ok(await _service.DeleteAsync(carId));
}
