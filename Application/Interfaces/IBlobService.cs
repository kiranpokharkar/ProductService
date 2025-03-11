namespace ProductService.Application.Interfaces
{
    public interface IBlobService
    {
        Task<string> UploadFileAsync(Stream fileStream, string fileName, string contentType);

        Task<bool> DeleteFileAsync(string fileName);
    }
}
