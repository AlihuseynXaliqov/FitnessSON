using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using FitnessApp.Core;
using FitnessApp.Service.DTOs.User;
using FitnessApp.Service.Service.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace FitnessApp.Service.Service.Implementation;

public class UserService : IUserService
{
    private readonly UserManager<AppUser> _userManager;
    private readonly SignInManager<AppUser> _signInManager;
    private readonly IMapper _mapper;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly IConfiguration _config;

    public UserService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IMapper mapper,
        RoleManager<IdentityRole> roleManager,IConfiguration config )
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _mapper = mapper;
        _roleManager = roleManager;
        _config = config;
    }

    public async Task RegisterAsync(RegisterDto registerDto)
    {
        if (await _userManager.FindByEmailAsync(registerDto.Email) != null)
        {
            throw new Exception("This email is currently in use");
        }

        var register = _mapper.Map<AppUser>(registerDto);
        var result = await _userManager.CreateAsync(register, registerDto.Password);
        await _userManager.AddToRoleAsync(register, Roles.Admin.ToString());
        if (!result.Succeeded)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in result.Errors)
            {
                sb.Append(item.Description + " ");
            }

            throw new Exception(sb.ToString());
        }
    }

    public async Task CreateRoleAsync()
    {
        foreach (var role in Enum.GetValues(typeof(Roles)))
        {
            await _roleManager.CreateAsync(new IdentityRole()
            {
                Name = role.ToString()
            });
        }
    }
    public async Task<string> LoginAsync(LoginDto loginDto)
    {
        var user= await _userManager.FindByNameAsync(loginDto.UsernameOrEmail)
            ?? await _userManager.FindByEmailAsync(loginDto.UsernameOrEmail);
        if (user == null) throw new Exception("Melumatlar sehvdir");
        var result= await _userManager.CheckPasswordAsync(user, loginDto.Password);
        if (!result) throw new Exception("Melumatlar sehvdir");

        var _claims = new[]
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id),
            new Claim(ClaimTypes.Name, user.UserName)
        };
        SecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWT:SecurityKey"]));
        SigningCredentials signingCredentials= new SigningCredentials(key,SecurityAlgorithms.HmacSha256);
        JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(
            issuer: _config["JWT:Issuer"],
            audience: _config["JWT:Audience"],
            claims: _claims,
            signingCredentials:signingCredentials,
            expires: DateTime.UtcNow.AddMinutes(5)
        );

        var token =new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
        return token;


    }
}