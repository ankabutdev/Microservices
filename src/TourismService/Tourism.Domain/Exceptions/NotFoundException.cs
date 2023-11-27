using System.Net;

namespace Tourism.Domain.Exceptions;

public class NotFoundException : Exception
{
    public HttpStatusCode StatusCode { get; set; } = HttpStatusCode.NotFound;

    public string TitleMessage { get; set; } = string.Empty;
}
