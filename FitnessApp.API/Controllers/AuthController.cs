using FitnessApp.Service.DTOs.User;
using FitnessApp.Service.Service.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FitnessApp.API.Controllers;

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
    public async Task<IActionResult> Register([FromForm] RegisterDto dto)
    {
        await _authService.RegisterAsync(dto);
        return Ok();
    }
    
    [HttpPost("[Action]")]
    public async Task<IActionResult> Login([FromForm] LoginDto dto)
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
    public async Task<IActionResult> SubmitRegister([FromForm] SubmitRegisterDto dto)
    {
        return Ok(await _authService.SubmitRegistration(dto));
    }

    

    [HttpPost("[Action]")]
    public async Task<IActionResult> ResendNewCode([FromForm] ResendCodeDto dto)
    {
        return Ok(await _authService.ResendConfirmationCode(dto));
    }
 
    [HttpPost("[Action]")]
    public async Task<IActionResult> ForgetPassword([FromForm] ForgetPasswordDto dto)
    {
        return Ok(await _authService.ForgetPasswordAsync(dto));
    }

    [HttpPost("[Action]")]
    public async Task<IActionResult> ResetPassword([FromForm] ResetPasswordDto dto)
    {
        return Ok(await _authService.ResetPassword(dto));
    }
}