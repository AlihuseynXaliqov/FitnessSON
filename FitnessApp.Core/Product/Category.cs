using FitnessApp.Core.Base;

namespace FitnessApp.Core.Product;

public class Category:BaseEntity
{
    public string Name { get; set; }
    public ICollection<Product> Products { get; set; }
}