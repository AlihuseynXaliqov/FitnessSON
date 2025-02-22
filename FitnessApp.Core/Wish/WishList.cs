using FitnessApp.Core.Base;
using FitnessApp.Core.Products;
using FitnessApp.Core.User;

namespace FitnessApp.Core.Wish;

public class Wishlist : BaseEntity
{
    public string UserId { get; set; }
    public AppUser User { get; set; }
    public int ProductId { get; set; }
    public Product Product { get; set; }
}