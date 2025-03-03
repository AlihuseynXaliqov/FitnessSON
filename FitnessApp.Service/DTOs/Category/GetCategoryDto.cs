namespace FitnessApp.Service.DTOs.Category;

public record GetCategoryDto
{
    public int Id { get; set; }
    public string Name { get; set; }
}