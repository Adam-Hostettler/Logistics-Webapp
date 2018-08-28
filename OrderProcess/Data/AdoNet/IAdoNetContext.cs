using System.Data;

namespace OrderProcess.Data.AdoNet
{
    public interface IAdoNetContext
    {
        IDbCommand CreateCommand();
        IUnitOfWork CreateUnitOfWork();
        void Dispose();
    }
}