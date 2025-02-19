using FitnessApp.Service.DTOs.Plan;
using FitnessApp.Service.Service.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FitnessApp.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PlanController : ControllerBase
{
    private readonly IPlanService _service;

    public PlanController(IPlanService service)
    {
        _service = service;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetPlanById(int id)
    {
        return Ok(await _service.GetByIdAsync(id));
    }

    [HttpGet("withTrainer")]
    public IActionResult GetPlanWithTrainer()
    {
        return Ok(_service.GetPlansWithTrainer());
    }

    [HttpGet("withoutTrainer")]
    public IActionResult GetPlanWithoutTrainer()
    {
        return Ok(_service.GetPlansWithoutTrainer());
    }

    [HttpPost("create")]
    public async Task<IActionResult> Create(CreatePlanDto createPlanDto)
    {
        return StatusCode(StatusCodes.Status201Created, await _service.CreateAsync(createPlanDto));
    }

    [HttpPut("update")]
    public async Task<IActionResult> Update(UpdatePlanDto updatePlanDto)
    {
        return Ok(await _service.UpdateAsync(updatePlanDto));
    }

    [HttpDelete("delete/{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _service.DeleteAsync(id);
        return Ok();
    }
    
    
}