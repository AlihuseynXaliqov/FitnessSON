using FluentValidation;

namespace FitnessApp.Service.DTOs.Tag;

public record CreateTagDto
{
    public string Name { get; set; }
}
public class CreateTagDtoValidator : AbstractValidator<CreateTagDto>
{
    public CreateTagDtoValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Tag adı boş ola bilməz.")
            .MaximumLength(10).WithMessage("Tag adı maksimum 10 simvol ola bilər.");
    }
}
