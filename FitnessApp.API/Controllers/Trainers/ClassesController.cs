using FitnessApp.Service.DTOs.Class;
using FitnessApp.Service.Service.Interface;
using FitnessApp.Service.Service.Interface.Trainers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FitnessApp.API.Controllers.Trainers;

[Route("api/[controller]")]
[ApiController]
[Authorize(Roles = "Admin")]
public class ClassesController : ControllerBase
{
    private readonly IClassService _classService;

    public ClassesController(IClassService classService)
    {
        _classService = classService;
    }

    [HttpGet]
    [AllowAnonymous]
    public ICollection<GetClassDto> GetAllClasses()
    {
        return _classService.GetAllClasses();
    }

    [HttpGet("{id}")]
    [AllowAnonymous]
    public async Task<IActionResult> GetByIdClasses(int id)
    {
        return StatusCode(200, await _classService.GetClass(id));
    }
    
    [HttpPost("create")]
    public async Task<IActionResult> CreateClass([FromForm]CreateClassDto dto)
    {
        await _classService.CreateClass(dto);
        return StatusCode(201);
    }

    [HttpPut("update/{id}")]
    public async Task<IActionResult> UpdateClass([FromForm]UpdateClassDto dto)
    {
        await _classService.UpdateClass(dto);
        return StatusCode(200);
    }
    
    [HttpDelete("delete/{id}")]
    public async Task<IActionResult> DeleteClass(int id)
    {
        await _classService.DeleteClass(id);
        return StatusCode(200);
    }
}