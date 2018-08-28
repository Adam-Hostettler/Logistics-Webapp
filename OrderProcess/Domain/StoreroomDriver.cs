using System;
using OrderProcess.Data;
using OrderProcess.Data.Interface;

namespace OrderProcess.Domain
{
    public class StoreroomDriver : UserDTO, IAssignTicket
    {
        public StoreroomDriver()
        {
            UserName = "Bob";
        }

        public void AssingTicket()
        {
            //Set Ticket.Status to Picked.
            throw new NotImplementedException();
        }
    }
}