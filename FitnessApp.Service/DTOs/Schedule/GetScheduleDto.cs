namespace FitnessApp.Service.DTOs.Schedule;

public class GetScheduleDto
{
    public int Id { get; set; } 
    public int ClassId { get; set; }
    public int TrainerId { get; set; }
    public DayOfWeek DayOfWeek { get; set; }
    public TimeSpan StartTime { get; set; }

    public TimeSpan EndTime { get; set; }
}