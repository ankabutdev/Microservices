namespace Apartment.Domain.Exceptions.Apartments;

public class ApartmentAlreadyExistsException : NotFoundException
{
    public ApartmentAlreadyExistsException()
    {
        TitleMessage = "Apartment already exists!";
    }
}