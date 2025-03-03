using FluentValidation;

namespace FitnessApp.Service.DTOs.User;

public record SubmitRegisterDto
{
    public string Email { get; set; }
    public string ConfirmKey { get; set; }
}
public class SubmitRegistrationDtoValidator : AbstractValidator<SubmitRegisterDto>
{
    public SubmitRegistrationDtoValidator()
    {
        RuleFor(x => x.Email)
            .NotNull()
            .NotEmpty()
            .WithMessage("Gmail boş ola bilməz!")
            .EmailAddress().WithMessage("Düzgün email daxil edin");

        RuleFor(x => x.ConfirmKey)
            .NotNull()
            .NotEmpty()
            .WithMessage("Təsdiq kodunu daxil edin!");
    }
}