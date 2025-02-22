using FitnessApp.Service.DTOs.Category;
using FitnessApp.Service.Service.Interface;
using FitnessApp.Service.Service.Interface.Products;
using Microsoft.AspNetCore.Mvc;

namespace FitnessApp.API.Controllers.Products;

[Route("api/[controller]")]
[ApiController]
public class CategoryController:ControllerBase
{
    private readonly ICategoryService _service;

    public CategoryController(ICategoryService service)
    {
        _service = service;
    }
    
    [HttpGet]
    public ICollection<GetCategoryDto> GetAll()
    {
        return _service.GetAll();
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        return StatusCode(200, await _service.GetByIdAsync(id));
    }
    
    [HttpPost("create")]
    public async Task<IActionResult> Create([FromForm]CreateCategoryDto dto)
    {
        await _service.CreateAsync(dto);
        return StatusCode(201);
    }

    [HttpPut("update/{id}")]
    public async Task<IActionResult> Update([FromForm]UpdateCategoryDto dto)
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