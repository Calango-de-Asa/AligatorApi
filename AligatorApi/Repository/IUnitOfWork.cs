using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AligatorApi.Repository
{
    interface IUnitOfWork
    {
        IRepositoryBill RepositoryBill { get; }
        IRepositoryHouse RepositoryHouse { get; }
        IRepositoryNotice RepositoryNotice { get; }
        IRepositoryPerson RepositoryPerson { get; }
        IRepositoryTask RepositoryTask { get; }

        void Commit();
    }
}
