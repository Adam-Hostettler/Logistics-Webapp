using System;
using System.Data;

namespace OrderProcess.Data.AdoNet
{
    public class AdoNetUnitOfWork : IUnitOfWork
    {
        private readonly Action<AdoNetUnitOfWork> _committed;
        private readonly Action<AdoNetUnitOfWork> _rolledBack;
        private IDbTransaction _transaction;

        public AdoNetUnitOfWork(IDbTransaction transaction, Action<AdoNetUnitOfWork> rolledBack,
            Action<AdoNetUnitOfWork> committed)
        {
            Transaction = transaction;
            _transaction = transaction;
            _rolledBack = rolledBack;
            _committed = committed;
        }

        public IDbTransaction Transaction { get; }

        public void Dispose()
        {
            if (_transaction == null)
                return;
            _transaction.Rollback();
            _transaction.Dispose();
            _rolledBack(this);
            _transaction = null;
        }

        public void SaveChanges()
        {
            if (_transaction == null)
                throw new InvalidOperationException("May not call save changes twice.");
            _transaction.Commit();
            _committed(this);
            _transaction = null;
        }
    }
}