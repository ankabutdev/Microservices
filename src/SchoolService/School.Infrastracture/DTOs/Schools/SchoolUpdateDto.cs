using School.Domain.Enums;

namespace School.Domain.Entities.Students;

public class SchoolUpdateDto
{
    public string Name { get; set; } = string.Empty;

    public string PhoneNumber { get; set; } = string.Empty;

    public string Location { get; set; } = string.Empty;

    public Direction Direction { get; set; }
}
