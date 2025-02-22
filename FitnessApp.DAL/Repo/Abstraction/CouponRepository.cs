using FitnessApp.Core.Products;
using FitnessApp.DAL.Repo.Interface;
using Microsoft.EntityFrameworkCore;

namespace FitnessApp.DAL.Repo.Abstraction;

public class CouponRepository:Repository<Coupon>,ICouponRepository
{
    public CouponRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<Coupon?> GetCouponByCode(string code)
    {
        return await Table.FirstOrDefaultAsync(c => c.Code == code && c.IsActive && c.ExpiryDate > DateTime.Now);
    }
}