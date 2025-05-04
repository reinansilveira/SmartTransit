namespace SmartTransit.Application.InputFilter.ErrorMessage;

public class StopErrorMessage
{
    public const string StopNameEmpty = "The 'Name' field is cannot be empty.";
    
    public const string StopNameExceededMaximumLength = "the 'Name' field cannot exceed {0} characters";
    
    public const string LatitudeEmpty = "The 'Latitude' field is cannot be empty.";
    
    public const string LatitudeNotNull = "The 'Latitude' field is cannot be null.";
    
    public const string LongitudeEmpty = "The 'Longitude' field is cannot be empty.";
    
    public const string LongitudeNotNull = "The 'Longitude' field is cannot be null.";
    
    public const string LatitudeInclusiveBetween = "Latitude must be between -90 and 90.";
    
    public const string LongitudeInclusiveBetween = "Longitude must be between -180 and 180.";
}