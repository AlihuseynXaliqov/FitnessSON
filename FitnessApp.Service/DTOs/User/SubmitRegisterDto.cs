using FluentValidation;

namespace FitnessApp.Service.DTOs.User;

public class SubmitRegisterDto
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
            .Matches(@"^[a-zA-Z0-9._%+-]+@gmail\.com$")
            .WithMessage("Etibarlı gmail deyil!");
        RuleFor(x => x.ConfirmKey)
            .NotNull()
            .NotEmpty()
            .WithMessage("Təsdiq kodunu daxil edin!");
    }
}