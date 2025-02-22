namespace FitnessApp.Service.DTOs.Product;

public class GetProductDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }

    public decimal Discount { get; set; }
    public decimal DiscountPrice { get; set; }
    public string SKU { get; set; }
    public int Rate { get; set; }
    public int StockQuantity { get; set; }
    public bool IsOnSale { get; set; }
    public string ImageUrl { get; set; }
    public int? Size { get; set; }
    public string? Color { get; set; }
    public string CategoryName { get; set; }
    public ICollection<string> TagNames { get; set; }
    public ICollection<ProductImagesDto> ProductImages { get; set; }

}