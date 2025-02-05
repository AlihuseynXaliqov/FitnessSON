using FitnessApp.Core.Base;

namespace FitnessApp.Core;

public class Trainer:BaseEntity
{

    public string FirstName { get; set; }  
    public string LastName { get; set; } 
    public string ImageUrl { get; set; }   
    public string Specialization { get; set; }  // Mütəxəssisi olduğu sahə (Fitness, CrossFit və s.)
    public string Experience { get; set; }
    public string Biography { get; set; }
    public int Age { get; set; }
    public double Weight { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string FacebookUrl { get; set; }
    public string InstagramUrl { get; set; }
    public string TwitterUrl { get; set; }
    
    public ICollection<TrainersClasses> TrainersClasses { get; set; }

    
}
