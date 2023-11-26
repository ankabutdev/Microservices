using Car.Domain.Enums;

namespace Car.Infrastracture.DTOs.Cars;

public class CarUpdateDto
{
    public string Name { get; set; } = string.Empty;

    public decimal Price { get; set; }

    public float Discount { get; set; }

    public CarType Type { get; set; }

    public string Description { get; set; } = string.Empty;

}
