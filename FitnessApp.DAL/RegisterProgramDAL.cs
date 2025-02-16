using FitnessApp.DAL.Repo.Abstraction;
using FitnessApp.DAL.Repo.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace FitnessApp.DAL;

public static class RegisterProgramDAL
{
    public static void AddRegisterDAL(this IServiceCollection services)
    {
        services.AddScoped<ITrainerRepository, TrainerRepository>();
        services.AddScoped<IClassRepository, ClassRepository>();
        services.AddScoped<IScheduleRepository, ScheduleRepository>();
        services.AddScoped<IClientRepository, ClientRepository>();
        services.AddScoped<IPositionRepository, PositionRepository>();
        services.AddScoped<IPostRepository, PostRepository>();
        services.AddScoped<IPlanRepository, PlanRepository>();
        services.AddScoped<IProductRepository, ProductRepository>();

    }
}