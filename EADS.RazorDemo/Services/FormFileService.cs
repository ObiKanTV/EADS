namespace EADS.RazorDemo.Services
{
    public class FormFileService : IFormFileService
    {
        public async Task<string> ToString(FormFile formFile)
        {
            using var memoryStream = new MemoryStream();
            await formFile.CopyToAsync(memoryStream);

            // Upload the file if less than 2 MB
            // if (memoryStream.Length < 2097152)
            return Convert.ToBase64String(memoryStream.ToArray());
        }
        public async Task<byte[]> ToByteArray(FormFile formFile)
        {
            using var memoryStream = new MemoryStream();
            await formFile.CopyToAsync(memoryStream);

            // Upload the file if less than 2 MB
            // if (memoryStream.Length < 2097152)
            return memoryStream.ToArray();
        }
        public async Task<FormFile> ToFormFile(byte[] bytes, string name, string fileName)
        {
            using var memoryStream = new MemoryStream(bytes);

            return new FormFile(memoryStream, 0, bytes.Length, name, fileName);
        }
        public async Task<FormFile> ToFormFile(string dataString, string contentType, string fileName)
        {
            var bytes = Convert.FromBase64String(dataString);
            using var memoryStream = new MemoryStream(bytes);
            return new FormFile(memoryStream, 0, bytes.Length, fileName, fileName);
        }
    }

    public interface IFormFileService
    {
        Task<FormFile> ToFormFile(string dataString, string name, string fileName);
        Task<FormFile> ToFormFile(byte[] bytes, string name, string fileName);
        Task<byte[]> ToByteArray(FormFile formFile);
        Task<string> ToString(FormFile formFile);
    }
}
