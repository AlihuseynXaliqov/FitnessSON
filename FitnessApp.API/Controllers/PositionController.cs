using FitnessApp.Service.DTOs.Position;
using FitnessApp.Service.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace FitnessApp.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PositionController: ControllerBase
{
    private readonly IPositionService _service;

    public PositionController(IPositionService positionService)
    {
        _service = positionService;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(_service.GetAll());
        
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        return Ok( await _service.GetByIdAsync(id));
    }

    [HttpPost("create")]
    public async Task<IActionResult> Create(CreatePositionDto dto)
    {
        return Ok(await _service.CreateAsync(dto));
    }

    [HttpPut("update")]
    public async Task<IActionResult> Update(UpdatePositionDto dto)
    {
        return Ok(await _service.UpdateAsync(dto));
    }

    [HttpDelete("delete/{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _service.DeleteAsync(id);
        return Ok();
    }
}