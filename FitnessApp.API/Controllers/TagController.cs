using FitnessApp.Service.DTOs.Tag;
using FitnessApp.Service.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace FitnessApp.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TagController:ControllerBase
{
    private readonly ITagService _service;

    public TagController(ITagService service)
    {
        _service = service;
    }
    
    [HttpGet]
    public ICollection<GetTagDto> GetAll()
    {
        return _service.GetAll();
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        return StatusCode(200, await _service.GetByIdAsync(id));
    }
    
    [HttpPost("create")]
    public async Task<IActionResult> Create([FromForm]CreateTagDto dto)
    {
        await _service.CreateAsync(dto);
        return StatusCode(201);
    }

    [HttpPut("update/{id}")]
    public async Task<IActionResult> Update([FromForm]UpdateTagDto dto)
    {
        await _service.UpdateAsync(dto);
        return StatusCode(200);
    }
    
    [HttpDelete("delete/{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _service.DeleteAsync(id);
        return StatusCode(200);
    }
}