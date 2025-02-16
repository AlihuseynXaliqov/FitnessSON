using FitnessApp.Core.Base;

namespace FitnessApp.Core.Class;

public class TrainersClasses:BaseEntity
{
    public int TrainerId { get; set; }
    public Trainer.Trainer Trainer { get; set; }
    public int ClassId { get; set; }
    public Classes Class { get; set; }
}