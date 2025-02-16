using AutoMapper;
using FitnessApp.Core;
using FitnessApp.Core.FeedBack;
using FitnessApp.Service.DTOs.Client;

namespace FitnessApp.Service.Mapper.Client;

public class ClientProfile : Profile
{
    public ClientProfile()
    {
        CreateMap<ClientFeedBack, CreateFeedBackDto>().ReverseMap();
        CreateMap<ClientFeedBack, GetFeedBackDto>()
            .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.User.FirstName))
            .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.User.LastName));
        CreateMap<ClientFeedBack, UpdateFeedBackDto>().ReverseMap();

    }
}