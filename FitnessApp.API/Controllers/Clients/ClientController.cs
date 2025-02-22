using FitnessApp.Service.DTOs.Client;
using FitnessApp.Service.Service.Interface;
using FitnessApp.Service.Service.Interface.Clients;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FitnessApp.API.Controllers.Clients;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class ClientController : ControllerBase
{
    private readonly IClientService _service;

    public ClientController(IClientService service)
    {
        _service = service;
    }

    [HttpGet]
    [AllowAnonymous]
    public IActionResult GetAll()
    {
        return Ok(_service.GetAllAsync());
    }

    [HttpGet("{id}")]
    [AllowAnonymous]
    public async Task<IActionResult> GetById(int id)
    {
        return Ok(await _service.GetByIdAsync(id));
    }

    [HttpPost("create")]
    public async Task<IActionResult> Create(CreateFeedBackDto dto)
    {
        return StatusCode(201, await _service.CreateAsync(dto));
    }


    [HttpPut("update/{id}")]
    public async Task<IActionResult> Update(UpdateFeedBackDto dto)
    {
        await _service.UpdateAsync(dto);
        return Ok();
    }

    [HttpDelete("delete/{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _service.DeleteAsync(id);
        return Ok();
    }

    [HttpGet("confirmedFeedbacks")]
    public IActionResult GetUnconfirmedFeedbacks()
    {
        return Ok(_service.GetAllUnconfirmedFeedBack());
    }

    [HttpPut("unconfirmedFeedbacks/{id}")]
    public async Task<IActionResult> UpdateUnconfirmedFeedbacks(int id)
    {
       await _service.ConfirmFeedBack(id);
       return Ok();
    }

}