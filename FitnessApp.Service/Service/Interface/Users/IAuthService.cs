using FitnessApp.Core.User;
using FitnessApp.Service.DTOs.User;

namespace FitnessApp.Service.Service.Interface.Users;

public interface IAuthService
{
    Task<string> RegisterAsync(RegisterDto registerDto);
    Task<object> LoginAsync(LoginDto loginDto);
    Task LogoutAsync();
    Task<string> SubmitRegistration(SubmitRegisterDto dto);
    Task<string> ResendConfirmationCode(ResendCodeDto dto);
    Task<string> ResetPassword(ResetPasswordDto dto);
    Task<string> ForgetPasswordAsync(ForgetPasswordDto dto);
    Task DeleteUnconfirmedUsers();
    /*
    Task<UserDto> GetAllInfoAsync(string userId);
*/
}