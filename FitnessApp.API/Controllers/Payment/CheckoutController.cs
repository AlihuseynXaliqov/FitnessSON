using FitnessApp.DAL.Repo.Interface;
using FitnessApp.Service.DTOs.Payment;
using FitnessApp.Service.Service.Implementation.Cart;
using FitnessApp.Service.Service.Interface.Cart;

namespace FitnessApp.API.Controllers.Payment;

using Microsoft.AspNetCore.Mvc;
using Stripe;
using System.Linq;
using System.Threading.Tasks;

[Route("api/checkout")]
public class CheckoutController : ControllerBase
{
    private readonly ICartItemsService _cartItemsService;
    private readonly IStripeService _stripeService;
    private readonly IProductRepository _productRepository;

    public CheckoutController(ICartItemsService cartItemsService, IStripeService stripeService, IProductRepository productRepository)
    {
        _cartItemsService = cartItemsService;
        _stripeService = stripeService;
        _productRepository = productRepository;
    }

    // Checkout işlemi
    [HttpPost("process-payment")]
    public async Task<IActionResult> ProcessPayment([FromBody] CheckoutRequest request)
    {
        // Sepeti al
        var cartItems = await _cartItemsService.GetCartAsync(request.UserId);
        
        if (!cartItems.Any())
        {
            return BadRequest(new { Message = "Sepet boş!" });
        }

        // Toplam tutarı hesapla
        decimal totalAmount = 0;
        foreach (var item in cartItems)
        {
            var product = await _productRepository.GetByIdAsync(item.Id);
            totalAmount += product.Price * item.Quantity;
        }

        // Stripe ödeme işlemi
        var charge = _stripeService.CreateCharge(request.Token, totalAmount, request.ReceiptEmail);

        // Eğer ödeme başarılıysa
        if (charge.Status == "succeeded")
        {
            // Ödeme başarılı, sepeti temizle
            await _cartItemsService.ClearCartAsync(request.UserId);
            return Ok(new { Message = "Ödeme başarılı", ChargeId = charge.Id });
        }
        else
        {
            // Ödeme başarısız
            return BadRequest(new { Message = "Ödeme başarısız" });
        }
    }
}
