using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrderProcess.Data
{
    public class ProductDTO : BaseDTO
    {
        public string PartNumber { get; set; }
        public string PartName { get; set; }
        public string Supplier { get; set; }
        public string DropoffLocation { get; set; } //Might need a revisit.
    }
}