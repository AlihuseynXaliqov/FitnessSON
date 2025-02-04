using FitnessApp.Service.DTOs.User;

namespace FitnessApp.Service.Service.Interface;

public interface IAuthService
{
    Task RegisterAsync(RegisterDto registerDto);
    Task CreateRoleAsync();
    Task<string> LoginAsync(LoginDto loginDto);
    Task LogoutAsync();
    Task<string> SubmitRegistration(SubmitRegisterDto dto);
    Task<string> ResetPassword(ResetPasswordDto dto);
    Task<string> ForgetPasswordAsync(ForgetPasswordDto dto);
}