namespace OrderProcess.Data
{
    public class ProductOnHandDTO : BaseDTO
    {
        public ProductDTO Product { get; set; }
        public int Quantity { get; set; }
    }
}