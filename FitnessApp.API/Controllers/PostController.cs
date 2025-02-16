using FitnessApp.Service.DTOs.Post;
using FitnessApp.Service.Service.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace FitnessApp.API.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize(Roles = "Admin")]

public class PostController : ControllerBase
{
    private readonly IPostService _service;

    public PostController(IPostService service)
    {
        _service = service;
    }

    [HttpGet]
    public ICollection<GetPostDto> GetAll()
    {
        return _service.GetAll();
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        return StatusCode(200, await _service.GetByIdAsync(id));
    }

    [HttpPost("create")]
    public async Task<IActionResult> Create(CreatePostDto dto)
    {
        return StatusCode(201, await _service.CreateAsync(dto));
    }


    [HttpPut("update")]
    public async Task<IActionResult> Update(UpdatePostDto dto)
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