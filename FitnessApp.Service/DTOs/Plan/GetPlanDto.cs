using FitnessApp.Core;

namespace FitnessApp.Service.DTOs.Plan;

public record GetPlanDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Duration { get; set; }
    public string DurationText { get; set; }
    public decimal Price { get; set; }
    public string Description { get; set; }
    public bool withTrainer { get; set; } 
    public List<string> Features { get; set; }
}