using FitnessApp.Core.User;
using FitnessApp.DAL;
using FitnessApp.Service.Helper.Email;
using FitnessApp.Service.Service.Interface.Users;
using Microsoft.EntityFrameworkCore;

namespace FitnessApp.Service.Service.Implementation.Plan;

using FitnessApp.Core.Stripe;
using FitnessApp.Service.DTOs.Plan;
using FitnessApp.Service.Service.Interface.Plan;
using Microsoft.Extensions.Options;
using Stripe;
using Stripe.Checkout;

public class PlanStripeService
{
    private readonly IMailService _mailService;
    private readonly AppDbContext _appDbContext;
    private readonly ISubscribePlanService _subscribePlanService;

    public PlanStripeService(IOptions<StripeSettings> stripeSettings,IMailService mailService,AppDbContext appDbContext, ISubscribePlanService subscribePlanService)
    {
        _mailService = mailService;
        _appDbContext = appDbContext;
        _subscribePlanService = subscribePlanService;
        StripeConfiguration.ApiKey = stripeSettings.Value.Secretkey;
    }

    public async Task<Session> CreatePlanCheckoutSession(decimal price, string userId, int planId)
    {
        var user = await _appDbContext.Users.FirstOrDefaultAsync(x => x.Id == userId);
        if (user == null)
        {
            throw new Exception("İstifadəçi tapılmadı!");
        }

        var options = new SessionCreateOptions
        {
            PaymentMethodTypes = new List<string> { "card" },
            LineItems = new List<SessionLineItemOptions>
            {
                new()
                {
                    Quantity = 1,
                    PriceData = new SessionLineItemPriceDataOptions
                    {
                        Currency = "usd",
                        UnitAmount = (long)(price * 100),
                        ProductData = new SessionLineItemPriceDataProductDataOptions
                        {
                            Name = "Plan Abunəliyi",
                            Description = "FitnessApp üçün plan abunəliyi"
                        }
                    }
                }
            },
            Mode = "payment",
            SuccessUrl = "http://localhost:5179/plan-success?session_id={CHECKOUT_SESSION_ID}",
            CancelUrl = "http://localhost:5179/plan-cancel",
            Metadata = new Dictionary<string, string>
            {
                { "userId", userId },
                { "planId", planId.ToString() }
            }
        };

        var sessionService = new SessionService();
        var session = await sessionService.CreateAsync(options);

        return session;
    }
    
    
}