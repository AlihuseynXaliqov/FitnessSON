using FitnessApp.Core.Base;
using FitnessApp.Service.DTOs.Contact;
using FitnessApp.Service.Service.Interface.Clients;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FitnessApp.API.Controllers.Clients;

[Route("api/[controller]")]
[ApiController]
[Authorize(Roles = "Admin")]
public class ContactController : ControllerBase
{
    private readonly IContactService _contactService;

    public ContactController(IContactService contactService)
    {
        _contactService = contactService;
    }

    [HttpGet("contacts")]
    public IActionResult GetAll()
    {
        return Ok(_contactService.GetAll());
    }

    [HttpGet("contacts/{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        return Ok(await _contactService.GetById(id));
    }

    [AllowAnonymous]
    [HttpPost("create")]
    public async Task<IActionResult> Create(CreateContactDto dto)
    {
        var message = await _contactService.Create(dto);
        return StatusCode(StatusCodes.Status201Created, new { success = true, message });
    }

    [HttpDelete("delete/{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _contactService.Delete(id);
        return Ok();
    }
}