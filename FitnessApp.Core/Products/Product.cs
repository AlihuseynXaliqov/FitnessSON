using FitnessApp.Core.Base;
using FitnessApp.Core.Cart;
using FitnessApp.Core.Wish;

namespace FitnessApp.Core.Products;

public class Product : BaseEntity
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
    public Category Category { get; set; }
    public ICollection<Wishlist> wishlists { get; set; }
    public ICollection<CartItem> CartItems { get; set; }
    public ICollection<ProductImages> ProductImages { get; set; }
    public ICollection<TagProduct> TagProducts { get; set; }
}