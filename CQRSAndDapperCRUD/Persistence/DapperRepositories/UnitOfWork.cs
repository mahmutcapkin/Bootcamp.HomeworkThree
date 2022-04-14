using Application.Repositories;
using System.Data;

namespace Persistence.DapperRepositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDbTransaction _dbTransaction;
        public UnitOfWork(IDbTransaction dbTransaction)
        {
            _dbTransaction = dbTransaction;
        }

        public void Commit()
        {
            _dbTransaction.Commit();
        }

        public void RollBack()
        {
            _dbTransaction.Rollback();
        }
    }
}
