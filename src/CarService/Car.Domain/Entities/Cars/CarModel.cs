using Car.Domain.Enums;

namespace Car.Domain.Entities.Cars;

public class CarModel : BaseEntity
{
    public string Name { get; set; } = string.Empty;

    public decimal Price { get; set; }

    public float Discount { get; set; }

    public CarType Type { get; set; }

    public string Description { get; set; } = string.Empty;

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

}
