using System.Collections.Generic;
using System.Web.Http;
using OrderProcess.Data;
using OrderProcess.Data.Interface;

namespace OrderProcess.Controllers.APIControllers
{
    public class ProductController : ApiController
    {
        private readonly IProductRepository productRepository;

        public ProductController(IProductRepository repo)
        {            
            productRepository = repo;
        }

        // GET: api/Product
        public IHttpActionResult Get()
        {
            IEnumerable<ProductDTO> products = new List<ProductDTO>();

            products = productRepository.GetAllProducts();

            return Ok(products);
        }

        // POST: api/Product
        public void Post([FromBody]ProductDTO item)
        {
            productRepository.Create(item);
        }
    }
}
