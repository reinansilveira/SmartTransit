using FluentValidation;
using SmartTransit.Application.InputFilter.ErrorMessage;
using SmartTransit.Application.Resource.Line;

namespace SmartTransit.Application.InputFilter.Validators.Line;

public class LineValidator : AbstractValidator<LineCreateResource>
{
    public LineValidator()
    {
        RuleFor(line => line.Name).NotEmpty().WithMessage(LineErrorMessage.LineNameEmpty)
            .MaximumLength(50).WithMessage(LineErrorMessage.LineNameExceededMaximumLength);

        RuleFor(line => line.Stops).NotEmpty().WithMessage(LineErrorMessage.StopIdEmpty);
        RuleForEach(x => x.Stops)
            .NotNull().WithMessage(LineErrorMessage.StopIdNotNull);
    }
}