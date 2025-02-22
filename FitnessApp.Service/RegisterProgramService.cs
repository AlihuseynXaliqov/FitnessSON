using System.Reflection;
using FitnessApp.Service.DTOs.User;
using FitnessApp.Service.Helper.Email;
using FitnessApp.Service.Service.Implementation;
using FitnessApp.Service.Service.Implementation.Cart;
using FitnessApp.Service.Service.Implementation.Clients;
using FitnessApp.Service.Service.Implementation.Plan;
using FitnessApp.Service.Service.Implementation.Post;
using FitnessApp.Service.Service.Implementation.Products;
using FitnessApp.Service.Service.Implementation.Trainers;
using FitnessApp.Service.Service.Implementation.Users;
using FitnessApp.Service.Service.Implementation.Wish;
using FitnessApp.Service.Service.Interface;
using FitnessApp.Service.Service.Interface.Cart;
using FitnessApp.Service.Service.Interface.Clients;
using FitnessApp.Service.Service.Interface.Plan;
using FitnessApp.Service.Service.Interface.Post;
using FitnessApp.Service.Service.Interface.Products;
using FitnessApp.Service.Service.Interface.Trainers;
using FitnessApp.Service.Service.Interface.Users;
using FitnessApp.Service.Service.Interface.Wish;
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
        services.AddScoped<IPlanService, PlanService>();
        services.AddScoped<IProductService, ProductService>();
        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<ITagService, TagService>();
        services.AddScoped<ICartItemsService, CartItemsService>();
        services.AddScoped<IWishlistService, WishlistService>();
        services.AddScoped<ISubscribePlanService, SubscribePlanService>();
        services.AddScoped<ICouponService, CouponService>();
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddTransient<IMailService, MailService>();
        services.AddControllers().AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<RegisterValidator>());
        services.Configure<MailSettings>(configuration.GetSection("MailSettings"));
        services.AddHttpContextAccessor();

    }
}