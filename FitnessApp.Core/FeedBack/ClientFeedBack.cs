using FitnessApp.Core.Base;
using FitnessApp.Core.User;

namespace FitnessApp.Core.FeedBack;

public class ClientFeedBack:BaseEntity
{
    public string ImageUrl { get; set; }
    public string Description { get; set; }
    public int Rating { get; set; }
    public bool ConfirmedFeedBack { get; set; }
    public string UserId { get; set; }
    public AppUser? User { get; set; }
}