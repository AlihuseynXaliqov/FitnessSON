using FluentValidation;

namespace FitnessApp.Service.DTOs.User;

public class ResendCodeDto
{
    public string Email { get; set; }
}
public class ResendCodeValidator : AbstractValidator<ResendCodeDto>
{
    public ResendCodeValidator()
    {
        RuleFor(x => x.Email)
            .NotNull()
            .NotEmpty()
            .WithMessage("Gmail boş ola bilməz!")
            .EmailAddress().WithMessage("Düzgün email daxil edin");

    }
}