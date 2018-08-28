using OrderProcess.Data;

namespace OrderProcess.Domain
{
    public class ProductRequestItem
    {
        public int Quantity { get; set; }
        public ProductDTO Product { get; set; }
    }
}