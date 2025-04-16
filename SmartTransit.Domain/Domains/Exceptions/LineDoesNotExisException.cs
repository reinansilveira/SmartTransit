using System.Net;

namespace SmartTransit.Domain.Domains.Exceptions;

public class LineDoesNotExisException : SmartTransitBaseException
{
    public int StatusCode { get; set; }
    public string ErrorMessage { get; set; }

    public LineDoesNotExisException() : base("LineDoesNotExisException exception error.")
    {
        StatusCode = (int)HttpStatusCode.InternalServerError;
    }

    public LineDoesNotExisException(string message) : base(message)
    {
        ErrorMessage = message;
        StatusCode = (int)HttpStatusCode.BadRequest;
    }
    
    public LineDoesNotExisException(int statusCode, string message) : base(message)
    {
        StatusCode = statusCode;
        ErrorMessage = message;
    }
}