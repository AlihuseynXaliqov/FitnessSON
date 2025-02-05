namespace FitnessApp.Service.DTOs.Class;

public class CreateClassDto
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string ImageUrl { get; set; }

    public DayOfWeek Day { get; set; }  
    public TimeSpan StartTime { get; set; }  
    public TimeSpan EndTime { get; set; }   
}