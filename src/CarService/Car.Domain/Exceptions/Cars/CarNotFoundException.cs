namespace Car.Domain.Exceptions.Cars;

public class CarNotFoundException : NotFoundException
{
    public CarNotFoundException()
    {
        TitleMessage = "Car not found!";
    }
}
