namespace Tourism.Domain.Exceptions.Tourists;

public class TouristNotFoundException : NotFoundException
{
    public TouristNotFoundException()
    {
        TitleMessage = "Tourist not found!";
    }
}
