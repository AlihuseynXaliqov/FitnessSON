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

     return StatusCode(201, "Cədvıl uğurla əlavə edildi");
    }
    
}