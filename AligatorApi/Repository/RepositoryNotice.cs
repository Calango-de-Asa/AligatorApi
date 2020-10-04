using AligatorApi.Context;
using AligatorApi.Models;
using AligatorApi.Pagination;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace AligatorApi.Repository
{
    public class RepositoryNotice : Repository<Notice>, IRepositoryNotice
    {
        public RepositoryNotice(DatabaseContext context) : base(context)
        {
        }

        public override Expression<Func<Notice, object>> OrderFunction() => (x => x.CreatedAt);
        public override PagedList<Notice> Get(PaginationParameters pp)
        {
            return PagedList<Notice>.ToPagedList(
                Get().OrderByDescending(OrderFunction()), pp.PageNumber, pp.PageSize);
        }

    }
}
