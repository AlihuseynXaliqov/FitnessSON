using FluentValidation;

namespace FitnessApp.Service.DTOs.Category;

public class UpdateCategoryDto
{
    public int Id { get; set; }
    public string Name { get; set; }
}
public class UpdateCategoryDtoValidator : AbstractValidator<UpdateCategoryDto>
{
    public UpdateCategoryDtoValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Kateqoriya adı tələb olunur.") 
            .Length(3, 50).WithMessage("Kateqoriya adı 3-50 simvol arasında olmalıdır.");     }
}