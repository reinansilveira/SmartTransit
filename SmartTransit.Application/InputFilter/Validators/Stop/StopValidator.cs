using FluentValidation;
using SmartTransit.Application.InputFilter.ErrorMessage;
using SmartTransit.Application.Resource.Stop;

namespace SmartTransit.Application.InputFilter.Validators.Stop;

public class StopValidator :  AbstractValidator<StopCreateResource>
{
    public StopValidator()
    {
        RuleFor(stop => stop.Name).NotEmpty().WithMessage(StopErrorMessage.StopNameEmpty)
            .MaximumLength(50).WithMessage(StopErrorMessage.StopNameExceededMaximumLength);
        
        RuleFor(stop => stop.Latitude)
            .NotEmpty().WithMessage(StopErrorMessage.LatitudeEmpty)
            .NotNull().WithMessage(StopErrorMessage.LatitudeNotNull)
            .InclusiveBetween(-90, 90)
            .WithMessage(StopErrorMessage.LatitudeInclusiveBetween);
        
        RuleFor(stop => stop.Longitude)
            .NotEmpty().WithMessage(StopErrorMessage.LongitudeEmpty)
            .NotNull().WithMessage(StopErrorMessage.LongitudeNotNull)
            .InclusiveBetween(-180, 180)
            .WithMessage(StopErrorMessage.LongitudeInclusiveBetween);
    }
}