namespace FitnessApp.Service.DTOs.User;

public record LoginDto
{
    public string UsernameOrEmail { get; set; }
    public string Password { get; set; }
}