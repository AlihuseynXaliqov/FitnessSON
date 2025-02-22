using AutoMapper;
using FitnessApp.Service.DTOs.Coupon;

namespace FitnessApp.Service.Mapper.Coupon;

public class CouponProfile:Profile
{
    public CouponProfile()
    {
        CreateMap<GetCouponDto, Core.Products.Coupon>().ReverseMap();
        CreateMap<CreateCouponDto, Core.Products.Coupon>().ReverseMap();
        CreateMap<UpdateCouponDto, GetCouponDto>().ReverseMap();
    }
}