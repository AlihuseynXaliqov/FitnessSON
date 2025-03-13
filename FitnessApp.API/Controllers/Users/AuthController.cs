using System.Security.Claims;
using FitnessApp.Service.DTOs.User;
using FitnessApp.Service.Service.Interface;
using FitnessApp.Service.Service.Interface.Users;
using Microsoft.AspNetCore.Mvc;

namespace FitnessApp.API.Controllers.Users;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }


    [HttpPost("[Action]")]
    public async Task<IActionResult> Register(RegisterDto dto)
    {
        var message = await _authService.RegisterAsync(dto);
        return Ok(new { success = true, message });
    }

    [HttpPost("[Action]")]
    public async Task<IActionResult> Login(LoginDto dto)
    {
        return Ok(await _authService.LoginAsync(dto));
    }

    [HttpPost("[Action]")]
    public async Task<IActionResult> Logout()
    {
        await _authService.LogoutAsync();
        return Ok();
    }

    [HttpPost("[Action]")]
    public async Task<IActionResult> SubmitRegister(SubmitRegisterDto dto)
    {
        return Ok(await _authService.SubmitRegistration(dto));
    }


    [HttpPost("[Action]")]
    public async Task<IActionResult> ResendNewCode(ResendCodeDto dto)
    {
        return Ok(await _authService.ResendConfirmationCode(dto));
    }

    [HttpPost("[Action]")]
    public async Task<IActionResult> ForgetPassword(ForgetPasswordDto dto)
    {
        var message = await _authService.ForgetPasswordAsync(dto);
        return Ok(new { success = true, message });
    }

    [HttpPost("[Action]")]
    public async Task<IActionResult> ResetPassword(ResetPasswordDto dto)
    {
        return Ok(await _authService.ResetPassword(dto));
    }

    /*[HttpGet("[Action]")]
    public async Task<IActionResult> GetAllUsers()
    {
        var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (userId == null)
            return Unauthorized();

        var userInfo = await _authService.GetAllInfoAsync(userId);
        return userInfo != null ? Ok(userInfo) : NotFound();
    }*/
}