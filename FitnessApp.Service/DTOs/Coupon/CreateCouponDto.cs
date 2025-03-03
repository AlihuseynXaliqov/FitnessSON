﻿namespace FitnessApp.Service.DTOs.Coupon;

public record CreateCouponDto
{
    public string Code { get; set; }
    public decimal DiscountAmount { get; set; }
    public DateTime ExpiryDate { get; set; }
    public bool IsPercentage { get; set; }
}