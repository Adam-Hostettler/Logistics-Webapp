using System.Collections.Generic;
using OrderProcess.Data;

namespace OrderProcess.Domain
{
    public class Location
    {
        public int AisleNumber { get; set; }
        public string Column { get; set; }
        public int Row { get; set; }
        public List<ProductOnHandDTO> Products { get; set; }
    }
}