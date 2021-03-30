using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces.Repositories
{
   public interface IAsyncRepository<T> where T: class
    {
        Task<T> GetByIdAsync(int Id);

        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task RemoveAsync(T entity);
        Task<IReadOnlyCollection<T>> GetAllAsync();

        Task<IEnumerable<T>> GetWhereAsync(Expression<Func<T, bool>> predicate);
        Task<int> CountAll();
 
        Task<int> CountWhere(Expression<Func<T, bool>> predicate);
    }
}
