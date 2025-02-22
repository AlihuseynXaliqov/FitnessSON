using FluentValidation;

namespace FitnessApp.Service.DTOs.Category;

public class CreateCategoryDto
{
    public string Name { get; set; }
}
public class CreateCategoryDtoValidator : AbstractValidator<CreateCategoryDto>
{
    public CreateCategoryDtoValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Kateqoriya adı tələb olunur.") 
            .Length(3, 50).WithMessage("Kateqoriya adı 3-50 simvol arasında olmalıdır."); 
    }
}
