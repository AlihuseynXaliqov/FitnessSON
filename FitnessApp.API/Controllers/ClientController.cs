using FitnessApp.Service.DTOs.Client;
using FitnessApp.Service.Service.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FitnessApp.API.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class ClientController:ControllerBase
{
    private readonly IClientService _service;

    public ClientController(IClientService service)
    {
        _service = service;
    }
    [HttpGet]
    public  IActionResult GetAll()
    {
        return Ok(_service.GetAllAsync());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        return Ok(await _service.GetByIdAsync(id));
    }

    [HttpPost("create")]
    public async Task<IActionResult> Create(CreateFeedBackDto dto)
    {
        return StatusCode(201,await _service.CreateAsync(dto));
    }


    [HttpPut("update/{id}")]
    public async Task<IActionResult> Update(UpdateFeedBackDto dto)
    {
        await _service.UpdateAsync(dto);
        return Ok();
    }

    [HttpDelete("delete/{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _service.DeleteAsync(id);
        return Ok();
    }
    
}