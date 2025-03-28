﻿using FitnessApp.Service.DTOs.File;
using FitnessApp.Service.Service.Interface;
using FitnessApp.Service.Service.Interface.Users;
using Microsoft.AspNetCore.Mvc;

namespace FitnessApp.API.Controllers.Users;

[Route("api/[controller]")]
[ApiController]
public class FileUploadController:ControllerBase
{
    private readonly IFIleUploadService _service;

    public FileUploadController(IFIleUploadService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<IActionResult> UploadFile(CreateUploadFileDto dto)
    {
        if (dto.File.Length < 0)
        {
            return BadRequest("File duzgun deyil");
        }
        if(!dto.File.ContentType.Contains("image")) return BadRequest("File duzgun deyil");
        if(dto.File.Length>2097152 ) return BadRequest("File cox boyukdu");
        var file= await _service.UploadFile(dto);
        return Ok(file);
    }
    
    [HttpPost("delete")]
    public async Task<IActionResult> DeleteFile([FromQuery] string folderOrFileName)
    {
        await _service.DeleteFileAsync(folderOrFileName);
        return Ok(new { Message = "File ugurla silindi"});
    }


}