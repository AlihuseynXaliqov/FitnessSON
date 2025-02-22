using FitnessApp.Core.Blog;
using FitnessApp.Core.Cart;
using FitnessApp.Core.FeedBack;
using FitnessApp.Core.Plan;
using FitnessApp.Core.Wish;
using Microsoft.AspNetCore.Identity;

namespace FitnessApp.Core.User;

public class AppUser:IdentityUser
{
    public string FirstName { get; set; }
    public string LastName { get; set; }  
    public string? ConfirmKey { get; set; }
    public DateTime? ConfirmKeyCreatedAt { get; set; }
    public ICollection<ClientFeedBack>? ClientFeedBacks { get; set; }
    public ICollection<Wishlist> Wishlists { get; set; }
    public ICollection<CartItem> CartItems { get; set; }
    public ICollection<BlogPost>? BlogPosts { get; set; }
    public ICollection<UserPlan>? UserPlans { get; set; }
}