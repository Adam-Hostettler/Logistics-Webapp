using System.Collections.Generic;
using System.Data;

namespace OrderProcess.Data.Interface
{
    public interface IProductOnHandRepository
    {
        void Create(ProductOnHandDTO product);
        void Update(ProductOnHandDTO product);
        void Update(int productId, int quantity);
        void Delete(int id);
        IEnumerable<ProductOnHandDTO> FindProductOnHands(string firstName);
        IEnumerable<ProductOnHandDTO> FindBlocked();
        void Map(IDataRecord record, ProductOnHandDTO product);
        IEnumerable<ProductOnHandDTO> GetAllProductOnHand();
    }
}