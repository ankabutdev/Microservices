using Tourism.Domain.Enums;

namespace Tourism.Domain.Entities.Tourists;

public class Tourist : BaseEntity
{
    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public string PhoneNumber { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string PassportSeriaNumber { get; set; } = string.Empty;

    public OrderStatus Status { get; set; }

    public CardType CreditCard { get; set; }

    public DateTime DateOfBirth { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public DateTime UpdatedAt { get; set; }

}
