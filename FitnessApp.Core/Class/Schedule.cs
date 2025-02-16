using FitnessApp.Core.Base;

namespace FitnessApp.Core.Class;

public class Schedule:BaseEntity
{
    
    public int ClassId { get; set; }
    public Classes Class { get; set; }
    
    public int TrainerId { get; set; }
    public Trainer.Trainer Trainer { get; set; }
    
    public DayOfWeek DayOfWeek { get; set; }
    public TimeSpan StartTime { get; set; }
    public TimeSpan EndTime { get; set; }
    
    
}