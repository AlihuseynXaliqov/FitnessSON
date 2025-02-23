namespace FitnessApp.Service.DTOs.Coupon;

public class ApplyCouponRequestDto
{
    public string CouponCode { get; set; }
    public decimal TotalAmount { get; set; }
}