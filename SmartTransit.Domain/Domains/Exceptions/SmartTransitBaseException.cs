namespace SmartTransit.Domain.Domains.Exceptions;

public class SmartTransitBaseException : Exception
{
    public int StatusCode { get; set; }

    public SmartTransitBaseException() : base("AikoBaseException exception error.")
    {
    }

    public SmartTransitBaseException(string message) : base(message)
    {
    }
    
    public SmartTransitBaseException(int statusCode, string message) : base(message)
    {
        StatusCode = statusCode;
    }
}