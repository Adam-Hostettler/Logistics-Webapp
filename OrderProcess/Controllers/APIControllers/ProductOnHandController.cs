using System.Collections.Generic;
using System.Web.Http;
using OrderProcess.Data;
using OrderProcess.Data.Interface;

namespace OrderProcess.Controllers.APIControllers
{
    public class ProductOnHandController : ApiController
    {
        private readonly IProductOnHandRepository productOnHandRepository;

        public ProductOnHandController(IProductOnHandRepository pohr)
        {
            productOnHandRepository = pohr;
        }

        // GET: api/ProductOnHand
        public IHttpActionResult Get()
        {
            IEnumerable<ProductOnHandDTO> productOnHand = new List<ProductOnHandDTO>();

            productOnHand = productOnHandRepository.GetAllProductOnHand();

            return Ok(productOnHand);
        }
    }
}
