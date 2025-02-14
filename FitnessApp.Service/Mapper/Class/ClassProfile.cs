using AutoMapper;
using FitnessApp.Core;
using FitnessApp.Service.DTOs.Class;

namespace FitnessApp.Service.Mapper.Class;

public class ClassProfile:Profile
{
    public ClassProfile()
    {
        CreateMap<CreateClassDto, Classes>().ReverseMap();
        CreateMap<Classes, GetClassDto>()
            .ForMember(dest => dest.Schedules, opt => opt.MapFrom(src => src.Schedules.Select(s => new ClassScheduleDto
            {
                TrainerName = $"{s.Trainer.FirstName} {s.Trainer.LastName}",
                DayOfWeek = s.DayOfWeek,
                StartTime = s.StartTime.ToString(@"hh\:mm"),
                EndTime = s.EndTime.ToString(@"hh\:mm")
            }).ToList()));
        
        
        CreateMap<UpdateClassDto, Classes>().ReverseMap();

    }
}