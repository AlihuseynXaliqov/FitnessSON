using FluentValidation;

namespace FitnessApp.Service.DTOs.User;

public class ResetPasswordDto
{
    public string Email { get; set; }
    public string Token { get; set; }
    public string Password { get; set; }
    public string ConfirmPassword { get; set; }
}
public class ResetPasswordDtoValidator : AbstractValidator<ResetPasswordDto>
{
    public ResetPasswordDtoValidator()
    {
        RuleFor(x => x.Email)
            .NotNull()
            .NotEmpty()
            .WithMessage("Gmail boş ola bilməz!")
            .Matches(@"^[a-zA-Z0-9._%+-]+@gmail\.com$")
            .WithMessage("Etibarlı gmail deyil!");
        RuleFor(x => x.Token)
            .NotEmpty()
            .NotNull()
            .WithMessage("Token boş ola bilməz!");
        RuleFor(x => x.Password)
            .NotNull()
            .NotEmpty()
            .WithMessage("Şifrə boş ola bilməz!")
            .MinimumLength(8)
            .WithMessage("Şifrə ən azı 8 simvol uzunluğunda olmalıdır!");
        RuleFor(x => x.ConfirmPassword)
            .Equal(x => x.Password)
            .WithMessage("Şifrələr uyğunlaşmır!");
    }

}