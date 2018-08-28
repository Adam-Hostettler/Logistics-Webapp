using System;
using OrderProcess.Domain;

namespace OrderProcess.Data
{
    public class TicketDTO : BaseDTO
    {
        public TicketStatus Status { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime? CompleteTime { get; set; }
        public string LastModifiedBy { get; set; }
        public string ProductNumber { get; set; }
        public int Quantity { get; set; }
        public string DropoffLocation { get; set; }
        public string AssignedToUserID { get; set; }
        public int ProductId { get; set; }
    }
}