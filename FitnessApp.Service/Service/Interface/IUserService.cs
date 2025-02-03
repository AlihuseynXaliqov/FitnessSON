using FitnessApp.Service.DTOs.User;

namespace FitnessApp.Service.Service.Interface;

public interface IUserService
{
    Task RegisterAsync(RegisterDto registerDto);
    Task CreateRoleAsync();
    Task<string> LoginAsync(LoginDto loginDto);
}