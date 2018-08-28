using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using OrderProcess.Data.Extensions;
using OrderProcess.Data.Interface;
using OrderProcess.Domain;

namespace OrderProcess.Data.AdoNet
{
    public class TicketRepository : Repository<TicketDTO>, ITicketRepository
    {
        public TicketRepository(IAdoNetContext context) : base(context)
        {
        }

        public void Create(TicketDTO ticket)
        {
            using (var command = _context.CreateCommand())
            {
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "spLogistic_InsertTicket";
                command.AddParameter("@Status", ticket.Status);
                command.AddParameter("@StartTime", ticket.StartTime);
                command.AddParameter("@CompleteTime", ticket.CompleteTime);
                command.AddParameter("@LastModifiedBy", ticket.LastModifiedBy);
                command.AddParameter("@ProductNumber", ticket.ProductNumber);
                command.AddParameter("@Quantity", ticket.Quantity);
                command.AddParameter("@DropoffLocation", ticket.DropoffLocation);
                command.AddParameter("@ProductId", ticket.ProductId);
                //command.CommandText =
                //    $"INSERT INTO Tickets (Status, StartTime, CompleteTime, LastModifiedBy, ProductNumber, Quantity, DropoffLocation) VALUES({(int) Ticket.Status}, " +
                //    $"'{Ticket.StartTime.ToShortDateString()}','{Ticket.CompleteTime.ToShortDateString()}', '{Ticket.LastModifiedBy}', '{Ticket.ProductNumber}', " +
                //    $"{Ticket.Quantity}, '{Ticket.DropoffLocation}')";

                command.ExecuteNonQuery();
            }

            //todo: Get identity. Depends on the db engine.
        }

        public void Update(TicketDTO ticket)
        {
            using (var command = _context.CreateCommand())
            {
                if (ticket.AssignedToUserID == null)
                {
                    command.AddParameter("@assignedTo", DBNull.Value);
                }
                else
                {
                    command.AddParameter("@assignedTo", ticket.AssignedToUserID);
                }

                if (ticket.CompleteTime == null)
                {
                    command.AddParameter("@completeTime", DBNull.Value);
                }
                else
                {
                    command.AddParameter("@completeTime", ticket.CompleteTime);
                }

                command.AddParameter("@status", ticket.Status);
                command.AddParameter("@id", ticket.ID);
                command.AddParameter("@lastModified", ticket.LastModifiedBy);

                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "spLogistic_UpdateTicket";

                command.ExecuteNonQuery();
            }
        }

        public IEnumerable<TicketDTO> GetAssignedTickets(string userID)
        {
            var tickets = GetAllTickets();
            tickets = tickets.Where(item => item.AssignedToUserID == userID).ToList();
            return tickets;
        }

        public override void Map(IDataRecord record, TicketDTO ticket)
        {
            //user.FirstName = (string)record["FirstName"];
            //user.Age = (int)record["Age"];

            ticket.ID = (int) record["ID"];
            ticket.Status = (TicketStatus) record["Status"];
            ticket.StartTime = Convert.ToDateTime(record["StartTime"]);
            if (record["CompleteTime"] == DBNull.Value)
            {
                ticket.CompleteTime = null;
            }
            else
            {
                ticket.CompleteTime = Convert.ToDateTime(record["CompleteTime"]);
            }
            ticket.LastModifiedBy = (string) record["LastModifiedBy"];
            ticket.ProductNumber = (string) record["ProductNumber"];
            ticket.Quantity = (int) record["Quantity"];
            ticket.DropoffLocation = (string) record["DropoffLocation"];
            ticket.AssignedToUserID = record["UserID"] == DBNull.Value ? null : (string) record["UserID"];
            ticket.ProductId = (int) record["ProductId"];
        }

        /// <summary>
        /// Method retrieves all tickets.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<TicketDTO> GetAllTickets()
        {
            using (var command = _context.CreateCommand())
            {
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "spLogistic_GetTickets";
                return ToList(command);
            }
        }
        
        /// <summary>
        /// Gets the incomplete tickets for the Clerk/index.cshtml
        /// </summary>
        /// <returns></returns>
        public IEnumerable<TicketDTO> GetIncompleteTickets()
        {
            var allTickets = GetAllTickets(); //TODO: Create as stored proc.
            var incompleteTickets = allTickets.Where(item => item.CompleteTime == null).ToList();

            return incompleteTickets;
        }

        /// <summary>
        /// Gets all tickets that are assigned to the logged in user.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<TicketDTO> GetUsersTickets(string userId)
        {
            var allTickets = GetAllTickets(); //TODO: Create as stored proc.
            var usersTickets = allTickets.Where(item => item.AssignedToUserID == userId).ToList();

            return usersTickets;
        }

        /// <summary>
        /// Gets all tickets that have a status of picked(2).
        /// </summary>
        /// <returns></returns>
        public IEnumerable<TicketDTO> GetReviewTickets()
        {
            var allTickets = GetAllTickets(); //TODO: Create as stored proc.
            var reviewTickets = allTickets.Where(item => (int) item.Status == 2).ToList();

            return reviewTickets;
        }

        /// <summary>
        /// Gets all tickets that have a status of Inspected(3).
        /// </summary>
        /// <returns></returns>
        public IEnumerable<TicketDTO> GetDeliveryTickets()
        {
            var allTickets = GetAllTickets(); //TODO: Create as stored proc.
            var deliveryTickets = allTickets.Where(item => (int)item.Status == 3).ToList();

            return deliveryTickets;
        }

        public TicketDTO GetTicketById(int ticketId)
        {
            var allTickets = GetAllTickets(); //TODO: Create as stored proc.
            var requestedTicket = allTickets.Single(item => (int) item.ID == ticketId);

            return requestedTicket;
        }

        public IEnumerable<TicketDTO> GetbyDateTickets(string startDate, string endDate)
        {
            using (var command = _context.CreateCommand())
            {
                command.AddParameter("@startDate", Convert.ToDateTime(startDate));
                command.AddParameter("@endDate", Convert.ToDateTime(endDate));
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "spLogistic_GetTicketsbyDate";
                return ToList(command);
            }
        }

        public IEnumerable<TicketDTO> GetTicketsTodayByStatus()
        {
            using (var command = _context.CreateCommand())
            {
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "spLogistic_GetTicketsTodaybyStatus";
                return ToList(command);
            }
        }
    }
}