namespace FitnessApp.Service.DTOs.Class;

public class ClassScheduleDto
{
    public string TrainerName { get; set; }
    public DayOfWeek DayOfWeek { get; set; }
    public string StartTime { get; set; }
    public string EndTime { get; set; }
}