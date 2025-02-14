using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using FitnessApp.Core;
using FitnessApp.DAL;
using FitnessApp.Service.DTOs.User;
using FitnessApp.Service.Helper.Email;
using FitnessApp.Service.Helper.Exception.Auth;
using FitnessApp.Service.Service.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace FitnessApp.Service.Service.Implementation;

public class AuthService : IAuthService
{
    private readonly UserManager<AppUser> _userManager;
    private readonly SignInManager<AppUser> _signInManager;
    private readonly IMapper _mapper;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly IConfiguration _config;
    private readonly AppDbContext _context;
    private readonly IMailService _mailService;

    public AuthService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IMapper mapper,
        RoleManager<IdentityRole> roleManager, IConfiguration config, AppDbContext context, IMailService mailService)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _mapper = mapper;
        _roleManager = roleManager;
        _config = config;
        _context = context;
        _mailService = mailService;
    }

    public async Task RegisterAsync(RegisterDto registerDto)
    {
        if (await _userManager.FindByEmailAsync(registerDto.Email) != null)
        {
            throw new RegisterException("Bu email istifade edilir", 404);
        }

        var appUser = _mapper.Map<AppUser>(registerDto);
        var result = await _userManager.CreateAsync(appUser, registerDto.Password);
        
        if (!result.Succeeded)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in result.Errors)
            {
                sb.Append(item.Description + " ");
            }

            throw new Exception(sb.ToString());
        }

        var token = _userManager.GenerateEmailConfirmationTokenAsync(appUser);
        var confirmKey = new Random().Next(100000, 999999).ToString();
        appUser.ConfirmKey = confirmKey;
        appUser.ConfirmKeyCreatedAt = DateTime.UtcNow;
        await _context.SaveChangesAsync();
        var link = $"http://localhost:5179/submit-registration?email={registerDto.Email}&token={token}";

        MailRequest mailRequest = new MailRequest()
        {
            ToEmail = registerDto.Email,
            Subject = "Hesabınızı təsdiqləyin",
            Body = $"<h1>Təsdiq kodunuz: <br>{confirmKey}</h1><a href='{link}'>Təsdiqləyin<a/>"
        };
        await _userManager.AddToRoleAsync(appUser, nameof(Roles.Member));
        await _mailService.SendEmailAsync(mailRequest);
    }

    public async Task<string> SubmitRegistration(SubmitRegisterDto dto)
    {
        var user = await _userManager.FindByEmailAsync(dto.Email);
        if (user == null)
        {
            throw new NotFoundException();
        }

        
        if (user.EmailConfirmed)
        {
            throw new RegisterException("Hesabiniz artiq tesdiqlenib", 409);
        }

        if (string.IsNullOrEmpty(user.ConfirmKey))
        {
            throw new RegisterException("Tesdiq kodunuz movcud deyil ve ya artiq istifade edilib", 400);
        }
        

        if (user.ConfirmKey != dto.ConfirmKey)
        {
            throw new RegisterException("Tesdiq kodunuz duzgun deyil", 400);
        }

        if ((DateTime.UtcNow - user.ConfirmKeyCreatedAt.Value).TotalMinutes < 5)
        {
        user.EmailConfirmed = true;
        user.ConfirmKey = null;
            
        }
        else
        {
            throw new RegisterException("Təsdiq kodunun vaxtı bitib,yeniden kod gonderin ", 400);
        }
        await _context.SaveChangesAsync();
        return "Email uğurla təsdiqləndi!";
    }

    public async Task<string> ResendConfirmationCode(ResendCodeDto dto)
    {
        var user = await _userManager.FindByEmailAsync(dto.Email);
        if(user == null) throw new NotFoundException();
        if (user.EmailConfirmed)
        {
            throw new RegisterException("Hesabiniz artiq tesdiqlenib", 409);
        }
        
        var newConfirmKey = new Random().Next(100000, 999999).ToString();
        user.ConfirmKey = newConfirmKey;
        user.ConfirmKeyCreatedAt = DateTime.Now;
        await _context.SaveChangesAsync();
        
        MailRequest mailRequest = new MailRequest()
        {
            ToEmail = dto.Email,
            Subject = "Hesabınızı təsdiqləyin",
            Body = $"<h1>Təsdiq kodunuz: <br>{newConfirmKey}</h1><a href=''>Təsdiqləyin<a/>"
        };
        
        await _mailService.SendEmailAsync(mailRequest);
        return "Yeni təsdiq kodu emailinizə göndərildi. ";
    }
    

    public async Task<string> LoginAsync(LoginDto loginDto)
    {
        var user = await _userManager.FindByNameAsync(loginDto.UsernameOrEmail)
                   ?? await _userManager.FindByEmailAsync(loginDto.UsernameOrEmail);
        if (user == null) throw new NotFoundException();
        if (!user.EmailConfirmed)
        {
            await _userManager.DeleteAsync(user);
            throw new LoginException("Email düzgün deyil, yenidən qeydiyyatdan keçin", 400);
        }

        var result = await _userManager.CheckPasswordAsync(user, loginDto.Password);
        if (!result) throw new LoginException("Məlumatlar səhvdir", 400);

// 🛠 İstifadəçinin rollarını əldə edin
        var roles = await _userManager.GetRolesAsync(user);

// 🛠 Claim-lərə rolları əlavə edin
        var _claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id),
            new Claim(ClaimTypes.Name, user.UserName)
        };

// 🛠 Rolları tokenə əlavə edin
        foreach (var role in roles)
        {
            _claims.Add(new Claim(ClaimTypes.Role, role)); // ← Burada rol əlavə edirik
        }

// 🛠 JWT yaratmaq üçün Security Key və Signing Credentials
        SecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWT:SecurityKey"]));
        SigningCredentials signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

// 🛠 Token yaradılması
        JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(
            issuer: _config["JWT:Issuer"],
            audience: _config["JWT:Audience"],
            claims: _claims, // 🔥 Claim-lərə rollar da daxil oldu!
            signingCredentials: signingCredentials,
            expires: DateTime.UtcNow.AddDays(1)
        );

// 🛠 Tokeni string olaraq qaytarın
        return new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
    }

    public async Task<string> ForgetPasswordAsync(ForgetPasswordDto dto)
    {
        var user = await _userManager.FindByEmailAsync(dto.Email);
        if (user == null)
        {
            throw new NotFoundException();
        }

        var token = await _userManager.GeneratePasswordResetTokenAsync(user);
        var link = $"http://localhost:5179/reset-password?email={dto.Email}&token={token}";
        MailRequest mailRequest = new MailRequest()
        {
            ToEmail = dto.Email,
            Subject = "Şifrənin yenilənməsi",
            Body = $"Şifrənizi yeniləmək üçün bu linkə klikləyin: <a href='{link}'>Şifrəni yenilə</a>",
        };
        await _mailService.SendEmailAsync(mailRequest);
        return $"Bu emailli hesab movcuddursa, yenileme linki gonderilecek!";
    }

    public async Task<string> ResetPassword(ResetPasswordDto dto)
    {
        var user = await _userManager.FindByEmailAsync(dto.Email);
        if (user == null)
        {
            throw new NotFoundException();
        }

        var result = await _userManager.ResetPasswordAsync(user, dto.Token, dto.Password);
        if (!result.Succeeded)
        {
            throw new ResetPasswordException("Şifrəniz yenilənmədi. Yenidən cəhd edin!", 404);
        }

        return "Şifrəniz uğurla yeniləndi!";
    }

    public async Task LogoutAsync()
    {
        await _signInManager.SignOutAsync();
    }
}