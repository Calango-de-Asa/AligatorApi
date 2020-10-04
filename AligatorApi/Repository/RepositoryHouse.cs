using AligatorApi.Context;
using AligatorApi.Models;
using System;
using System.Linq.Expressions;

namespace AligatorApi.Repository
{
    public class RepositoryHouse : Repository<House>, IRepositoryHouse
    {
        public RepositoryHouse(DatabaseContext context) : base(context)
        {
        }
        public override Expression<Func<House, object>> OrderFunction() => (x => x.Name);
    }
}
