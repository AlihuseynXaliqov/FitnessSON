using FitnessApp.Service.DTOs.File;
using FitnessApp.Service.Helper.UploadFile;
using FitnessApp.Service.Service.Interface;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace FitnessApp.Service.Service.Implementation;

public class FileUploadService : IFIleUploadService
{
    private readonly IWebHostEnvironment _web;

    public FileUploadService(IWebHostEnvironment web)
    {
        _web = web;
    }

    public async Task<GetFileUploadDto> UploadFile(CreateUploadFileDto dto)
    {
        var imageUrl = dto.File.Upload(_web.WebRootPath, dto.FolderName);
        return new GetFileUploadDto()
        {
            ImageUrl = imageUrl
        };
    }
    
    public Task<bool> DeleteFileAsync(string folderName, string fileName)
    {
        return Task.FromResult(FileExtention.Delete(_web.WebRootPath, folderName, fileName));
    }

}