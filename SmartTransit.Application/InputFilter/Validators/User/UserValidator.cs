using FluentValidation;
using SmartTransit.Application.InputFilter.ErrorMessage;
using SmartTransit.Application.Resource;
using SmartTransit.Application.Resource.Line;
using SmartTransit.Application.Resource.User;

namespace SmartTransit.Application.InputFilter.Validators.User;

public class UserValidator : AbstractValidator<UserResource>
{
    public UserValidator()
    {
        RuleFor(user => user.Name).NotEmpty().WithMessage(UserErrorMessage.NameEmpty)
            .MaximumLength(50).WithMessage(UserErrorMessage.NameExceededMaximumLength);

        RuleFor(user => user.Email).NotEmpty().WithMessage(UserErrorMessage.EmailEmpty)
            .EmailAddress().WithMessage(UserErrorMessage.InvalidEmail);

        RuleFor(user => user.PasswordHash).NotEmpty().WithMessage(UserErrorMessage.PasswordEmpty)
            .MinimumLength(8).WithMessage(UserErrorMessage.PasswordMinimunLength)
            .Matches(@"[A-Z]").WithMessage(UserErrorMessage.PasswordMustContainUppercase)
            .Matches(@"[a-z]").WithMessage(UserErrorMessage.PasswordMustContainLowercase)
            .Matches(@"\d").WithMessage(UserErrorMessage.PasswordMustContainDigit)
            .Matches(@"[!@#\$%\^&\*\(\)_\+\-=\[\]{};':""\\|,.<>\/?]").WithMessage(UserErrorMessage.PasswordMustContainSpecialCharacter)
            .Matches(@"^\S*$").WithMessage(UserErrorMessage.PasswordCannotContainWhitespace);
            
    }
}