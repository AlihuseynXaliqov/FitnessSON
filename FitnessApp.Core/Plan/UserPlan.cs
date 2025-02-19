using FitnessApp.Core.Base;
using FitnessApp.Core.User;

namespace FitnessApp.Core.Plan;

public class UserPlan:BaseEntity
{
    public int PlanId { get; set; }
    public PricingPlan Plan { get; set; }
    
    public string UserId { get; set; }
    public AppUser User { get; set; }
    
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public bool IsActive { get; set; }
}