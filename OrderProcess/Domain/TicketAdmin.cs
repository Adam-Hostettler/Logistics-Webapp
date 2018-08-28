using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrderProcess.Domain
{
    public class TicketAdmin
    {
        public int TicketStatus { get; set; }
        public string ProductNumber { get; set; }
        public bool IsCompleted { get; set; }
    }
}