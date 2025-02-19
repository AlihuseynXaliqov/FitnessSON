using FitnessApp.Core.Base;

namespace FitnessApp.Core.Products;

public class Category:BaseEntity
{
    public string Name { get; set; }
    public ICollection<Products.Product> Products { get; set; }
}