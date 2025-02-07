using FitnessApp.Service.DTOs.Schedule;

namespace FitnessApp.Service.Service.Interface;

public interface IScheduleService
{
    Task<bool> CreateSchedule(CreateScheduleDto createScheduleDto);
}