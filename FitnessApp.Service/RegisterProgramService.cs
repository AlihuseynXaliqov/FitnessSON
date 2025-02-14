using System.Reflection;
using FitnessApp.Service.DTOs.User;
using FitnessApp.Service.Helper.Email;
using FitnessApp.Service.Service.Implementation;
using FitnessApp.Service.Service.Interface;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FitnessApp.Service;

public static class RegisterProgramService
{
    public static void AddRegisterService(this IServiceCollection services,IConfiguration configuration)
    {
        services.AddScoped<IAuthService,AuthService>();
        services.AddScoped<IClassService, ClassService>();
        services.AddScoped<ITrainerService, TrainerService>();
        services.AddScoped<IClientService, ClientService>();
        services.AddScoped<IPositionService, PositionService>();
        services.AddScoped<IPostService, PostService>();
        services.AddScoped<IScheduleService, ScheduleService>();
        services.AddScoped<IFIleUploadService, FileUploadService>();
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddTransient<IMailService, MailService>();
        services.AddControllers().AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<RegisterValidator>());
        services.Configure<MailSettings>(configuration.GetSection("MailSettings"));
        services.AddHttpContextAccessor();

    }
}