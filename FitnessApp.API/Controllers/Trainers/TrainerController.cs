using FitnessApp.Service.DTOs.Trainer;
using FitnessApp.Service.Service.Interface;
using FitnessApp.Service.Service.Interface.Trainers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FitnessApp.API.Controllers.Trainers;

[Route("api/[controller]")]
[ApiController]
[Authorize(Roles = "Admin")]
public class TrainerController: ControllerBase
{
    private readonly ITrainerService _trainerService;

    public TrainerController(ITrainerService trainerService)
    {
        _trainerService = trainerService;
    }

    [HttpGet]
    [AllowAnonymous]
    public IActionResult GetAllTrainers()
    {
        return Ok(_trainerService.GetTrainers());
    }

    [HttpGet("{id}")]
    [AllowAnonymous]
    public async Task<IActionResult> GetTrainerById(int id)
    {
        return Ok(await _trainerService.GetTrainerByIdAsync(id));
    }

    [HttpPost("create")]
    public async Task<IActionResult> AddTrainer([FromForm]CreateTrainerDto dto)
    {
        return StatusCode(201, await _trainerService.CreateTrainerAsync(dto));
    }

    [HttpPut("update/{id}")]
    public async Task<IActionResult> UpdateTrainer([FromForm] UpdateTrainerDto dto)
    {
        return StatusCode(200, await _trainerService.UpdateTrainerAsync(dto));
    }

    [HttpDelete("delete/{id}")]
    public async Task<IActionResult> DeleteTrainer(int id)
    {
        await _trainerService.Delete(id);
        return Ok();
    }
    
    
    
}