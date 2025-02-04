using FluentValidation;

namespace FitnessApp.Service.DTOs.User;

public class ForgetPasswordDto
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
            .Matches(@"^[a-zA-Z0-9._%+-]+@gmail\.com$")
            .WithMessage("Etibarlı gmail deyil!");
    }
}