using AligatorApi.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AligatorApi.Repository
{
    public class RepositoryTask : Repository<Task>, IRepositoryTask
    {
        public RepositoryTask(DatabaseContext context) 
            : base(context)
        { }
    }
}
