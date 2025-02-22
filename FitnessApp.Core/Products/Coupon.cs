using FitnessApp.Core.Base;

namespace FitnessApp.Core.Products;

public class Coupon : BaseEntity
{
    public string Code { get; set; }
    public decimal DiscountAmount { get; set; }
    public DateTime ExpiryDate { get; set; }
    public bool IsPercentage { get; set; }
}