using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Web.Entity
{
    public interface IRepository<T> where T : class
    {
        Task CreateAsync(T entity);

        Task<List<T>> ReadAllAsync();

        Task<(List<T> Lista, int Total)> ReadAllFilterAsync(int skip, int take);

        Task UpdateAsync(T entity);
        Task DeleteAsync(long id);


        Task<T> ReadAsync(long id);

        Task<List<T>> ReadAllAsync(Expression<Func<T, bool>> filter);
    }
}
