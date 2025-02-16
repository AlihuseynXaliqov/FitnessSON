using FitnessApp.Core.Base;

namespace FitnessApp.Core.Plan;

public class PricingPlan:BaseEntity
{
    public string Name { get; set; }
    public DurationType Duration { get; set; }
    public decimal Price { get; set; }
    public string Description { get; set; }
    public bool withTrainer { get; set; } 
    public List<string> Features { get; set; }
}