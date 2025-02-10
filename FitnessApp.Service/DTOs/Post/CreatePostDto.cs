namespace FitnessApp.Service.DTOs.Post;

public class CreatePostDto
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string ImageUrl { get; set; }
    public string UserId { get; set; }
}