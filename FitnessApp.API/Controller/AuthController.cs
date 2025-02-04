using FitnessApp.Service.DTOs.User;
using FitnessApp.Service.Service.Implementation;
using FitnessApp.Service.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace FitnessApp.API.Controller;

[Route("api/[controller]")]
[ApiController]
public class AuthController : Microsoft.AspNetCore.Mvc.Controller
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("[Action]")]
    public async Task<IActionResult> Register([FromForm]RegisterDto dto)
    {
        try
        {
            await _authService.RegisterAsync(dto);
            return Ok();
        }
        catch (Exception e)
        {
           return BadRequest(e.Message);    
        }
       
    }

    [HttpPost("[Action]")]
    public async Task<IActionResult> CreateRole()
    {
        try
        {
            await _authService.CreateRoleAsync();
            return Ok();    
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);    

        }
    }

    [HttpPost("[Action]")]
    public async Task<IActionResult> Login([FromForm]LoginDto dto)
    {
        try
        {
            
            return Ok(await _authService.LoginAsync(dto));    
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);    

        }
    }

    [HttpPost("[Action]")]
    public async Task<IActionResult> Logout()
    {
        try
        {
            await _authService.LogoutAsync();
            return Ok();    
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);    
        }
    }

    [HttpPost("[Action]")]
    public async Task<IActionResult> SumbitRegister([FromForm]SubmitRegisterDto dto)
    {
        try
        {
            return Ok( await _authService.SubmitRegistration(dto));
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);    

        }
    }

    [HttpPost("[Action]")]
    public async Task<IActionResult> ForgetPassword([FromForm] ForgetPasswordDto dto)
    {
        try
        {
            return Ok(await _authService.ForgetPasswordAsync(dto));
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);

        }
    }

    [HttpPost("[Action]")]
    public async Task<IActionResult> ResetPassword([FromForm] ResetPasswordDto dto)
    {
        try
        {
            return Ok(await _authService.ResetPassword(dto));
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);

        }
    }
    
}