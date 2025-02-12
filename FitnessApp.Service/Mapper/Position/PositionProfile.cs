using AutoMapper;
using FitnessApp.Core;
using FitnessApp.Service.DTOs.Position;

namespace FitnessApp.Service.Mapper.Position;

public class PositionProfile:Profile
{
    public PositionProfile()
    {
        CreateMap<TrainerPosition, CreatePositionDto>().ReverseMap();
        CreateMap<TrainerPosition, UpdatePositionDto>().ReverseMap();
        CreateMap<TrainerPosition, GetPositionDto>().ReverseMap();
    }
}