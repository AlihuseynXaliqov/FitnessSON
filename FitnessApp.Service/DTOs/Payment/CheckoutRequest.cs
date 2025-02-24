namespace FitnessApp.Service.DTOs.Payment;

public class CheckoutRequest
{
    public string UserId { get; set; }
    public string Token { get; set; }  // Stripe token
    public string ReceiptEmail { get; set; }  // Kullanıcı e-maili
}
