using AligatorApi.Context;
using AligatorApi.Models;
using System;
using System.Linq.Expressions;

namespace AligatorApi.Repository
{
    public class RepositoryPerson : Repository<Person>, IRepositoryPerson
    {
        public RepositoryPerson(DatabaseContext context) : base(context)
        {
        }


        public override Expression<Func<Person, object>> OrderFunction() => (x => x.Name);
    }
}
