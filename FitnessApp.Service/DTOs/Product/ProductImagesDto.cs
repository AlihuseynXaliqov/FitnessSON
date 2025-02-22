using FluentValidation;

namespace FitnessApp.Service.DTOs.Product;

public class ProductImagesDto
{
    public string ImageUrl { get; set; }
}
public class ProductImagesValidator : AbstractValidator<ProductImagesDto>
{
    public ProductImagesValidator()
    {
        RuleFor(x => x.ImageUrl)
            .NotEmpty().WithMessage("Şəkil URL boş ola bilməz.");
    }
}