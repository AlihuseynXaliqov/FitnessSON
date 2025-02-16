using AutoMapper;
using FitnessApp.Core;
using FitnessApp.Core.User;
using FitnessApp.Service.DTOs.User;

namespace FitnessApp.Service.Mapper.User;

public class UserProfile:Profile
{
    public UserProfile()
    {
        CreateMap<RegisterDto, AppUser>().ReverseMap();
    }
}