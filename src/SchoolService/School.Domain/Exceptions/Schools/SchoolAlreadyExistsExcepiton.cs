namespace School.Domain.Exceptions.Schools;

public class SchoolAlreadyExistsExcepiton : NotFoundException
{
    public SchoolAlreadyExistsExcepiton()
    {
        TitleMessage = "School alrady exists!";
    }
}
