using FitnessApp.Service.DTOs.Client;
using FitnessApp.Service.DTOs.Plan;

namespace FitnessApp.Service.DTOs.User;

public class UserDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }

    public List<GetFeedBackDto> ClientFeedBacks { get; set; } = new List<GetFeedBackDto>();
    public List<GetPlanDto> UserPlans { get; set; } = new List<GetPlanDto>();
}