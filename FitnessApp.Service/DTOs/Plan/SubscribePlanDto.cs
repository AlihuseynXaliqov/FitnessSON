namespace FitnessApp.Service.DTOs.Plan;

public class SubscribePlanDto
{
    public int PlanId { get; set; }
    public DateTime StartDate { get; set; }
    public bool IsActive { get; set; }
}