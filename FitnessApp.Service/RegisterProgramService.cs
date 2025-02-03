using System.Reflection;
using FitnessApp.Service.DTOs.User;
using FitnessApp.Service.Service.Implementation;
using FitnessApp.Service.Service.Interface;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;

namespace FitnessApp.Service;

public static class RegisterProgramService
{
    public static void AddRegisterService(this IServiceCollection services)
    {
        services.AddScoped<IUserService,UserService>();
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddControllers().AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<RegisterValidator>());
    }
}