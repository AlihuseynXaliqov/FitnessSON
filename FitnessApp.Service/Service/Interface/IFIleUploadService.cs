using FitnessApp.Service.DTOs.File;

namespace FitnessApp.Service.Service.Interface;

public interface IFIleUploadService
{
    Task<GetFileUploadDto> UploadFile(CreateUploadFileDto dto);
    Task<bool> DeleteFileAsync(string fileOrFolderName);
}