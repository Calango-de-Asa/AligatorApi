using AligatorApi.Context;
using AligatorApi.Models;
using System;
using System.Linq.Expressions;

namespace AligatorApi.Repository
{
    public class RepositoryBill : Repository<Bill>, IRepositoryBill
    {
        public RepositoryBill(DatabaseContext context) : base(context)
        {
        }

        public override Expression<Func<Bill, object>> OrderFunction() => (x => x.Name);
    }
}
