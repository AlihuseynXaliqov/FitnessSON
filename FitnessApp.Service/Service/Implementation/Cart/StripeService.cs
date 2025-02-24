using FitnessApp.Service.Service.Interface.Cart;
using Microsoft.Extensions.Configuration;
using Stripe;

namespace FitnessApp.Service.Service.Implementation.Cart;

public class StripeService:IStripeService
{
    private readonly string _secretKey;

    public StripeService(IConfiguration configuration)
    {
        _secretKey = configuration["Stripe:Secretkey"];
    }

    public Charge CreateCharge(string tokenId, decimal amount, string receiptEmail)
    {
        StripeConfiguration.ApiKey = _secretKey;

        var options = new ChargeCreateOptions
        {
            Amount = (long)(amount * 100), // Amount in cents (Stripe cent cinsinden işlem yapar)
            Currency = "usd",  // Currency
            Description = "Product Purchase", // Description
            Source = tokenId, // Token generated on frontend
            ReceiptEmail = receiptEmail,  // Receipt email
        };

        var service = new ChargeService();
        Charge charge = service.Create(options);

        return charge;
    }
}