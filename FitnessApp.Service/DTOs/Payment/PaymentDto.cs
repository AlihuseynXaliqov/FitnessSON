namespace FitnessApp.Service.DTOs.Payment;


public record PaymentDto
{
    public string BillingName { get; set; }
    public string BillingEmail { get; set; }
    public string BillingPhone { get; set; }
    public decimal TotalAmount { get; set; }
    public BillingAddressDto BillingAddress { get; set; }
}
