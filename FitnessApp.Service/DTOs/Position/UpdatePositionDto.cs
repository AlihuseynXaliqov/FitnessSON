using FluentValidation;

namespace FitnessApp.Service.DTOs.Position;

public record UpdatePositionDto
{
    public int Id { get; set; }
    public string Name { get; set; }
}
public class UpdatePositionDtoValidator : AbstractValidator<CreatePositionDto>
{
    public UpdatePositionDtoValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("Ad bos ola bilmez")
            .MinimumLength(3).WithMessage("Adin minimum uzunluqu 3 ola biler");
        
    }
}