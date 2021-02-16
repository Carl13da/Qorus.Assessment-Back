using System;

namespace Qorus.Assessment.Domain.Models
{
    public class File
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public long Size { get; set; }
        public string Category { get; set; }
        public DateTime LastReviewed { get; set; }
        public string URL { get; set; }
    }
}
