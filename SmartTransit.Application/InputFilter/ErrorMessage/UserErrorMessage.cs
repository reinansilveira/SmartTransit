namespace SmartTransit.Application.InputFilter.ErrorMessage;

public class UserErrorMessage
{
    public const string NameEmpty = "The 'Name' field is cannot be empty.";
    
    public const string NameExceededMaximumLength = "the 'Name' field cannot exceed {0} characters";
    
    public const string EmailEmpty = "The 'Email' field is cannot be empty.";
    
    public const string InvalidEmail = "Invalid email address";
    
    public const string PasswordEmpty = "The 'Password' field is cannot be empty.";
    
    public const string PasswordMinimunLength = "The 'Password' field must be at least {0} characters.";
    
    public const string PasswordMustContainUppercase = "The 'Password' field must contain at least one uppercase letter.";
    
    public const string PasswordMustContainLowercase = "The 'Password' field must contain at least one lowercase letter.";
    
    public const string PasswordMustContainDigit = "The 'Password' field must contain at least one number.";
    
    public const string PasswordMustContainSpecialCharacter = "The 'Password' field must contain at least one special character.";
    
    public const string PasswordCannotContainWhitespace = "The 'Password' field cannot contain whitespace.";
}