using System.Net;

namespace SmartTransit.Domain.Domains.Exceptions;

public class StopDoesNotExistException : SmartTransitBaseException
{
    public int StatusCode { get; set; }
    public string ErrorMessage { get; set; }

    public StopDoesNotExistException() : base("SmartTransitBaseException exception error.")
    {
        StatusCode = (int)HttpStatusCode.InternalServerError;
    }

    public StopDoesNotExistException(string message) : base(message)
    {
        ErrorMessage = message;
        StatusCode = (int)HttpStatusCode.BadRequest;
    }
    
    public StopDoesNotExistException(int statusCode, string message) : base(message)
    {
        StatusCode = statusCode;
        ErrorMessage = message;
    }

}