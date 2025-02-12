using FluentValidation;

namespace FitnessApp.Service.DTOs.Position;

public class CreatePositionDto
{
    public string Name { get; set; }
}

public class CreatePositionDtoValidator : AbstractValidator<CreatePositionDto>
{
    public CreatePositionDtoValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("Ad bos ola bilmez")
            .MinimumLength(3).WithMessage("Adin minimum uzunluqu 3 ola biler");
        
    }
}