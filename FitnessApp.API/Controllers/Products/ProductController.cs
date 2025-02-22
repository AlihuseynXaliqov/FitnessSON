using FitnessApp.Service.DTOs.Product;
using FitnessApp.Service.Service.Interface;
using FitnessApp.Service.Service.Interface.Products;
using Microsoft.AspNetCore.Mvc;

namespace FitnessApp.API.Controllers.Products;

[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly IProductService _service;

    public ProductController(IProductService service)
    {
        _service = service;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        return Ok(await _service.GetById(id));
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(_service.GetAll());
    }

    [HttpPost("create")]
    public async Task<IActionResult> Create(CreateProductDto product)
    {
        return Ok(await _service.Create(product));
    }

    [HttpPut("update/{id}")]
    public async Task<IActionResult> Update(UpdateProductDto product)
    {
        return Ok(await _service.Update(product));
    }

    [HttpDelete("delete/{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _service.Delete(id);
        return Ok();
    }

    [HttpPut("IncreaseStock")]
    public async Task<IActionResult> IncreaseStock(int productId, int quantity)
    {
       
        return Ok( await _service.IncreaseStock(productId, quantity));
    }
    
    [HttpPut("ReduceStock")]
    public async Task<IActionResult> ReduceStock(int productId, int quantity)
    {
        
        return Ok(await _service.ReduceStock(productId, quantity));
    }

}