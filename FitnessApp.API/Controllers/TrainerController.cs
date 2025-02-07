using FitnessApp.Core;
using FitnessApp.Service.DTOs.Trainer;
using FitnessApp.Service.Service.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FitnessApp.API.Controllers;

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

    [HttpGet("[action]")]
    public IActionResult GetAllTrainers()
    {
        return Ok(_trainerService.GetTrainers());
    }

    [HttpGet("[action]")]
    public async Task<IActionResult> GetTrainerById(int id)
    {
        return Ok(await _trainerService.GetTrainerByIdAsync(id));
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> AddTrainer([FromForm]CreateTrainerDto dto)
    {
        return StatusCode(201, await _trainerService.CreateTrainerAsync(dto));
    }

    [HttpPut("[action]")]
    public async Task<IActionResult> UpdateTrainer([FromForm] UpdateTrainerDto dto)
    {
        return StatusCode(200, await _trainerService.UpdateTrainerAsync(dto));
    }
    
    
}