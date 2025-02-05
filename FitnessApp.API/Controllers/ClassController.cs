using FitnessApp.Service.DTOs.Class;
using FitnessApp.Service.Service.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FitnessApp.API.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class ClassController : ControllerBase
{
    private readonly IClassService _classService;

    public ClassController(IClassService classService)
    {
        _classService = classService;
    }

    /*[AllowAnonymous] */
    [HttpPost("create")]
    public async Task<IActionResult> Create(CreateClassDto dto)
    {
        await _classService.CreateClass(dto);
        return StatusCode(201, dto);
    }
}