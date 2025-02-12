using AutoMapper;
using FitnessApp.Core;
using FitnessApp.DAL;
using FitnessApp.DAL.Repo.Interface;
using FitnessApp.Service.DTOs.Schedule;
using FitnessApp.Service.Helper.Exception.Base;
using FitnessApp.Service.Helper.Exception.Schedule;
using FitnessApp.Service.Service.Interface;
using Microsoft.EntityFrameworkCore;

namespace FitnessApp.Service.Service.Implementation;

public class ScheduleService : IScheduleService
{
    private readonly IMapper _mapper;
    private readonly IScheduleRepository _repository;
    private readonly AppDbContext _dbContext;

    public ScheduleService(IMapper mapper, IScheduleRepository repository, AppDbContext dbContext)
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
                    && (createScheduleDto.StartTime >= x.StartTime && 
                        createScheduleDto.EndTime <= x.EndTime))
            ));
        if (toqqusma)
        {
            return false;
        }

        var schedule = _mapper.Map<Schedule>(createScheduleDto);
        await _repository.AddAsync(schedule);
        await _repository.SaveChangesAsync();
        return true;
    }

    public async Task<GetScheduleDto> GetSchedule(int Id)
    {
        if (Id <= 0) throw new NegativeIdException("Id menfi ve ya sifir ola bilmez", 404);

        var schedule = await _repository
            .GetAll("Class", "Trainer")
            .AsNoTracking().FirstOrDefaultAsync(x => x.Id == Id);
        if (schedule == null) throw new NotFoundException("Cədvəl tapılmadı!", 404);
        var scheduleDto = _mapper.Map<GetScheduleDto>(schedule);
        return scheduleDto;
    }

    public ICollection<GetScheduleDto> GetSchedules()
    {
        var schedule = _repository.GetAll("Class", "Trainer");
        return _mapper.Map<ICollection<GetScheduleDto>>(schedule);
    }

    public async Task<bool> UpdateSchedule(UpdateScheduleDto updateScheduleDto)
    {
        var schedule = _repository.GetAll("Class", "Trainer")
            .FirstOrDefault(x => x.Id == updateScheduleDto.Id);

        if (schedule == null) throw new NotFoundException("Cədvəl tapılmadı!", 404);

        bool toqqusma = await _dbContext.Schedules.AnyAsync(x =>
            x.IsDeleted &&
            x.TrainerId == updateScheduleDto.TrainerId &&
            x.DayOfWeek == updateScheduleDto.DayOfWeek &&
            ((
                (updateScheduleDto.StartTime >= x.StartTime &&
                 updateScheduleDto.StartTime < x.EndTime) || // Yeni dərsin başlanğıcı mövcud dərsin vaxtına düşür
                (updateScheduleDto.EndTime > x.StartTime &&
                 updateScheduleDto.EndTime <= x.EndTime) || // Yeni dərsin bitmə vaxtı mövcud dərsin vaxtına düşür
                (updateScheduleDto.StartTime <= x.StartTime &&
                 updateScheduleDto.EndTime >= x.EndTime) // Yeni dərs mövcud dərsi tam əhatə edir
            )));
        if (toqqusma)
        {
            return false;
        }

        _mapper.Map(updateScheduleDto, schedule);
        _repository.Update(schedule);
        await _repository.SaveChangesAsync();
        return true;
    }

    public async Task DeleteSchedule(int Id)
    {
        if (Id <= 0) throw new NegativeIdException("Id menfi ve ya sifir ola bilmez", 404);
        var schedule = await GetSchedule(Id);
        var oldSchedule = _mapper.Map<Schedule>(schedule);
        _repository.Delete(oldSchedule);
        await _repository.SaveChangesAsync();
    }
}