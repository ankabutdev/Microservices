using School.Domain.Enums;

namespace School.Infrastracture.DTOs.Schools;

public class SchoolCreateDto
{
    public string Name { get; set; } = string.Empty;

    public string PhoneNumber { get; set; } = string.Empty;

    public string Location { get; set; } = string.Empty;

    public Direction Direction { get; set; }

}
