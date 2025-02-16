using FitnessApp.Core.Base;
using FitnessApp.Core.User;

namespace FitnessApp.Core.Blog;

public class BlogPost:BaseEntity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string ImageUrl { get; set; }
    public string UserId { get; set; }
    public AppUser User { get; set; }
    
}