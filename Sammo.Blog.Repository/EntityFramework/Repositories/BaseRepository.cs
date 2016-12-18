using EntityFramework.Extensions;
using Sammo.Blog.Domain;
using Sammo.Blog.Domain.Entities;
using Sammo.Blog.Domain.Repositories;
using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Sammo.Blog.Repository.EntityFramework.Repositories
{
    public class BaseRepository<T> : IRepository<T> where T : EntityBase
    {
        protected SammoDbContext SammoDbContext = new SammoDbContext();

        public IQueryable<T> Find(Expression<Func<T,bool>> filter)
        {
            return Filter(filter);
        }

        public Task<bool> IsExistsAsync(Expression<Func<T,bool>> filter)
        {
            return SammoDbContext.Set<T>().AnyAsync(filter);
        }

        public Task<T> FindSingleAsync(Expression<Func<T,bool>> filter)
        {
            return SammoDbContext.Set<T>().AsNoTracking().FirstOrDefaultAsync(filter);
        }

        public Task<int> GetCountAsync(Expression<Func<T,bool>> filter)
        {
            return Filter(filter).CountAsync();
        }

        public Task AddAsync(T entity)
        {
            SammoDbContext.Set<T>().Add(entity);
            return SammoDbContext.SaveChangesAsync();
        }

        public Task BatchAddAsync(T[] entities)
        {
            SammoDbContext.Set<T>().AddRange(entities);
            return SammoDbContext.SaveChangesAsync();
        }

        public Task UpdateAsync(T entity)
        {
            var entry = SammoDbContext.Entry(entity);
            entry.State = EntityState.Modified;
            return SammoDbContext.SaveChangesAsync();
        }

        public Task UpdateAsync(Expression<Func<T, object>> filter, T entity)
        {
            SammoDbContext.Set<T>().AddOrUpdate(filter, entity);
            return SammoDbContext.SaveChangesAsync();
        }

        public Task UpdateAsync(Expression<Func<T, bool>> where, Expression<Func<T, T>> entity)
        {
            return SammoDbContext.Set<T>().Where(where).UpdateAsync(entity);
        }

        public Task DeleteAsync(T entity)
        {
            SammoDbContext.Set<T>().Remove(entity);
            return SammoDbContext.SaveChangesAsync();
        }

        private IQueryable<T> Filter(Expression<Func<T,bool>> filter)
        {
            var dbSet = SammoDbContext.Set<T>().AsQueryable();
            if (dbSet != null)
                dbSet = dbSet.Where(filter);

            return dbSet;
        }
    }
}
