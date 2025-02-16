using FitnessApp.Core;

namespace FitnessApp.Service.DTOs.Plan;

public class GetPlanDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Duration { get; set; }
    public decimal Price { get; set; }
    public string Description { get; set; }
    public bool withTrainer { get; set; } 
    public List<string> Features { get; set; }
}