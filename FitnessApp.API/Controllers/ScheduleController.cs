using FitnessApp.Service.DTOs.Class;
using FitnessApp.Service.DTOs.Schedule;
using FitnessApp.Service.Helper.Exception.Schedule;
using FitnessApp.Service.Service.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FitnessApp.API.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize(Roles = "Admin")]
public class ScheduleController:ControllerBase
{
    private readonly IScheduleService _scheduleService;

    public ScheduleController(IScheduleService scheduleService)
    {
        _scheduleService = scheduleService;
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> Create(CreateScheduleDto dto)
    {
     var schedule=await _scheduleService.CreateSchedule(dto);
     if (!schedule)
     {
         throw new ScheduleException("Halhazirda bu vaxt cədvəldə mövcuddur", 404);
     }

     return StatusCode(201, "Cədvəl uğurla əlavə edildi");
    }

    [HttpGet("[action]")]
    public async Task<IActionResult> GetSchedule(int id)
    {
        return Ok(await _scheduleService.GetSchedule(id));        
    }

    [HttpGet("[action]")]
    public ICollection<GetScheduleDto> GetSchedules()
    {
        return _scheduleService.GetSchedules();
    }

    [HttpPut("[action]")]
    public async Task<IActionResult> Update(UpdateScheduleDto dto)
    {
        var schedule = await _scheduleService.UpdateSchedule(dto);
        if (!schedule)
        {
            throw new ScheduleException("Halhazirda bu vaxt cədvəldə mövcuddur", 404);
        }

        return StatusCode(201, "Cədvəl uğurla dəyişdirildi");
    }

    [HttpDelete("[action]")]
    public async Task<IActionResult> Delete(int id)
    {
        await _scheduleService.DeleteSchedule(id);
        return Ok();
    }
}