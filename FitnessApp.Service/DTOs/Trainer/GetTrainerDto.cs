namespace FitnessApp.Service.DTOs.Trainer;

public record GetTrainerDto
{
    public int Id { get; set; }
    public string FirstName { get; set; }  
    public string LastName { get; set; } 
    public string ImageUrl { get; set; }   
    public string Biography { get; set; }
    public int Experience { get; set; }
    public int Age { get; set; }
    public double Weight { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string PositionName { get; set; }
    public List<string> ClassNames { get; set; } = new List<string>();
}