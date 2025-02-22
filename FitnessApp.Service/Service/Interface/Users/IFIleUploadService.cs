using FitnessApp.Service.DTOs.File;

namespace FitnessApp.Service.Service.Interface.Users;

public interface IFIleUploadService
{
    Task<GetFileUploadDto> UploadFile(CreateUploadFileDto dto);
    Task<bool> DeleteFileAsync(string fileOrFolderName);
}