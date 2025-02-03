using FitnessApp.Service.DTOs.User;
using FitnessApp.Service.Service.Implementation;
using FitnessApp.Service.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace FitnessApp.API.Controller;

[Route("api/[controller]")]
[ApiController]
public class AuthController : Microsoft.AspNetCore.Mvc.Controller
{
    private readonly IUserService _userService;

    public AuthController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost("[Action]")]
    public async Task<IActionResult> Register(RegisterDto dto)
    {
        try
        {
            await _userService.RegisterAsync(dto);
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
            await _userService.CreateRoleAsync();
            return Ok();    
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);    

        }
    }

    [HttpPost("[Action]")]
    public async Task<IActionResult> Login(LoginDto dto)
    {
        try
        {
            
            return Ok(await _userService.LoginAsync(dto));    
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);    

        }
    }
}