using FitnessApp.Core.Base;

namespace FitnessApp.Core;

public class Classes:BaseEntity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string ImageUrl { get; set; }

    public DayOfWeek Day { get; set; }  
    public TimeSpan StartTime { get; set; }  
    public TimeSpan EndTime { get; set; }   
    public ICollection<TrainersClasses> TrainersClasses { get; set; }
}