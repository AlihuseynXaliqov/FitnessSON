using Microsoft.AspNetCore.Identity;

namespace FitnessApp.Core;

public class AppUser:IdentityUser
{
    public string FirstName { get; set; }
    public string LastName { get; set; }    
}