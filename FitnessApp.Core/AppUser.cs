using Microsoft.AspNetCore.Identity;

namespace FitnessApp.Core;

public class AppUser:IdentityUser
{
    public string FirstName { get; set; }
    public string LastName { get; set; }  
    public string? ConfirmKey { get; set; }
    public DateTime? ConfirmKeyCreatedAt { get; set; }
    public ICollection<ClientFeedBack>? ClientFeedBacks { get; set; }
    public ICollection<BlogPost>? BlogPosts { get; set; }
}