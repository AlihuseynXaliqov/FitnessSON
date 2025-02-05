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
        RuleFor(x => x.FirstName)
            .NotNull().WithMessage("Ad boş ola bilməz")
            .NotEmpty().WithMessage("Ad boş ola bilməz")
            .MaximumLength(20).WithMessage("Ad ən çox 20 simvoldan ibarət ola bilər")
            .MinimumLength(4).WithMessage("Ad ən çox 4 simvoldan ibarət ola bilər");
        
        RuleFor(x => x.LastName)
            .NotNull().WithMessage("Soyad boş ola bilməz")
            .NotEmpty().WithMessage("Soyad boş ola bilməz")
            .MaximumLength(20).WithMessage("Soyad ən çox 20 simvoldan ibarət ola bilər")
            .MinimumLength(4).WithMessage("Soyad ən çox 4 simvoldan ibarət ola bilər");     
        RuleFor(x => x.LastName)
            .NotNull().WithMessage("İstifadəçi ad boş ola bilməz")
            .NotEmpty().WithMessage("İstifadəçi ad boş ola bilməz")
            .MaximumLength(20).WithMessage("İstifadəçi ad ən çox 20 simvoldan ibarət ola bilər")
            .MinimumLength(4).WithMessage("İstifadəçi ad ən çox 4 simvoldan ibarət ola bilər");   
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
            .Matches("[A-Z]").WithMessage("Parolda en az 1 boyuk herf olmalidi")
            .Matches("[a-z]").WithMessage("Parolda en az 1 kicik herf olmalidi")
            .Matches("[0-9]").WithMessage("Parolda en az 1 reqem olmalidi")
            .Matches("^[A-Za-z0-9]").WithMessage("Parolda en az 1 simvol olmalidi")
            .MinimumLength(8).WithMessage("Password must be at least 8 characters");
        
        RuleFor(x => x)
            .Must(x => x.Password == x.ConfirmPassword).WithMessage("Passwords do not match");
    }
    }
