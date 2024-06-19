using Microsoft.AspNetCore.Mvc;

namespace Fruitable.Utilities
{
    public interface IFileService
    {
        Task<string> UploadFileAsync(IFormFile file, string uploadPath);
        Task<FileContentResult> DownloadFileAsync(string filePath);
    }

    public class FileService : IFileService
    {
        public async Task<string> UploadFileAsync(IFormFile file, string uploadPath)
        {
            if (file == null || file.Length == 0)
                throw new ArgumentException("File is empty");

            var filePath = Path.Combine(uploadPath, Path.GetFileName(file.FileName));

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return filePath;
        }

        public async Task<FileContentResult> DownloadFileAsync(string filePath)
        {
            var fileBytes = await File.ReadAllBytesAsync(filePath);
            var contentType = "APPLICATION/octet-stream";
            return new FileContentResult(fileBytes, contentType)
            {
                FileDownloadName = Path.GetFileName(filePath)
            };
        }
    }
}
