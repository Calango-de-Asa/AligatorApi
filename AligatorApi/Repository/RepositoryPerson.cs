using AligatorApi.Context;
using AligatorApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AligatorApi.Repository
{
    public class RepositoryPerson : Repository<Person>, IRepositoryPerson
    {
        public RepositoryPerson(DatabaseContext context) : base(context)
        {
        }
    }
}
