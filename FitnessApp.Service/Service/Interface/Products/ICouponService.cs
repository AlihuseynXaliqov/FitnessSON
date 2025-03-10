using FitnessApp.Service.DTOs.Coupon;

namespace FitnessApp.Service.Service.Interface.Products;

public interface ICouponService
{
    Task Delete(int id);
    Task<string> ApplyCouponAsync(ApplyCouponRequestDto couponRequestDto);
    Task Update(UpdateCouponDto dto);
    ICollection<GetCouponDto> GetAll();
    Task<GetCouponDto> GetById(int id);
    Task AddCoupon(CreateCouponDto dto);
}