using AligatorApi.Pagination;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AligatorApi.Repository
{
    public interface IRepository<T>
    {
        IQueryable<T> Get();
        PagedList<T> Get(PaginationParameters pp);

        Expression<Func<T, object>> OrderFunction();

        Task<T> GetById(Expression<Func<T, bool>> predicate);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
