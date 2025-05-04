namespace SmartTransit.Application.InputFilter.ErrorMessage;

public class LineErrorMessage
{
    public const string LineNameEmpty = "The 'Name' field is cannot be empty.";
    
    public const string LineNameExceededMaximumLength = "the 'Name' field cannot exceed {0} characters";
    
    public const string StopIdEmpty = "The 'StopId' field is cannot be empty.";
    
    public const string StopIdNotNull = "The 'StopId' field is cannot be null.";
    
}