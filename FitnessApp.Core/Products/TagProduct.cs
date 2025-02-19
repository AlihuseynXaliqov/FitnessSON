using FitnessApp.Core.Base;

namespace FitnessApp.Core.Products;

public class TagProduct:BaseEntity
{
    public int TagId { get; set; }
    public Tag Tag { get; set; }
    
    public int ProductId { get; set; }
    public Products.Product Product { get; set; }
}