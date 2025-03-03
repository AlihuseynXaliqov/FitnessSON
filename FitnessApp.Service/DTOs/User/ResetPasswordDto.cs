using FluentValidation;

namespace FitnessApp.Service.DTOs.User;

public record ResetPasswordDto
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
            .EmailAddress().WithMessage("Düzgün email daxil edin");

        RuleFor(x => x.Token)
            .NotEmpty()
            .NotNull()
            .WithMessage("Token boş ola bilməz!");
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