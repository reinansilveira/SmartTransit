using System.Net;

namespace SmartTransit.Domain.Domains.Exceptions;

public class VehicleDoesNotExistException : SmartTransitBaseException
{
    public int StatusCode { get; set; }
    public string ErrorMessage { get; set; }

    public VehicleDoesNotExistException() : base("VehicleDoesNotExistException exception error.")
    {
        StatusCode = (int)HttpStatusCode.InternalServerError;
    }

    public VehicleDoesNotExistException(string message) : base(message)
    {
        ErrorMessage = message;
        StatusCode = (int)HttpStatusCode.BadRequest;
    }
    
    public VehicleDoesNotExistException(int statusCode, string message) : base(message)
    {
        StatusCode = statusCode;
        ErrorMessage = message;
    }
}