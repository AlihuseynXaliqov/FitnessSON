using AutoMapper;
using FitnessApp.Core;
using FitnessApp.Service.DTOs.Client;

namespace FitnessApp.Service.Mapper.Client;

public class ClientProfile : Profile
{
    public ClientProfile()
    {
        CreateMap<ClientFeedBack, CreateFeedBackDto>().ReverseMap();
        CreateMap<ClientFeedBack, GetFeedBackDto>()
            .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.User.FirstName))
            .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.User.LastName))
            .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.User.Id));

        CreateMap<ClientFeedBack, UpdateFeedBackDto>().ReverseMap();

    }
}