using FitnessApp.Core.Products;
using FitnessApp.Service.DTOs.Coupon;
using FitnessApp.Service.Service.Interface.Products;
using Microsoft.AspNetCore.Mvc;

namespace FitnessApp.API.Controllers.Products;

[Route("api/[controller]")]
[ApiController]

public class CouponController:ControllerBase
{
    private readonly ICouponService _couponService;

    public CouponController(ICouponService couponService)
    {
        _couponService = couponService;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(_couponService.GetAll());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        return Ok(await _couponService.GetById(id));
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateCouponDto dto)
    {
        await _couponService.AddCoupon(dto);
        return StatusCode(201);
    }

    [HttpPut("update/{id}")]
    public async Task<IActionResult> Update([FromForm] UpdateCouponDto dto)
    {
        await _couponService.Update(dto);
        return Ok();
    }

    [HttpDelete("delete/{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _couponService.Delete(id);
        return Ok();
    }
}