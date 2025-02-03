using System.Text.RegularExpressions;
using FluentValidation;

namespace FitnessApp.Service.DTOs.User;

public class RegisterDto
{
 
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Username { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
    public string ConfirmPassword { get; set; } 
}

public class RegisterValidator : AbstractValidator<RegisterDto>
{
    public RegisterValidator()
    {
        RuleFor(x => x.FirstName).NotNull().WithMessage("First name cannot be null")
            .NotEmpty().WithMessage("First name cannot be empty")
            .MaximumLength(20).WithMessage("First name must be between 4 and 20 characters")
            .MinimumLength(4).WithMessage("First name must be between 4 and 20 characters");
        
        RuleFor(x=>x.LastName)
            .NotEmpty().WithMessage("Last name cannot be empty")
            .NotNull().WithMessage("Last name cannot be null")
            .MaximumLength(20).WithMessage("First name must be between 4 and 20 characters")
            .MinimumLength(4).WithMessage("First name must be between 4 and 20 characters");
        RuleFor(x=>x.Username)
            .NotNull().WithMessage("Username cannot be null")
            .NotEmpty().WithMessage("Username name cannot be empty")
            .MaximumLength(20).WithMessage("Username name must be between 4 and 20 characters")
            .MinimumLength(3).WithMessage("Username name must be between 3 and 20 characters");
        RuleFor(x => x.Email)
            .NotEmpty()
            .NotNull()
            .Must(x =>
            {
                Regex regex = new Regex(@"^[a-zA-Z0-9._%+-]+@gmail\.com$");
                var match = regex.Match(x);
                return match.Success;
            }).WithMessage("Email is not correct");

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Password cannot be empty")
            .NotNull().WithMessage("Password cannot be null")
            .MinimumLength(8).WithMessage("Password must be at least 8 characters");
        
        RuleFor(x => x)
            .Must(x => x.Password == x.ConfirmPassword).WithMessage("Passwords do not match");
    }
    }
