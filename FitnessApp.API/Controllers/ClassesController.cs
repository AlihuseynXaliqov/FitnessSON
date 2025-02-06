using FitnessApp.Service.DTOs.Class;
using FitnessApp.Service.Service.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FitnessApp.API.Controllers;

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

    [HttpPost("[action]")]
    public async Task<IActionResult> CreateClass(CreateClassDto dto)
    {
        await _classService.CreateClass(dto);
        return StatusCode(201);
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> UpdateClass(UpdateClassDto dto)
    {
        await _classService.UpdateClass(dto);
        return StatusCode(200);
    }


    [HttpGet("[action]")]
    public async Task<IActionResult> GetByIdClasses(int id)
    {
        return StatusCode(200, await _classService.GetClass(id));
    }

    [HttpGet("[action]")]
    public ICollection<GetClassDto> GetAllClasses()
    {
        return _classService.GetAllClasses();
    }

    [HttpDelete("[action]")]
    public async Task<IActionResult> DeleteClass(int id)
    {
        await _classService.DeleteClass(id);
        return StatusCode(200);
    }
}