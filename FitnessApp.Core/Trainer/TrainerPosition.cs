using FitnessApp.Core.Base;

namespace FitnessApp.Core.Trainer;

public class TrainerPosition:BaseEntity
{
    public string Name { get; set; }
    
    public ICollection<Core.Trainer.Trainer> Trainers { get; set; }
}