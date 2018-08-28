using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrderProcess.Domain
{
    public class AdminViewModel
    {
        public IList<TicketAdmin> TicketAdminData { get; set; }
        public IList<ProductOnHandAdmin> ProductOnHandAdminData { get; set; }
    }
}