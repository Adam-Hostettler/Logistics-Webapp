using System;
using OrderProcess.Data;
using OrderProcess.Data.Interface;

namespace OrderProcess.Domain
{
    public class Clerk : UserDTO, IConsolidate, IAssignTicket
    {
        public Clerk()
        {
            UserName = "Ted";
        }

        public void AssingTicket()
        {
            //If assing to Storeroom or Delivery driver ?
            //Start Ticket.StartTime.
            //Set Ticket.Status to Prined
            throw new NotImplementedException();
        }

        public void Consolidate()
        {
            throw new NotImplementedException();
        }
    }
}