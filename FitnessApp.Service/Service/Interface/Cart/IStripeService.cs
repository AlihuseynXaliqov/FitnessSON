using Stripe;

namespace FitnessApp.Service.Service.Interface.Cart;

public interface IStripeService
{
    Charge CreateCharge(string tokenId, decimal amount, string receiptEmail);
}