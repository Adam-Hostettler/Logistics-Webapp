using System.Data;

namespace OrderProcess.Data.AdoNet
{
    public interface IConnectionFactory
    {
        IDbConnection Create();
    }
}