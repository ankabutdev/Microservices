namespace School.Domain.Exceptions.Schools;

public class SchoolNotFoundException : NotFoundException
{
    public SchoolNotFoundException()
    {
        TitleMessage = "School not found!";
    }
}