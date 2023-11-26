using Apartment.Domain.Enums;

namespace Apartment.Infrastructure.DTOs.Apartments;

public class ApartmentUpdateDto
{
    public string Name { get; set; } = string.Empty;

    public RoomStatus Status { get; set; }

    public string Title { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;
}
