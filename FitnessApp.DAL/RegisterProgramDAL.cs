﻿using FitnessApp.DAL.Repo.Abstraction;
using FitnessApp.DAL.Repo.Interface;
using Hangfire;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FitnessApp.DAL;

public static class RegisterProgramDAL
{
    public static void AddRegisterDAL(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<ITrainerRepository, TrainerRepository>();
        services.AddScoped<IClassRepository, ClassRepository>();
        services.AddScoped<IScheduleRepository, ScheduleRepository>();
        services.AddScoped<IClientRepository, ClientRepository>();
        services.AddScoped<IPositionRepository, PositionRepository>();
        services.AddScoped<IPostRepository, PostRepository>();
        services.AddScoped<IPlanRepository, PlanRepository>();
        services.AddScoped<ISubscribePlanRepository, SubscribePlanRepository>();
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<ITagRepository, TagRepository>();
        services.AddScoped<IWishlistRepository, WishlistRepository>();
        services.AddScoped<ICartItemsRepository, CartItemsRepository>();
        services.AddScoped<ICouponRepository, CouponRepository>();
        services.AddScoped<IContactRepository, ContactRepository>();
        services.AddHangfire
            (config => config.UseSqlServerStorage(configuration.GetConnectionString("deploy")));
        services.AddHangfireServer();

    }
}