using AutoMapper;
using FitnessApp.Core;
using FitnessApp.Core.Plan;
using FitnessApp.Service.DTOs.Plan;

namespace FitnessApp.Service.Mapper.Plan;

public class PlanProfile:Profile
{
    public PlanProfile()
    {
        CreateMap<CreatePlanDto, PricingPlan>().ReverseMap();
        CreateMap<GetPlanDto, PricingPlan>()
            .ForMember(dest => dest.Duration, opt => opt.MapFrom(src => src.Duration.ToString())).ReverseMap();
        CreateMap<UpdatePlanDto, PricingPlan>().ReverseMap();
    }
}