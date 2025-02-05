using AutoMapper;
using FitnessApp.Core;
using FitnessApp.Service.DTOs.Class;

namespace FitnessApp.Service.Mapper.Class;

public class ClassProfile:Profile
{
    public ClassProfile()
    {
        CreateMap<CreateClassDto, Classes>().ReverseMap();
        CreateMap<UpdateClassDto, Classes>().ReverseMap();
        CreateMap<GetClassDto, Classes>().ReverseMap();

    }
}