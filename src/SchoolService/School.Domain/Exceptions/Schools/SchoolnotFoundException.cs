namespace School.Domain.Exceptions.Schools;

public class SchoolnotFoundException : NotFoundException
{
    public SchoolnotFoundException()
    {
        TitleMessage = "School not found!";
    }
}
