using AligatorApi.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AligatorApi.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private RepositoryBill _repositoryBill;
        private RepositoryHouse _repositoryHouse;
        private RepositoryNotice _repositoryNotice;
        private RepositoryPerson _repositoryPerson;
        private RepositoryTask _repositoryTask;

        public DatabaseContext _context;

        public IRepositoryBill RepositoryBill
        {
            get
            {
                return _repositoryBill ??= new RepositoryBill(_context);
            }
        }

        public IRepositoryHouse RepositoryHouse
        {
            get
            {
                return _repositoryHouse ??= new RepositoryHouse(_context);
            }
        }

        public IRepositoryNotice RepositoryNotice
        {
            get
            {
                return _repositoryNotice ??= new RepositoryNotice(_context);
            }
        }

        public IRepositoryPerson RepositoryPerson
        {
            get
            {
                return _repositoryPerson ??= new RepositoryPerson(_context);
            }
        }

        public IRepositoryTask RepositoryTask
        {
            get
            {
                return _repositoryTask ??= new RepositoryTask(_context);
            }
        }

        public UnitOfWork(DatabaseContext context)
        {
            _context = context;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
