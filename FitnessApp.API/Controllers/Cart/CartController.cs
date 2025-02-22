using System.Security.Claims;
using FitnessApp.Service.Service.Interface.Cart;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace FitnessApp.API.Controllers.Cart;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class CartController : ControllerBase
{
    private readonly ICartItemsService _service;

    public CartController(ICartItemsService service)
    {
        _service = service;
    }

    [HttpPost("add-to-cart/{productId}")]
    public async Task<IActionResult> AddToCart(int productId, [FromForm] int quantity)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        await _service.Create(userId, productId, quantity);
        return Ok("Product added to cart");
    }

    [HttpGet("cart")]
    public async Task<IActionResult> GetCart()
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        var cart = await _service.GetCartAsync(userId);
        return Ok(cart);
    }

    [HttpPut("update-cart/{productId}")]
    public async Task<IActionResult> UpdateCart(int productId, [FromForm] int quantity)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        await _service.UpdateCartAsync(productId, userId, quantity);
        return Ok("Cart updated");
    }

    [HttpDelete("remove-from-cart/{productId}")]
    public async Task<IActionResult> RemoveFromCart(int productId)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        await _service.RemoveFromCartAsync(productId, userId);
        return NoContent();
    }

    [HttpDelete("clear-cart")]
    public async Task<IActionResult> ClearCart()
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        await _service.ClearCartAsync(userId);
        return NoContent();
    }
}