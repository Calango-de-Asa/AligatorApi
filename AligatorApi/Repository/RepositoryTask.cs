using AligatorApi.Context;
using AligatorApi.Models;
using System;
using System.Linq.Expressions;

namespace AligatorApi.Repository
{
    public class RepositoryTask : Repository<Task>, IRepositoryTask
    {
        public RepositoryTask(DatabaseContext context) : base(context)
        { }

        public override Expression<Func<Task, object>> OrderFunction() => (x => x.Name);
    }
}
