using AutoMapper;
using FitnessApp.Core;
using FitnessApp.Core.FeedBack;
using FitnessApp.Core.Plan;
using FitnessApp.Core.User;
using FitnessApp.Service.DTOs.Client;
using FitnessApp.Service.DTOs.Plan;
using FitnessApp.Service.DTOs.User;

namespace FitnessApp.Service.Mapper.User;

public class UserProfile:Profile
{
    public UserProfile()
    {
        CreateMap<RegisterDto, AppUser>().ReverseMap();
        CreateMap<AppUser, UserDto>();
        CreateMap<ClientFeedBack, GetFeedBackDto>();
        CreateMap<UserPlan, GetPlanDto>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Plan.Name))
            .ForMember(dest => dest.Duration, opt => opt.MapFrom(src => src.Plan.Duration.ToString()))
            .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Plan.Price))
            .ForMember(dest => dest.withTrainer, opt => opt.MapFrom(src => src.Plan.withTrainer));
    
    }
}