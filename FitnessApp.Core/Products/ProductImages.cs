using FitnessApp.Core.Base;

namespace FitnessApp.Core.Products;

public class ProductImages:BaseEntity
{
    public string ImageUrl { get; set; }
    public int? ProductId { get; set; }
    public Products.Product? Product { get; set; }
}