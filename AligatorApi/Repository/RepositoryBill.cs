using AligatorApi.Context;
using AligatorApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AligatorApi.Repository
{
    public class RepositoryBill : Repository<Bill>, IRepositoryBill
    {
        public RepositoryBill(DatabaseContext context) : base(context)
        {
        }
    }
}
