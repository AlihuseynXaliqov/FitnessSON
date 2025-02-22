using FitnessApp.Service.DTOs.Schedule;
using FitnessApp.Service.Helper.Exception.Schedule;
using FitnessApp.Service.Service.Interface;
using FitnessApp.Service.Service.Interface.Trainers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FitnessApp.API.Controllers.Trainers;

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
    
    [HttpGet]
    [AllowAnonymous]
    public ICollection<GetScheduleDto> GetSchedules()
    {
        return _scheduleService.GetSchedules();
    }

    [HttpGet("{id}")]
    [AllowAnonymous]
    public async Task<IActionResult> GetSchedule(int id)
    {
        return Ok(await _scheduleService.GetSchedule(id));        
    }

    [HttpPost("create")]
    public async Task<IActionResult> Create(CreateScheduleDto dto)
    {
     var schedule=await _scheduleService.CreateSchedule(dto);
     if (!schedule)
     {
         throw new ScheduleException("Halhazirda bu vaxt cədvəldə mövcuddur", 404);
     }

     return StatusCode(201, "Cədvəl uğurla əlavə edildi");
    }
    
    [HttpPut("update/{id}")]
    public async Task<IActionResult> Update(UpdateScheduleDto dto)
    {
        var schedule = await _scheduleService.UpdateSchedule(dto);
        if (!schedule)
        {
            throw new ScheduleException("Halhazirda bu vaxt cədvəldə mövcuddur", 404);
        }

        return StatusCode(201, "Cədvəl uğurla dəyişdirildi");
    }

    [HttpDelete("delete/{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _scheduleService.DeleteSchedule(id);
        return Ok();
    }
}