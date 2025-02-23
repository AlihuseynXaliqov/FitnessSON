using FluentValidation;

namespace FitnessApp.Service.DTOs.Contact;

public class CreateContactDto
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Subject { get; set; }
    public string Message { get; set; }
}
public class CreateContactDtoValidator : AbstractValidator<CreateContactDto>
{
    public CreateContactDtoValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Ad mütləqdir.")
            .MinimumLength(2).WithMessage("Ad ən azı 2 simvol olmalıdır.")
            .MaximumLength(20).WithMessage("Ad ən çox 50 simvol ola bilər.");

        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email mütləqdir.")
            .EmailAddress().WithMessage("Düzgün email daxil edin.");

        RuleFor(x => x.Subject)
            .NotEmpty().WithMessage("Mövzu mütləqdir.")
            .MinimumLength(3).WithMessage("Mövzu ən azı 3 simvol olmalıdır.")
            .MaximumLength(20).WithMessage("Mövzu ən çox 20 simvol ola bilər.");

        RuleFor(x => x.Message)
            .NotEmpty().WithMessage("Mesaj mütləqdir.")
            .MinimumLength(10).WithMessage("Mesaj ən azı 10 simvol olmalıdır.")
            .MaximumLength(500).WithMessage("Mesaj ən çox 500 simvol ola bilər.");
    }
}