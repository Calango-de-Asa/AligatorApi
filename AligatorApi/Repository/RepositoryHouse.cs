using AligatorApi.Context;
using AligatorApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AligatorApi.Repository
{
    public class RepositoryHouse : Repository<House>, IRepositoryHouse
    {
        public RepositoryHouse(DatabaseContext context) : base(context)
        {
        }
    }
}
