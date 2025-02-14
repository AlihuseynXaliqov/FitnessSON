namespace FitnessApp.Service.DTOs.Class;

public class GetClassDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string ImageUrl { get; set; }
    
    public ICollection<ClassScheduleDto> Schedules { get; set; }
}