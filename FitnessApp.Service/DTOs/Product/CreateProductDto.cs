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
    public ICollection<int> TagIds { get; set; }
    public ICollection<ProductImagesDto> ProductImages { get; set; }
    
}