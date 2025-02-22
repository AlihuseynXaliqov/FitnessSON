using System.Security.Claims;
using FitnessApp.Service.Service.Interface.Wish;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FitnessApp.API.Controllers.Wish;

[Route("api/[controller]")]
[ApiController] 
[Authorize]
public class WishlistController:ControllerBase
{
    
    private readonly IWishlistService _wishlistService;

    public WishlistController(IWishlistService wishlistService)
    {
        _wishlistService = wishlistService;
    }

    [HttpPost("add-to-wishlist/{productId}")]
    public async Task<IActionResult> AddToWishlist(int productId)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        await _wishlistService.Create(userId, productId);
        return Ok("Product added to wishlist");
    }

    [HttpDelete("remove-from-wishlist/{productId}")]
    public async Task<IActionResult> RemoveFromWishlist(int productId)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        await _wishlistService.RemoveFromWishlistAsync(productId, userId);
        return NoContent();
    }

    [HttpGet("get-all-wishlists")]
    public async Task<IActionResult> GetWishlist()
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        var wishlist = await _wishlistService.GetWishlist(userId);
        return Ok(wishlist);
    }
}