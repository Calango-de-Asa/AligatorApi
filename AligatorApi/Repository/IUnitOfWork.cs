using System.Threading.Tasks;

namespace AligatorApi.Repository
{
    public interface IUnitOfWork
    {
        IRepositoryBill RepositoryBill { get; }
        IRepositoryHouse RepositoryHouse { get; }
        IRepositoryNotice RepositoryNotice { get; }
        IRepositoryPerson RepositoryPerson { get; }
        IRepositoryTask RepositoryTask { get; }

        Task Commit();
    }
}
