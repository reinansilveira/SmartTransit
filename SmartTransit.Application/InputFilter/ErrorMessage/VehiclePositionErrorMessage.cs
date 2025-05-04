namespace SmartTransit.Application.InputFilter.ErrorMessage;

public class VehiclePositionErrorMessage
{
    public const string VehicleIdEmpty = "The 'VehicleId' field cannot be empty.";

    public const string LongitudeEmpty = "The 'Longitude' field cannot be empty.";
    public const string LongitudeNotNull = "The 'Longitude' field cannot be null.";
    public const string LongitudeInclusiveBetween = "The 'Longitude' field must be between -180 and 180.";

    public const string VehiclePositionEmpty = "The 'VehiclePosition' field cannot be empty.";
    public const string VehiclePositionNotNull = "The 'VehiclePosition' field cannot be null.";
}