using System;
using OrderProcess.Data;
using OrderProcess.Data.Interface;

namespace OrderProcess.Domain
{
    public class ExteralUserDto : UserDTO, ICreateTicket
    {
        public TicketDTO CreateTicket(ProductDTO product, int quantity)
        {
            throw new NotImplementedException();
        }
    }
}