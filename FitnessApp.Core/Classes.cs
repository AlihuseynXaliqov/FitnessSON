using FitnessApp.Core.Base;

namespace FitnessApp.Core;

public class Classes:BaseEntity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string ImageUrl { get; set; }

    public List<Schedule> Schedules { get; set; } = new();
    public ICollection<TrainersClasses> TrainersClasses { get; set; }
}