using FluentValidation;

namespace FitnessApp.Service.DTOs.Client;

public class CreateFeedBackDto
{
    public string ImageUrl { get; set; }
    public string Description { get; set; }
    public int Rating { get; set; }
    public string UserId { get; set; }
}

public class CreateFeedBackDtoValidator : AbstractValidator<CreateFeedBackDto>
{
    public CreateFeedBackDtoValidator()
    {
        RuleFor(x => x.ImageUrl)
            .NotEmpty().WithMessage("ImageUrl cannot be empty.");

        RuleFor(x => x.Description)
            .NotEmpty().WithMessage("Description cannot be empty.")
            .MinimumLength(10).WithMessage("Description must be at least 10 characters long.");

        RuleFor(x => x.Rating)
            .InclusiveBetween(1, 5).WithMessage("Rating must be between 1 and 5.");

        RuleFor(x => x.UserId)
            .NotEmpty().WithMessage("UserId cannot be empty.");
    }
}