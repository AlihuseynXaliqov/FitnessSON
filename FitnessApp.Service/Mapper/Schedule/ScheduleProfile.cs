using AutoMapper;
using FitnessApp.Service.DTOs.Schedule;

namespace FitnessApp.Service.Mapper.Schedule;

public class ScheduleProfile: Profile
{
    public ScheduleProfile()
    {
        CreateMap<Core.Schedule, CreateScheduleDto>().ReverseMap();
    }
}