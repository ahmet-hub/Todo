using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Todo.Core.Interfaces
{
    public interface IRepository<T> : IDisposable where T : class, new()
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetAsync(string id);
        Task<T> GetFilterAsync(Expression<Func<T, bool>> predicate);
        Task<IEnumerable<T>> GetWhereAsync(Expression<Func<T, bool>> predicate = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = "");
        Task AddAsync(T entity);
        Task Update(T entity);
        Task DeleteAsync(string id);
        Task Delete(T entity);
    }
}
