using System.Collections.Generic;
using System.Data;

namespace OrderProcess.Data.Interface
{
    public interface IProductRepository
    {
        void Create(ProductDTO Product);
        void Update(ProductDTO Product);
        void Delete(int id);
        IEnumerable<ProductDTO> FindProducts(string firstName);
        IEnumerable<ProductDTO> FindBlocked();
        void Map(IDataRecord record, ProductDTO Product);
        IEnumerable<ProductDTO> GetAllProducts();
    }
}