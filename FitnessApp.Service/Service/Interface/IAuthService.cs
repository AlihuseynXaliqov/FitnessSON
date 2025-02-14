using FitnessApp.Service.DTOs.User;

namespace FitnessApp.Service.Service.Interface;

public interface IAuthService
{
    Task RegisterAsync(RegisterDto registerDto);
    Task<string> LoginAsync(LoginDto loginDto);
    Task LogoutAsync();
    Task<string> SubmitRegistration(SubmitRegisterDto dto);
    Task<string> ResendConfirmationCode(ResendCodeDto dto);
    Task<string> ResetPassword(ResetPasswordDto dto);
    Task<string> ForgetPasswordAsync(ForgetPasswordDto dto);
    Task DeleteUnconfirmedUsers();
}