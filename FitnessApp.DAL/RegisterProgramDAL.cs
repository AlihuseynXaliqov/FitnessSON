using FitnessApp.DAL.Repo.Abstraction;
using FitnessApp.DAL.Repo.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace FitnessApp.DAL;

public static class RegisterProgramDAL
{
    public static void AddRegisterDAL(this IServiceCollection services)
    {
        services.AddScoped<ITrainerRepository, TrainerRepository>();
        
    }
}