using Tourism.Domain.Enums;

namespace Tourism.Application.DTOs.Tourists;

public class TouristUpdateDto
{
    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public string PhoneNumber { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public OrderStatus Status { get; set; }

    public CardType CreditCard { get; set; }

    public DateTime DateOfBirth { get; set; }

}
