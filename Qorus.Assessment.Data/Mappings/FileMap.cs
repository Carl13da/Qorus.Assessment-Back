using Microsoft.EntityFrameworkCore;
using Qorus.Assessment.Domain.Models;

namespace Qorus.Assessment.Data.Mappings
{
    public class FileMap
    {
        public static void Map(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<File>(v =>
            {
                v.HasKey(x => x.Id);

                v.Property(d => d.Category);
                v.Property(d => d.Name);
                v.Property(d => d.Size);
                v.Property(d => d.LastReviewed);
            });
        }
    }
}
