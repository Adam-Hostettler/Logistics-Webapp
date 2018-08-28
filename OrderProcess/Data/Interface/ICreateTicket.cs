using OrderProcess.Domain;

namespace OrderProcess.Data.Interface
{
    public interface ICreateTicket
    {
        TicketDTO CreateTicket(ProductDTO product, int quantity);
    }
}