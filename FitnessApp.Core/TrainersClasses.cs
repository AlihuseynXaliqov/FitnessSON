using FitnessApp.Core.Base;

namespace FitnessApp.Core;

public class TrainersClasses:BaseEntity
{
    public int TrainerId { get; set; }
    public Trainer Trainer { get; set; }
    public int ClassId { get; set; }
    public Classes Class { get; set; }
}