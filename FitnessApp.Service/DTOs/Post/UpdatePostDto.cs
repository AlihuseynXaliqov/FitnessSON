using FluentValidation;

namespace FitnessApp.Service.DTOs.Post;

public record UpdatePostDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string ImageUrl { get; set; }
    
}
public class UpdatePostValidator : AbstractValidator<CreatePostDto>
{
    public UpdatePostValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Ad boş ola bilməz")
            .MinimumLength(4).WithMessage("Ad ən azı 4 simvoldan ibarət olmalıdır")
            .MaximumLength(50).WithMessage("Ad ən çox 50 simvoldan ibarət ola bilər");

        RuleFor(x => x.ImageUrl)
            .NotEmpty().WithMessage("Şəkil linki boş ola bilməz");

        RuleFor(x => x.Description)
            .NotEmpty().WithMessage("Təsvir boş ola bilməz")
            .MinimumLength(10).WithMessage("Təsvir ən azı 10 simvoldan ibarət olmalıdır")
            .MaximumLength(100).WithMessage("Təsvir ən çox 100 simvoldan ibarət ola bilər");
        
    }

}