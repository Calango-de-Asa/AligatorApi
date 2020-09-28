using AligatorApi.Context;
using AligatorApi.Models;

namespace AligatorApi.Repository
{
    public class RepositoryTask : Repository<Task>, IRepositoryTask
    {
        public RepositoryTask(DatabaseContext context) : base(context)
        { }
    }
}
