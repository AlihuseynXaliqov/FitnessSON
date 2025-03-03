using System.Security.Claims;
using FitnessApp.DAL.Repo.Interface;
using FitnessApp.Service.DTOs.Payment;
using FitnessApp.Service.Service.Implementation.Cart;
using FitnessApp.Service.Service.Interface.Cart;
using Microsoft.AspNetCore.Authorization;

namespace FitnessApp.API.Controllers.Payment;

using Microsoft.AspNetCore.Mvc;
using Stripe;
using System.Linq;
using System.Threading.Tasks;


[Route("api/[controller]")]
[ApiController]
[Authorize]
public class PaymentController : ControllerBase
{
    private readonly StripeService _stripeService;

    public PaymentController(StripeService stripeService)
    {
        _stripeService = stripeService;
    }

    [HttpPost("payment")]
    public async Task<IActionResult> CreatePayment([FromBody] PaymentDto paymentDto)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);// Assuming the user ID is stored in the username
        var session = await _stripeService.CreateCheckoutSession(paymentDto, userId);

        return Ok(new
        {
            SessionId = session.Id,
            CheckoutUrl = session.Url  // URL to redirect to Stripe Checkout page
        });
    }

}

