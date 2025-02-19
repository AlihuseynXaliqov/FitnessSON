using FitnessApp.Core.Base;

namespace FitnessApp.Core.Products;

public class Tag:BaseEntity
{
    public string Name { get; set; }
    public ICollection<TagProduct>? TagProducts { get; set; }
}