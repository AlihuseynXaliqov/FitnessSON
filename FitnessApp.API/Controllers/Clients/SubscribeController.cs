using System.Security.Claims;
using FitnessApp.DAL;
using FitnessApp.Service.DTOs.Plan;
using FitnessApp.Service.Helper.Email;
using FitnessApp.Service.Service.Implementation.Plan;
using FitnessApp.Service.Service.Interface;
using FitnessApp.Service.Service.Interface.Clients;
using FitnessApp.Service.Service.Interface.Plan;
using FitnessApp.Service.Service.Interface.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Stripe.Checkout;

namespace FitnessApp.API.Controllers.Clients;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class SubscribeController : ControllerBase
{
    private readonly ISubscribePlanService _service;
    private readonly IMailService _mailService;
    private readonly AppDbContext _appDbContext;
    private readonly PlanStripeService _planStripeService;
    

    public SubscribeController(ISubscribePlanService service,IMailService mailService,AppDbContext appDbContext, PlanStripeService planStripeService)
    {
        _service = service;
        _mailService = mailService;
        _appDbContext = appDbContext;
        _planStripeService = planStripeService;
    }

    [HttpPost("create-checkout-session")]
    public async Task<IActionResult> CreateCheckoutSession([FromBody] SubscribePlanDto request)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        var session = await _planStripeService.CreatePlanCheckoutSession(request.Price, userId, request.PlanId);
        return Ok(new { sessionId = session.Id, sessionUrl = session.Url });
    }
    [HttpGet("plan-success")]
    public async Task<IActionResult> Success([FromQuery] string session_id)
    {
        if (string.IsNullOrEmpty(session_id))
        {
            return BadRequest(new { message = "Session ID düzgün deyil!" });
        }

        var sessionService = new SessionService();
        Session session;
        try
        {
            session = await sessionService.GetAsync(session_id);
        }
        catch (Exception)
        {
            return BadRequest(new { message = "Session ID etibarsızdır və ya Stripe API-də tapılmadı!" });
        }

        if (session.PaymentStatus != "paid")
        {
            return BadRequest(new { message = "Ödəniş tamamlanmadı!" });
        }

        if (!session.Metadata.ContainsKey("userId") || !session.Metadata.ContainsKey("planId"))
        {
            return BadRequest(new { message = "Ödəniş məlumatları tam deyil!" });
        }

        var userId = session.Metadata["userId"];
        var planId = Convert.ToInt32(session.Metadata["planId"]);

        var result = await _service.SubscribePlanAfterPayment(userId, planId);

        var user = await _appDbContext.Users.FirstOrDefaultAsync(x => x.Id == userId);
        if (user != null)
        {
            var mailRequest = new MailRequest
            {
                ToEmail = user.Email,
                Subject = "Uğurlu Ödəniş",
                Body = $"Hörmətli {user.UserName}, sizin ödənişiniz uğurla yerinə yetirildi." +
                       "<br><br>" +
                       "Ən yaxşı arzularla,<br>" +
                       "FitnessApp Komandası"
            };

            await _mailService.SendEmailAsync(mailRequest);
        }

        return Ok(new { message = result });
    }

}