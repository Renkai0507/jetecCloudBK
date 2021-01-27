using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BkServer.Repository.Interface
{
    public interface IRepositoryBase<T>  where T : class
    {
        IQueryable<T> GetAll();
        List<T> GetAllList();
         List<T> UseQuery(string sql);
        Task<List<T>> GetAllListAsync();
        List<T> GetAllList(Expression<Func<T,bool>> expression);
        Task<List<T>> GetAllListAsync(Expression<Func<T,bool>> expression);
        T Single(Expression<Func<T,bool>> expression);
        Task<T> SingleAsync(Expression<Func<T,bool>> expression);
        T FirstOrDefault(Expression<Func<T,bool>> expression);
        Task<T> FirstorDefaultAsync(Expression<Func<T,bool>> expression);
        T Insert(T entity);
        Task<T> InsertAsync(T entity);
        T Update(T entity);
        Task<T> UpdateAsync(T entity);
        void Delete(T entity);
        Task DeleteAsync(T entity);
        void Delete(Expression<Func<T,bool>> expression);
        Task DeleteAsync(Expression<Func<T,bool>> expression);
        int count();
        Task<int> CountAsync();

        Task<int> CountAsync(Expression<Func<T,bool>> expression);
        long LongCount();
        Task<long> LongCountAsync();
        long LongCount(Expression<Func<T,bool>> expression);
        Task<long> LongCountAsync(Expression<Func<T,bool>> expression);


    }
    
}