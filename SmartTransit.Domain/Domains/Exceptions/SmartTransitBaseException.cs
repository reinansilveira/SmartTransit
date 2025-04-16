using System.Net;

namespace SmartTransit.Domain.Domains.Exceptions;

public class SmartTransitBaseException : Exception
{
    public int StatusCode { get; set; }
    public string ErrorMessage { get; set; }

    public SmartTransitBaseException() : base("SmartTransitBaseException exception error.")
    {
        StatusCode = (int)HttpStatusCode.InternalServerError;
    }

    public SmartTransitBaseException(string message) : base(message)
    {
        ErrorMessage = message;
        StatusCode = (int)HttpStatusCode.BadRequest;
    }
    
    public SmartTransitBaseException(int statusCode, string message) : base(message)
    {
        StatusCode = statusCode;
        ErrorMessage = message;
    }
    
    public virtual IList<string> GetErrorMessages()
    {
        return new List<string> { ErrorMessage };
    }

    public virtual HttpStatusCode GetStatusCode()
    {
        return (HttpStatusCode)StatusCode;
    }
}