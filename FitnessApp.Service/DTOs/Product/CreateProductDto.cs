using FluentValidation;

namespace FitnessApp.Service.DTOs.Product;

public class CreateProductDto
{
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }

    public decimal Discount { get; set; }
    public decimal DiscountPrice => Discount > 0 ? Price - (Price * Discount / 100) : Price;

    public string SKU { get; set; }
    public int Rate { get; set; }
    public int StockQuantity { get; set; }
    public bool IsOnSale { get; set; }
    public string ImageUrl { get; set; }
    public int? Size { get; set; }
    public string? Color { get; set; }
    public int CategoryId { get; set; }
    public ICollection<int> TagIds { get; set; } = new List<int>();

    public ICollection<ProductImagesDto> ProductImages { get; set; }
    
}

public class CreateProductDtoValidator : AbstractValidator<CreateProductDto>
{
    public CreateProductDtoValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Məhsul adı boş ola bilməz.")
            .MaximumLength(40).WithMessage("Məhsul adı maksimum 40 simvol ola bilər.");

        RuleFor(x => x.Description)
            .NotEmpty().WithMessage("Açıqlama boş ola bilməz.");

        RuleFor(x => x.Price)
            .GreaterThan(0).WithMessage("Qiymət 0-dan böyük olmalıdır.");

        RuleFor(x => x.Discount)
            .InclusiveBetween(0, 100).WithMessage("Endirim faizi 0 ilə 100 arasında olmalıdır.");

        RuleFor(x => x.SKU)
            .NotEmpty().WithMessage("SKU boş ola bilməz.");

        RuleFor(x => x.Rate)
            .InclusiveBetween(0, 5).WithMessage("Qiymetlendirme 0 ilə 5 arasında olmalıdır.");

        RuleFor(x => x.StockQuantity)
            .GreaterThanOrEqualTo(0).WithMessage("Stok miqdarı mənfi ola bilməz.");

        RuleFor(x => x.ImageUrl)
            .NotEmpty().WithMessage("Şəkil URL boş ola bilməz.");

    }
}
