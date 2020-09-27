using AligatorApi.Context;
using AligatorApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AligatorApi.Repository
{
    public class RepositoryNotice : Repository<Notice>, IRepositoryNotice
    {
        public RepositoryNotice(DatabaseContext context) : base(context)
        {
        }
    }
}
