using FitnessApp.Service.DTOs.Schedule;

namespace FitnessApp.Service.Service.Interface.Trainers;

public interface IScheduleService
{
    Task<bool> CreateSchedule(CreateScheduleDto createScheduleDto);
    Task<GetScheduleDto> GetSchedule(int Id);
    Task DeleteSchedule(int Id);
    Task<bool> UpdateSchedule(UpdateScheduleDto updateScheduleDto);
    ICollection<GetScheduleDto> GetSchedules();
}