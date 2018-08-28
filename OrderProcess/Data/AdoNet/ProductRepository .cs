using System;
using System.Collections.Generic;
using System.Data;
using OrderProcess.Data.Extensions;
using OrderProcess.Data.Interface;
using OrderProcess.Domain;

namespace OrderProcess.Data.AdoNet
{
    public class ProductRepository : Repository<ProductDTO>, IProductRepository
    {
        public ProductRepository(IAdoNetContext context) : base(context)
        {
        }

        public void Create(ProductDTO product)
        {
            using (var command = _context.CreateCommand())
            {
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "spLogistic_InsertProduct";
                command.AddParameter("@PartNumber", product.PartNumber);
                command.AddParameter("@PartName", product.PartName);
                command.AddParameter("@Supplier", product.Supplier);
                command.AddParameter("@DropoffLocation", product.DropoffLocation);
                //command.CommandText =
                //    $"INSERT INTO dbo.Products (PartNumber, PartName, Supplier, DropoffLocation) VALUES('{product.PartNumber}', '{product.PartName}', '{product.Supplier}', '{product.DropoffLocation}')";
                command.ExecuteNonQuery();
            }

            //todo: Get identity. Depends on the db engine.
        }

        public void Update(ProductDTO product)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ProductDTO> FindProducts(string firstName)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ProductDTO> FindBlocked()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Maps the data from the database (IDataRecrod record) to the a new ProductDTO Product.
        /// </summary>
        /// <param name="record">Holds the data from the database.</param>
        /// <param name="product">A new ProductDTO</param>
        public override void Map(IDataRecord record, ProductDTO product)
        {
            //user.FirstName = (string)record["FirstName"];
            //user.Age = (int)record["Age"];
            product.PartNumber = (string) record["PartNumber"];
            product.PartName = (string) record["PartName"];
            product.Supplier = (string) record["Supplier"];
            product.DropoffLocation = (string) record["DropoffLocation"];
        }

        public IEnumerable<ProductDTO> GetAllProducts()
        {
            using (var command = _context.CreateCommand())
            {
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "spLogistic_GetProducts";
                //command.CommandText =
                //    @"SELECT * FROM Products";
                return ToList(command);
            }
        }
    }
}