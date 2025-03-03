using FluentValidation;

namespace FitnessApp.Service.DTOs.User;

public record ForgetPasswordDto
{
    public string Email { get; set; }
}

public class ForgetPasswordValidator : AbstractValidator<ForgetPasswordDto>
{
    public ForgetPasswordValidator()
    {
        RuleFor(x => x.Email)
            .NotNull()
            .NotEmpty()
            .WithMessage("Gmail boş ola bilməz!")
            .EmailAddress().WithMessage("Düzgün email daxil edin");
    }
}