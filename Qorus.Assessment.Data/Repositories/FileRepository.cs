using Microsoft.EntityFrameworkCore;
using Qorus.Assessment.Data.Contexts;
using Qorus.Assessment.Domain.Interfaces.Repositories;
using Qorus.Assessment.Domain.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Qorus.Assessment.Data.Repositories
{
    public class FileRepository : Repository<File>, IFileRepository
    {
        public FileRepository(SqlContext sqlContext) : base(sqlContext)
        {

        }

        public override async Task<File> GetFirst()
        {
            return await Task.Run(() => DbSet
                .FirstOrDefaultAsync());
        }

        public override async Task<File> GetById(Guid id)
        {
            return await Task.Run(() => DbSet
                 .Where(x => x.Id == id)
                 .FirstOrDefaultAsync());
        }
    }
}
