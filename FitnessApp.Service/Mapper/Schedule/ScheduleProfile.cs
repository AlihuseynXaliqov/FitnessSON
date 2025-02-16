using AutoMapper;
using FitnessApp.Service.DTOs.Schedule;

namespace FitnessApp.Service.Mapper.Schedule;

public class ScheduleProfile: Profile
{
    public ScheduleProfile()
    {
        CreateMap<Core.Class.Schedule, CreateScheduleDto>().ReverseMap();
        CreateMap<GetScheduleDto, Core.Class.Schedule>().ReverseMap()
            .ForMember(dest => dest.ClassName, opt => opt.MapFrom(src => src.Class.Name))
            .ForMember(dest => dest.TrainerFirstName, opt => opt.MapFrom(src => src.Trainer.FirstName))
            .ForMember(dest => dest.TrainerLastName, opt => opt.MapFrom(src => src.Trainer.LastName));
        CreateMap<Core.Class.Schedule,UpdateScheduleDto>().ReverseMap();
    }
}