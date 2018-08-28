using System.Collections.Generic;
using System.Data;
using OrderProcess.Data.AdoNet;

namespace OrderProcess.Data.Interface
{
    public interface ITicketRepository
    {
        void Create(TicketDTO Ticket);
        void Update(TicketDTO Ticket);
        IEnumerable<TicketDTO> GetAssignedTickets(string UserID);
        void Map(IDataRecord record, TicketDTO Ticket);
        AdoNetContext Context { get; }
        IEnumerable<TicketDTO> ToList(IDbCommand command);
        IEnumerable<TicketDTO> GetAllTickets();
        IEnumerable<TicketDTO> GetIncompleteTickets();
        IEnumerable<TicketDTO> GetUsersTickets(string userId);
        IEnumerable<TicketDTO> GetReviewTickets();
        IEnumerable<TicketDTO> GetDeliveryTickets();
        TicketDTO GetTicketById(int ticketId);
        IEnumerable<TicketDTO> GetbyDateTickets(string startDate, string endDate);
        IEnumerable<TicketDTO> GetTicketsTodayByStatus();
    }
}