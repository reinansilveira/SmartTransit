using FluentValidation;
using SmartTransit.Application.InputFilter.ErrorMessage;
using SmartTransit.Application.Resource.Vehicle;

namespace SmartTransit.Application.InputFilter.Validators.Vehicle;

public class VehicleValidator : AbstractValidator<VehicleResource>
{
    public VehicleValidator()
    {
        RuleFor(vehicle => vehicle.Name).NotEmpty().WithMessage(VehicleErrorMessage.VehicleNameEmpty)
            .MaximumLength(50).WithMessage(VehicleErrorMessage.VehicleNameExceededMaximumLength);
        
        RuleFor(vehicle => vehicle.Modelo).NotEmpty().WithMessage(VehicleErrorMessage.ModeloNameEmpty)
            .MaximumLength(50).WithMessage(VehicleErrorMessage.ModeloNameExceededMaximumLength);

        RuleFor(x => x.LineId)
            .NotEmpty().WithMessage(VehicleErrorMessage.LineIdEmpty);
    }
}