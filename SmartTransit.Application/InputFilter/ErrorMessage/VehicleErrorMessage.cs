namespace SmartTransit.Application.InputFilter.ErrorMessage;

public class VehicleErrorMessage
{
    public const string VehicleNameEmpty = "The 'VehicleName' field is cannot be empty.";
    
    public const string VehicleNameExceededMaximumLength = "the 'VehicleName' field cannot exceed {0} characters";
    
    public const string ModeloNameEmpty = "The 'ModeloName' field is cannot be empty.";
    
    public const string ModeloNameExceededMaximumLength = "the 'ModeloName' field cannot exceed {0} characters";
    
    public const string LineIdEmpty = "The 'LineId' field is cannot be empty.";
    
}