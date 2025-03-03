using FluentValidation;

namespace FitnessApp.Service.DTOs.Client;

public record UpdateFeedBackDto
{
    public int Id { get; set; }
    public string ImageUrl { get; set; }
    public string Description { get; set; }
    public int Rating { get; set; }
}

public class UpdateFeedBackDtoValidator : AbstractValidator<UpdateFeedBackDto>
{
    public UpdateFeedBackDtoValidator()
    {
        RuleFor(x => x.ImageUrl)
            .NotEmpty().WithMessage("Şəkil URL-i boş ola bilməz.");

        RuleFor(x => x.Description)
            .NotEmpty().WithMessage("Təsvir boş ola bilməz.")
            .MinimumLength(10).WithMessage("Təsvir ən azı 10 simvoldan ibarət olmalıdır.");

        RuleFor(x => x.Rating)
            .InclusiveBetween(1, 5).WithMessage("Reytinq 1 ilə 5 arasında olmalıdır.");
    }
}