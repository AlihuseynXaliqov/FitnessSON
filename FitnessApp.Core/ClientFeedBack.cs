using FitnessApp.Core.Base;

namespace FitnessApp.Core;

public class ClientFeedBack:BaseEntity
{
    public string ImageUrl { get; set; }
    public string Description { get; set; }
    public int Rating { get; set; }
    public string UserId { get; set; }
    public AppUser? User { get; set; }
}