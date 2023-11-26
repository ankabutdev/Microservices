using Apartment.Domain.Enums;

namespace Apartment.Domain.Entities.Apartments;

public class ApartmentModel : BaseEntity
{
    public string Name { get; set; } = string.Empty;

    public RoomStatus Status { get; set; }

    public string Title { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public DateTime UpdatedAt { get; set; }

}
