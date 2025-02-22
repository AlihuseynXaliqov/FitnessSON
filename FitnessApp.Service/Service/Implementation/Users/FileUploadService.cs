using FitnessApp.Service.DTOs.File;
using FitnessApp.Service.Helper.UploadFile;
using FitnessApp.Service.Service.Interface;
using FitnessApp.Service.Service.Interface.Users;
using Microsoft.AspNetCore.Hosting;

namespace FitnessApp.Service.Service.Implementation.Users;

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
    
    public Task<bool> DeleteFileAsync(string fileOrFolderName)
    {
        return Task.FromResult(FileExtention.Delete(_web.WebRootPath,fileOrFolderName ));
    }

}