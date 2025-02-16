using FitnessApp.Core.Base;

namespace FitnessApp.Core.Product;

public class ProductImages:BaseEntity
{
    public string ImageUrl { get; set; }
    public int? ProductId { get; set; }
    public Product? Product { get; set; }
}