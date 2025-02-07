using AutoMapper;
using FitnessApp.Core;
using FitnessApp.DAL;
using FitnessApp.DAL.Repo.Interface;
using FitnessApp.Service.DTOs.Schedule;
using FitnessApp.Service.Service.Interface;
using Microsoft.EntityFrameworkCore;

namespace FitnessApp.Service.Service.Implementation;

public class ScheduleService:IScheduleService
{
    private readonly IMapper _mapper;
    private readonly IScheduleRepository _repository;
    private readonly AppDbContext _dbContext;

    public ScheduleService(IMapper mapper,IScheduleRepository repository,AppDbContext dbContext)
    {
        _mapper = mapper;
        _repository = repository;
        _dbContext = dbContext;
    }

    public async Task<bool> CreateSchedule(CreateScheduleDto createScheduleDto)
    {
        bool toqqusma = await _dbContext.Schedules.AnyAsync(x =>
            x.TrainerId == createScheduleDto.TrainerId &&
            x.DayOfWeek == createScheduleDto.DayOfWeek &&
            ((
                (createScheduleDto.StartTime >= x.StartTime &&
                 createScheduleDto.StartTime < x.EndTime) || // Yeni dərsin başlanğıcı mövcud dərsin vaxtına düşür
                (createScheduleDto.EndTime > x.StartTime &&
                 createScheduleDto.EndTime <= x.EndTime) || // Yeni dərsin bitmə vaxtı mövcud dərsin vaxtına düşür
                (createScheduleDto.StartTime <= x.StartTime &&
                 createScheduleDto.EndTime >= x.EndTime) // Yeni dərs mövcud dərsi tam əhatə edir
            )));
        if (toqqusma)
        {
            return false;
        }
        var schedule = _mapper.Map<Schedule>(createScheduleDto);
        await _repository.AddAsync(schedule);
        await _repository.SaveChangesAsync();
        return true;
    }
}