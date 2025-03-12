using AutoMapper;
using FitnessApp.Core.Products;
using FitnessApp.DAL.Repo.Abstraction;
using FitnessApp.DAL.Repo.Interface;
using FitnessApp.Service.DTOs.Coupon;
using FitnessApp.Service.Helper.Exception.Base;
using FitnessApp.Service.Service.Interface.Products;
using Microsoft.AspNetCore.Http;

namespace FitnessApp.Service.Service.Implementation.Products;

public class CouponService : ICouponService
{
    private readonly ICouponRepository _repository;
    private readonly IMapper _mapper;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public CouponService(ICouponRepository repository, IMapper mapper, IHttpContextAccessor httpContextAccessor)
    {
        _repository = repository;
        _mapper = mapper;
        _httpContextAccessor = httpContextAccessor;
    }


    public async Task<string> ApplyCouponAsync(ApplyCouponRequestDto couponRequestDto)
    {
        var coupon = await _repository.GetCouponByCode(couponRequestDto.CouponCode);

        if (coupon == null) throw new NotFoundException("Kupon tapilmadi", 404);

        if (coupon.ExpiryDate < DateTime.UtcNow || !coupon.IsActive)
            throw new Helper.Exception.Auth.NotFoundException("Kupon sehvdir", 400);
        
        int couponDiscountAmount = (int)coupon.DiscountAmount;
        

        return $"{couponDiscountAmount}";
    }


    public async Task AddCoupon(CreateCouponDto dto)
    {
        var coupon = _mapper.Map<Coupon>(dto);
        await _repository.AddAsync(coupon);
        await _repository.SaveChangesAsync();
    }

    public async Task<GetCouponDto> GetById(int id)
    {
        if (id <= 0) throw new NegativeIdException("Id menfi ve ya sifir ola bilmez", 400);
        var coupon = await _repository.GetByIdAsync(id);
        if (coupon == null) throw new NotFoundException("Kupon tapilmadi", 400);

        return _mapper.Map<GetCouponDto>(coupon);
    }

    public ICollection<GetCouponDto> GetAll()
    {
        var coupons = _repository.GetAll();
        return _mapper.Map<ICollection<GetCouponDto>>(coupons);
    }

    public async Task Update(UpdateCouponDto dto)
    {
        var couponDto = await GetById(dto.Id);
        _mapper.Map(dto, couponDto);
        var coupon = _mapper.Map<Coupon>(couponDto);
        _repository.Update(coupon);
        await _repository.SaveChangesAsync();
    }

    public async Task Delete(int id)
    {
        var couponDto = await GetById(id);
        var coupon = _mapper.Map<Coupon>(couponDto);
        _repository.Delete(coupon);
        await _repository.SaveChangesAsync();
    }
}