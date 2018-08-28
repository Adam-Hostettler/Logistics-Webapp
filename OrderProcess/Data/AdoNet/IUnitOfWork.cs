using System.Data;

namespace OrderProcess.Data.AdoNet
{
    public interface IUnitOfWork
    {
        IDbTransaction Transaction { get; }

        void Dispose();
        void SaveChanges();
    }
}