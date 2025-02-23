using FitnessApp.Core.Products;

namespace FitnessApp.DAL.Repo.Interface;

public interface ICouponRepository:IRepository<Coupon>
{
    Task<Coupon?> GetCouponByCode(string code);

}