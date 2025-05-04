using FluentValidation;
using SmartTransit.Application.InputFilter.ErrorMessage;
using SmartTransit.Application.Resource.VehiclePosition;

namespace SmartTransit.Application.InputFilter.Validators.VehiclePosition;

public class VehiclePositionValidator : AbstractValidator<VehiclePositionResource>
{
    public VehiclePositionValidator()
    {
        RuleFor(vehicle => vehicle.VehicleId).NotEmpty().WithMessage(VehiclePositionErrorMessage.VehicleIdEmpty);
        
        RuleFor(vehicle => vehicle.Longitude).NotEmpty().WithMessage(VehiclePositionErrorMessage.LongitudeEmpty)
            .NotNull().WithMessage(VehiclePositionErrorMessage.LongitudeNotNull)
                .InclusiveBetween(-90, 90)
                .WithMessage(VehiclePositionErrorMessage.LongitudeInclusiveBetween);

        RuleFor(vehicle => vehicle.VehiclePosition).NotEmpty().WithMessage(VehiclePositionErrorMessage.VehiclePositionEmpty)
            .NotNull().WithMessage(VehiclePositionErrorMessage.VehiclePositionNotNull);
    }
}