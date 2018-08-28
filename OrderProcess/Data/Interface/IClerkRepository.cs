using System.Collections.Generic;
using System.Data;
using OrderProcess.Domain;

namespace OrderProcess.Data.Interface
{
    public interface IClerkRepository
    {
        void Create(Clerk Clerk);
        void Update(Clerk Clerk);
        void Delete(int id);
        IEnumerable<Clerk> FindClerks(string firstName);
        IEnumerable<Clerk> FindBlocked();
        void Map(IDataRecord record, Clerk Clerk);
    }
}