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
            .MinimumLength(3).WithMessage("Ad ən az 3 simvoldan ibarət ola bilər");
        
        RuleFor(x => x.LastName)
            .NotNull().WithMessage("Soyad boş ola bilməz")
            .NotEmpty().WithMessage("Soyad boş ola bilməz")
            .MaximumLength(20).WithMessage("Soyad ən çox 20 simvoldan ibarət ola bilər")
            .MinimumLength(3).WithMessage("Soyad ən az 3 simvoldan ibarət ola bilər");  
        
        RuleFor(x => x.Username)
            .NotNull().WithMessage("İstifadəçi adı boş ola bilməz")
            .NotEmpty().WithMessage("İstifadəçi adı boş ola bilməz")
            .MaximumLength(20).WithMessage("İstifadəçi adı ən çox 20 simvoldan ibarət ola bilər")
            .MinimumLength(4).WithMessage("İstifadəçi adı ən az 4 simvoldan ibarət ola bilər");

        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email boş ola bilməz")
            .NotNull().WithMessage("Email boş ola bilməz")
            .EmailAddress().WithMessage("Düzgün email daxil edin");

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Şifrə boş ola bilməz")
            .NotNull().WithMessage("Şifrə boş ola bilməz")
            .Matches("[A-Z]").WithMessage("Şifrədə ən azı 1 böyük hərf olmalıdır")
            .Matches("[a-z]").WithMessage("Şifrədə ən azı 1 kiçik hərf olmalıdır")
            .Matches("[0-9]").WithMessage("Şifrədə ən azı 1 rəqəm olmalıdır")
            .Matches("[^A-Za-z0-9]").WithMessage("Şifrədə ən azı 1 simvol olmalıdır")
            .MinimumLength(8).WithMessage("Şifrə ən azı 8 simvoldan ibarət olmalıdır");

        RuleFor(x => x)
            .Must(x => x.Password == x.ConfirmPassword).WithMessage("Şifrələr uyğun gəlmir");
    }
}
