namespace Car.Domain.Exceptions.Cars;

public class CarAlreadyExistsException : NotFoundException
{
    public CarAlreadyExistsException()
    {
        TitleMessage = "Car already exists";
    }
}
