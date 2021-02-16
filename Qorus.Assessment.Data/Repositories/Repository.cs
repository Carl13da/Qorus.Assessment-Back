using Microsoft.EntityFrameworkCore;
using Qorus.Assessment.Data.Contexts;
using Qorus.Assessment.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Qorus.Assessment.Data.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly SqlContext _context;
        protected readonly DbSet<TEntity> DbSet;

        public Repository(SqlContext sqlContext)
        {
            _context = sqlContext;
            DbSet = _context.Set<TEntity>();
        }
       
        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task Create(TEntity obj)
        {
            await DbSet.AddAsync(obj);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await DbSet.ToListAsync();
        }

        public virtual async Task<TEntity> GetById(Guid id)
        {
            return await DbSet.FindAsync(id);
        }

        public virtual async Task<TEntity> GetFirst()
        {
            return await DbSet.FirstOrDefaultAsync();
        }

        public async Task<int> SaveChanges()
        {
            return await _context.SaveChangesAsync();
        }

        public virtual async Task Update(TEntity obj)
        {
            await Task.Run(() => DbSet.Update(obj));
            await _context.SaveChangesAsync();
        }
    }
}
