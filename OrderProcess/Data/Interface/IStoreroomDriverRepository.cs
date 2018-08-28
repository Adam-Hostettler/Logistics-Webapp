using System.Collections.Generic;
using System.Data;
using OrderProcess.Data.AdoNet;
using OrderProcess.Domain;

namespace OrderProcess.Data.Interface
{
    public interface IStoreroomDriverRepository
    {
        void Create(StoreroomDriver StoreroomDriver);
        void Update(StoreroomDriver StoreroomDriver);
        void Delete(int id);
        IEnumerable<StoreroomDriver> FindStoreroomDrivers(string firstName);
        IEnumerable<StoreroomDriver> FindBlocked();
        void Map(IDataRecord record, StoreroomDriver StoreroomDriver);
        AdoNetContext Context { get; }
        IEnumerable<StoreroomDriver> ToList(IDbCommand command);
    }
}