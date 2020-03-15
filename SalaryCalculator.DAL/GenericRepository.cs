using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SalaryCalculator.DAL.Interfaces;
using SalaryCalculator.Domain;

namespace SalaryCalculator.DAL
{
    public class GenericRepository<T> : IGenericRepository<T>
        where T : Entity, new()
    {
        protected DbContext dbContext;
        private DbSet<T> dbSet;

        public GenericRepository(DbContext context)
        {
            dbContext = context;
            dbSet = dbContext.Set<T>();
        }

        public async Task<T> GetAsync(int? id)
        {
            var entity = await dbSet.FirstOrDefaultAsync(x => x.Id == id);
            return entity;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            var entities = await dbSet.ToListAsync();

            return entities;
        }

        public void Create(T entity)
        {
            dbSet.Add(entity);
        }

        public void Update(T entity)
        {
            dbContext.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(T entity)
        {
            dbSet.Remove(entity);
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await this.GetAsync(id);
            if (entity != null)
            {
                dbSet.Remove(entity);
            }
        }
    }

}
