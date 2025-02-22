using FluentValidation;

namespace FitnessApp.Service.DTOs.Class;

public class CreateClassDto
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string ImageUrl { get; set; }

}

public class CreateClassDtoValidator : AbstractValidator<CreateClassDto>
{
    public CreateClassDtoValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Ad boş ola bilməz")
            .MinimumLength(3).WithMessage("Ad ən azı 3 simvoldan ibarət olmalıdır")
            .MaximumLength(20).WithMessage("Ad 20 simvoldan çox ola bilməz");

        RuleFor(x => x.Description)
            .NotEmpty().WithMessage("Təsvir boş ola bilməz")
            .MinimumLength(10).WithMessage("Təsvir ən azı 10 simvoldan ibarət olmalıdır")
            .MaximumLength(500).WithMessage("Təsvir 500 simvoldan çox ola bilməz");

        RuleFor(x => x.ImageUrl)
            .NotEmpty().WithMessage("Şəkil URL-i boş ola bilməz");
    }
}