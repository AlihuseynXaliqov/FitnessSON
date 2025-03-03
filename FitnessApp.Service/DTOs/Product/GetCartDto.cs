namespace FitnessApp.Service.DTOs.Product;

public record GetCartDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }

    public decimal Discount { get; set; }
    public decimal DiscountPrice { get; set; }
    public string ImageUrl { get; set; }
    public int Quantity { get; set; }
}