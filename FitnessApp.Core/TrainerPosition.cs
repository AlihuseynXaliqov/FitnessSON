using FitnessApp.Core.Base;

namespace FitnessApp.Core;

public class TrainerPosition:BaseEntity
{
    public string Name { get; set; }
    
    public ICollection<Trainer> Trainers { get; set; }
}