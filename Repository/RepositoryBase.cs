using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using BkServer.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace BkServer.Repository
{
    public class RepositoryBase<T> : IRepositoryBase<T>  where T :class
    {
        public DbContext DbContext{set;get;}
        public virtual DbSet<T> Table => DbContext.Set<T>();

        public RepositoryBase(DbContext dbContext)
        {
            DbContext = dbContext;                                
        }

        public IQueryable<T> GetAll()
        {            
            return Table.AsQueryable();
        }
        public  List<T> UseQuery(string sqlquery)
        {            
            return  Table.FromSqlRaw(sqlquery).ToList();
        }
        
      

        public List<T> GetAllList()
        {
            return GetAll().ToList();
        }

        public async Task<List<T>> GetAllListAsync()
        {
            return await GetAll().ToListAsync();            
        }

        public List<T> GetAllList(Expression<Func<T, bool>> expression)
        {
            return GetAll().Where(expression).ToList();
        }

        public async Task<List<T>> GetAllListAsync(Expression<Func<T,bool>> expression)
        {
            return await GetAll().Where(expression).ToListAsync();
            
        }

        public T Single(Expression<Func<T, bool>> expression)
        {
            return GetAll().Single(expression);
        }

        public async Task<T> SingleAsync(Expression<Func<T, bool>> expression)
        {
            return await GetAll().SingleAsync(expression);
        }

        public T FirstOrDefault(Expression<Func<T, bool>> expression)
        {
            return GetAll().FirstOrDefault(expression);
        }

        public async Task<T> FirstorDefaultAsync(Expression<Func<T, bool>> expression)
        {
            var entity=await GetAll().FirstOrDefaultAsync(expression);
            return entity;
            
        }

        public T Insert(T entity)
        {
            var newEntity =Table.Add(entity).Entity;
            Save();
            return newEntity;
        }

        public async Task<T> InsertAsync(T entity)
        {
             var entityEntry =await Table.AddAsync(entity);
            await SaveAsync();
            return entityEntry.Entity;
        }

        public T Update(T entity)
        {
            AttachIfNot(entity);
            DbContext.Entry(entity).State=EntityState.Modified;
            Save();
            return entity;
        }

        public async Task<T> UpdateAsync(T entity)
        {
            AttachIfNot(entity);
            DbContext.Entry(entity).State=EntityState.Modified;
            await SaveAsync();

            return entity;
        }

        public void Delete(T entity)
        {
            AttachIfNot(entity);
            Table.Remove(entity);
            Save();
        }

        public async Task DeleteAsync(T entity)
        {
             AttachIfNot(entity);
            Table.Remove(entity);
            await SaveAsync();
        }

        public void Delete(Expression<Func<T, bool>> expression)
        {
            foreach(var entity in GetAll().Where(expression).ToList())
            {
                Delete(entity);
            }
        }

        public async Task DeleteAsync(Expression<Func<T, bool>> expression)
        {
             foreach(var entity in GetAll().Where(expression).ToList())
            {
               await DeleteAsync(entity);
            }
        }

        public int count()
        {
           return GetAll().Count();
        }

        public async Task<int> CountAsync()
        {
           return await GetAll().CountAsync();
        }

        public async Task<int> CountAsync(Expression<Func<T,bool>> expression)
        {
            return await GetAll().Where(expression).CountAsync();
        }

        public long LongCount()
        {
            return GetAll().LongCount();
        }

        public async Task<long> LongCountAsync()
        {
             return await GetAll().LongCountAsync();
        }

        public long LongCount(Expression<Func<T,bool>> expression)
        {
              return   GetAll().Where(expression).LongCount();
        }

        public async Task<long> LongCountAsync(Expression<Func<T,bool>> expression)
        {
             return await GetAll().Where(expression).LongCountAsync();
        }
        protected virtual void AttachIfNot(T entity)
        {
            var entry= DbContext.ChangeTracker.Entries()
            .FirstOrDefault(ent => ent.Entity==entity);
            if (entry!=null)
            {
                return;
            }
            Table.Attach(entity);
        }
        protected void Save()
        {
            DbContext.SaveChanges();
        }
        protected async Task SaveAsync()
        {
            await DbContext.SaveChangesAsync();
        }
      

       
    }
    
}