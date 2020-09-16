using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyFitnessManager.Db.Entities;

namespace MyFitnessManager.Db.Repositories
{
    public abstract class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly DbContext _context;
        private readonly DbSet<T> _dbSet;

        public Repository(DbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }
        public virtual void Create(T entity)
        { 
            _dbSet.Add(entity);
        }

        public virtual async Task<IEnumerable<T>> GetAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public virtual T Get(int id)
        {
            return _dbSet.FirstOrDefault(t => t.Id == id);
        }
        public virtual  async Task<T> GetAsync(int id)
        {
            return await _dbSet.FirstOrDefaultAsync(t => t.Id == id);
        }

        public virtual void Update(T entity)
        {
           _dbSet.Update(entity);
        }
        
        public virtual void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        public virtual async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}