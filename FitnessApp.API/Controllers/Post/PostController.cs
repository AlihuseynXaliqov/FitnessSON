using FitnessApp.Service.DTOs.Post;
using FitnessApp.Service.Service.Interface;
using FitnessApp.Service.Service.Interface.Post;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FitnessApp.API.Controllers.Post;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class PostController : ControllerBase
{
    private readonly IPostService _service;

    public PostController(IPostService service)
    {
        _service = service;
    }

    [HttpGet]
    [AllowAnonymous]
    public ICollection<GetPostDto> GetAll()
    {
        return _service.GetAll();
    }

    [HttpGet("{id}")]
    [AllowAnonymous]
    public async Task<IActionResult> GetById(int id)
    {
        return StatusCode(200, await _service.GetByIdAsync(id));
    }

    [HttpPost("create")]
    public async Task<IActionResult> Create(CreatePostDto dto)
    {
        return StatusCode(201, await _service.CreateAsync(dto));
    }


    [HttpPut("update/{id}")]
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

    [Authorize(Roles = "Admin")]
    [HttpPut("approvePost")]
    public async Task<IActionResult> ApprovePost(int id)
    {
        await _service.ApprovePostAsync(id);
        return Ok();
    }
}