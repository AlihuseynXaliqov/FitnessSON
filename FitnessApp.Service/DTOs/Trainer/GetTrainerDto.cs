namespace FitnessApp.Service.DTOs.Trainer;

public class GetTrainerDto
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string ImageUrl { get; set; }
    public string Specialization { get; set; } // Mütəxəssisi olduğu sahə (Fitness, CrossFit və s.)
    public string Biography { get; set; }
    public string Experience { get; set; }
    public int Age { get; set; }
    public double Weight { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string FacebookUrl { get; set; }
    public string InstagramUrl { get; set; }
    public string TwitterUrl { get; set; }


    public List<int> ClassIds { get; set; } = new List<int>();
}