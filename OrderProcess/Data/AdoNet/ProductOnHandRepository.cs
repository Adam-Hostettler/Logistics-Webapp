using System;
using System.Collections.Generic;
using System.Data;
using OrderProcess.Data.Extensions;
using OrderProcess.Data.Interface;
using OrderProcess.Domain;

namespace OrderProcess.Data.AdoNet
{
    public class ProductOnHandRepository : Repository<ProductOnHandDTO>, IProductOnHandRepository
    {
        public ProductOnHandRepository(IAdoNetContext context) : base(context)
        {
        }

        public void Create(ProductOnHandDTO product)
        {
            using (var command = _context.CreateCommand())
            {
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "spLogistic_InsertProductOnHand";
                command.ExecuteNonQuery();
            }

            //todo: Get identity. Depends on the db engine.
        }

        public void Update(ProductOnHandDTO product)
        {
            using (var command = _context.CreateCommand())
            {
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "spLogistic_UpdateProductOnHand";
                command.ExecuteNonQuery();

                //command.CommandText =
                //    @"UPDATE ProductOnHands SET CompanyId = @companyId WHERE Id = @ProductOnHandId";
                //command.AddParameter("companyId", 1);
                //command.AddParameter("ProductOnHandId", 1);
                //command.ExecuteNonQuery();
            }
        }

        public void Update(int productId, int quantity)
        {
            using (var command = _context.CreateCommand())
            {
                command.AddParameter("@ProductId", productId);
                command.AddParameter("@Quantity", quantity);
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "spLogistic_UpdateProductOnHandQuantity";
                command.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ProductOnHandDTO> FindProductOnHands(string firstName)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ProductOnHandDTO> FindBlocked()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Maps the data from the database (IDataRecrod record) to the a new ProductOnHandDTO ProductOnHand.
        /// </summary>
        /// <param name="record">Holds the data from the database.</param>
        /// <param name="product">A new ProductOnHandDTO</param>
        public override void Map(IDataRecord record, ProductOnHandDTO product)
        {
            product.Product = new ProductDTO();
            product.Product.PartNumber = (string) record["PartNumber"];
            product.Quantity = (int) record["Quantity"];
            product.Product.PartName = (string) record["PartName"];
            product.Product.Supplier = (string) record["Supplier"];
            product.Product.DropoffLocation = (string) record["DropoffLocation"];
            product.Product.ID = (int) record["ID"];
        }

        public IEnumerable<ProductOnHandDTO> GetAllProductOnHand()
        {
            using (var command = _context.CreateCommand())
            {
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "spLogistic_GetProductsOnHand";
                //command.CommandText =
                //    @"SELECT * FROM ProductOnHands";
                return ToList(command);
            }
        }
    }
}