using Microsoft.AspNetCore.Http;

namespace Qorus.Assessment.API.Helpers
{
    public static class FilesHelper
    {
        public static byte[] GetFileData(IFormFile file)
        {
            long length = file.Length;

            using var fileStream = file.OpenReadStream();
            byte[] bytes = new byte[length];
            fileStream.Read(bytes, 0, (int)file.Length);

            return bytes;
        }
    }
}
