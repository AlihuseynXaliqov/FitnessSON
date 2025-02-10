using FitnessApp.Core.Base;

namespace FitnessApp.Core;

public class BlogPost:BaseEntity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string ImageUrl { get; set; }
    public string UserId { get; set; }
    public AppUser User { get; set; }
    
}