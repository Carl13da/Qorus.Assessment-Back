using Microsoft.EntityFrameworkCore;
using Qorus.Assessment.Data.Mappings;
using Qorus.Assessment.Domain.Models;

namespace Qorus.Assessment.Data.Contexts
{
    public class SqlContext : DbContext
    {
        public SqlContext(DbContextOptions<SqlContext> options) : base(options) { }

        public DbSet<File> Files { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            FileMap.Map(modelBuilder);
        }
    }
}
