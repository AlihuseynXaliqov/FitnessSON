using Microsoft.AspNetCore.Http;

namespace FitnessApp.Service.DTOs.File;

public class CreateUploadFileDto
{
    public string FolderName { get; set; }
    public IFormFile File { get; set; }
}

