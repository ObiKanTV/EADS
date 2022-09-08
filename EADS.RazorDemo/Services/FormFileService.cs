namespace EADS.RazorDemo.Services
{
    public class FormFileService : IFormFileService
    {
        public async Task<byte[]> ToByteArray(FormFile formFile)
        {
            using var memoryStream = new MemoryStream();
            await formFile.CopyToAsync(memoryStream);

            // Upload the file if less than 2 MB
            // if (memoryStream.Length < 2097152)
            return memoryStream.ToArray();
        }
        public async Task<IFormFile> ToFormFile(byte[] bytes, string name, string fileName)
        {
            using var memoryStream = new MemoryStream(bytes);

            return new FormFile(memoryStream, 0, bytes.Length, name, fileName);
        }
    }

    public interface IFormFileService
    {
        Task<IFormFile> ToFormFile(byte[] bytes, string name, string fileName);
        Task<byte[]> ToByteArray(FormFile formFile);
    }
}
