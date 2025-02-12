using Microsoft.AspNetCore.Http;

namespace FitnessApp.Service.Helper.UploadFile;

public static class FileExtention
{
    public static string Upload(this IFormFile file,string rootPath, string folderName)
    {
        string fileName=file.FileName;
        if (fileName.Length > 64)
        {
            fileName=fileName.Substring(fileName.Length-64);
        }
        fileName=Guid.NewGuid()+fileName;
        Directory.CreateDirectory(Path.Combine(rootPath, folderName));
        
        string path = Path.Combine(rootPath, folderName, fileName);
       
        using (FileStream fs = new FileStream(path, FileMode.Create))
        {
            file.CopyTo(fs);
        }
        return Path.Combine(folderName, fileName).Replace("\\", "/");

    }
    public static bool Delete(string rootPath, string FolderAndFileName)
    {
        var fullPath = Path.Combine(rootPath, FolderAndFileName);

        if (!File.Exists(fullPath)) return false;

        File.Delete(fullPath);
        return true;
    }

}