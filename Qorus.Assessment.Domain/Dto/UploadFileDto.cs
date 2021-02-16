using System;

namespace Qorus.Assessment.Domain.Dto
{
    public class UploadFileDto
    {
        public string Name { get; set; }
        public string FileMimeType { get; set; }
        public byte[] FileData { get; set; }
        public string Category { get; set; }
        public DateTime LastReviewed { get; set; }
        public long Size { get; set; }
    }
}
