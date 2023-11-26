namespace Apartment.Domain.Exceptions.Apartments;

public class ApartmentNotFoundException : NotFoundException
{
    public ApartmentNotFoundException()
    {
        TitleMessage = "Apartment not found!";
    }
}
