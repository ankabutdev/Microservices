namespace Tourism.Domain.Exceptions.Tourists;

public class TouristAlreadyExistsException : NotFoundException
{
    public TouristAlreadyExistsException()
    {
        TitleMessage = "Tourist already exits!";
    }
}
