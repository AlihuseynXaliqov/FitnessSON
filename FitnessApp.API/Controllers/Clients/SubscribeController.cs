using FitnessApp.Service.DTOs.Plan;
using FitnessApp.Service.Service.Interface;
using FitnessApp.Service.Service.Interface.Clients;
using FitnessApp.Service.Service.Interface.Plan;
using Microsoft.AspNetCore.Mvc;

namespace FitnessApp.API.Controllers.Clients;

[Route("api/[controller]")]
[ApiController]
public class SubscribeController:ControllerBase
{
    private readonly ISubscribePlanService _service;

    public SubscribeController(ISubscribePlanService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<IActionResult> Create(SubscribePlanDto dto)
    {
       return StatusCode(201,await _service.SubscribePlan(dto));
    }
}