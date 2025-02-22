namespace FitnessApp.Service.DTOs.Coupon;

public class CreateCouponDto
{
    public string Code { get; set; }
    public decimal DiscountAmount { get; set; }
    public DateTime ExpiryDate { get; set; }
    public bool IsPercentage { get; set; }
}