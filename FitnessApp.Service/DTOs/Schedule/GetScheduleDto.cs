namespace FitnessApp.Service.DTOs.Schedule;

public record GetScheduleDto
{
    public int Id { get; set; }
    public string ClassName { get; set; }
    public string TrainerFirstName { get; set; }
    public string TrainerLastName { get; set; }

    public DayOfWeek DayOfWeek { get; set; }
    public TimeSpan StartTime { get; set; }

    public TimeSpan EndTime { get; set; }
}