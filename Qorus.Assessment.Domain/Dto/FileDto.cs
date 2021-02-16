using System;

namespace Qorus.Assessment.Domain.Dto
{
    public class FileDto
    {
        public string Name { get; set; }
        public long Size { get; set; }
        public string Category { get; set; }
        public DateTime LastReviewed { get; set; }
        public string URL { get; set; }
    }
}
