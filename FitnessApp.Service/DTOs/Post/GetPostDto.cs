﻿namespace FitnessApp.Service.DTOs.Post;

public record GetPostDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string ImageUrl { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    
    public DateTime CreatedAt { get; set; }
}