namespace FitnessApp.Service.DTOs.Client;

public class GetFeedBackDto
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string ImageUrl { get; set; }
    public string Description { get; set; }
    public int Rating { get; set; }
}