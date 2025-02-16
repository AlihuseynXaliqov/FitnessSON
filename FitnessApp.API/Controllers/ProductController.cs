using FitnessApp.Core.Product;
using FitnessApp.Service.DTOs.Product;
using FitnessApp.Service.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace FitnessApp.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController: ControllerBase
{
    private readonly IProductService _service;

    public ProductController(IProductService service)
    {
        _service = service;
    }

    /*[HttpPost("create")]
    public async Task<IActionResult> Create(CreateProductDto product)
    {
        return Ok(await _service.Create(product));
    }
}*/