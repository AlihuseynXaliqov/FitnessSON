using FluentValidation;

namespace FitnessApp.Service.DTOs.Tag;

public class UpdateTagDto
{
    public int Id { get; set; }
    public string Name { get; set; }
}
public class UpdateTagDtoValidator : AbstractValidator<UpdateTagDto>
{
    public UpdateTagDtoValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Tag adı boş ola bilməz.")
            .MaximumLength(10).WithMessage("Tag adı maksimum 10 simvol ola bilər.");
    }
}
