using System.Collections.Generic;
using System.Data;
using OrderProcess.Domain;

namespace OrderProcess.Data.Interface
{
    public interface IDeliveryDriverRepository
    {
        void Create(DeliveryDriver DeliveryDriver);
        void Update(DeliveryDriver DeliveryDriver);
        void Delete(int id);
        IEnumerable<DeliveryDriver> FindDeliveryDrivers(string firstName);
        IEnumerable<DeliveryDriver> FindBlocked();
        void Map(IDataRecord record, DeliveryDriver DeliveryDriver);
    }
}