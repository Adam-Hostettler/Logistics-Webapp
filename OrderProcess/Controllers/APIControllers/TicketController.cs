using System;
using System.Collections.Generic;
using System.Web.Http;
using OrderProcess.Data;
using OrderProcess.Data.AdoNet;
using OrderProcess.Data.Interface;
using OrderProcess.Domain;

namespace OrderProcess.Controllers.APIControllers
{
    public class TicketController : ApiController
    {
        private readonly ITicketRepository ticketRepository;
        private readonly IEFUserIdentityRepository userRepository;
        private readonly IProductOnHandRepository productOnHandRepository;

        public TicketController(ITicketRepository ticketrepo, IEFUserIdentityRepository userrepo, IProductOnHandRepository productrepo)
        {
            ticketRepository = ticketrepo;
            userRepository = userrepo;
            productOnHandRepository = productrepo;
        }

        // GET: api/Ticket
        public IHttpActionResult Get()
        {
            return Ok(ticketRepository.GetIncompleteTickets());
        }

        // GET: api/Ticket/5
        public IHttpActionResult Get(string id)
        {
            return Ok(ticketRepository.GetAssignedTickets(id));
        }

        [HttpGet]
        [Route("tickets/{userId}")]
        public IHttpActionResult GetUsersTickets(string userId)
        {
            return Ok(ticketRepository.GetUsersTickets(userId));
        }

        [HttpGet]
        [Route("tickets/review")]
        public IHttpActionResult GetReviewTickets()
        {
            return Ok(ticketRepository.GetReviewTickets());
        }

        [HttpGet]
        [Route("tickets/delivery")]
        public IHttpActionResult GetDeliveryTickets()
        {
            return Ok(ticketRepository.GetDeliveryTickets());
        }

        [HttpGet]
        [Route("tickets/byDate/{startDate}/{endDate}")]
        public IHttpActionResult GetTicketbyDate(string startDate, string endDate)
        {
            TicketChartBuilder ticketChartBuilder = new TicketChartBuilder();
            var ticketsWithinDate = ticketRepository.GetbyDateTickets(startDate, endDate);
            var sortedTickets = ticketChartBuilder.BuildCompletedTicketsByDate(ticketsWithinDate);

            return Ok(sortedTickets);
        }


        [HttpGet]
        [Route("tickets/duration/{startDate}/{endDate}")]
        public IHttpActionResult GetTicketDuration(string startDate, string endDate)
        {
            var ticketChartBuilder = new TicketChartBuilder();
            var ticketsWithinDate = ticketRepository.GetbyDateTickets(startDate, endDate);
            var sortedTickets = ticketChartBuilder.BuildTicketDurationByDate(ticketsWithinDate);

            return Ok(sortedTickets);
        }

        [HttpGet]
        [Route("tickets/status")]
        public IHttpActionResult GetTicketTodayByStatus()
        {
            var ticketChartBuilder = new TicketChartBuilder();
            var ticketsToday = ticketRepository.GetTicketsTodayByStatus();
            var sortedTickets = ticketChartBuilder.BuildTicketTodaybyStatus(ticketsToday);

            return Ok(sortedTickets);
        }

        // POST: api/Ticket
        public void Post([FromBody] ProductRequestItem item)
        {
            var ticket = new TicketDTO
            {
                ProductNumber = item.Product.PartNumber,
                StartTime = DateTime.Now,
                LastModifiedBy = Environment.UserName,
                Quantity = item.Quantity,
                Status = TicketStatus.Printed,
                DropoffLocation = item.Product.DropoffLocation,
                ProductId = item.Product.ID
            };

            ticketRepository.Create(ticket);
        }

        // PUT: api/Ticket/5
        public void Put(int id, [FromBody] string ticketAssigned)
        {
            TicketDTO ticket = new TicketDTO();
            ticket.ID = id;
            ticket.Status = TicketStatus.Printed;
            ticket.LastModifiedBy = Environment.UserName;
            ticket.AssignedToUserID = ticketAssigned;
            ticketRepository.Update(ticket);
        }

        [HttpPut]
        [Route("tickets/{id}")]
        public IHttpActionResult PutTicket(int id)
        {
            TicketDTO ticket = new TicketDTO();
            ticket.ID = id;
            ticket.Status = TicketStatus.Printed;
            ticket.LastModifiedBy = Environment.UserName;
            ticket.AssignedToUserID = null;
            ticketRepository.Update(ticket);
            return Ok();
        }

        [HttpPut]
        [Route("tickets/status/{id}")]
        public IHttpActionResult PutTicketStatus(int id)
        {
            TicketDTO ticket = new TicketDTO();
            ticket.ID = id;
            ticket.AssignedToUserID = userRepository.GetClerk();
            ticket.Status = TicketStatus.Picked;
            ticket.LastModifiedBy = Environment.UserName;
            ticketRepository.Update(ticket);
            return Ok();
        }

        [HttpPut]
        [Route("tickets/reivewed/{id}")]
        public IHttpActionResult PutReviewStatus(int id)
        {
            TicketDTO ticket = new TicketDTO();
            ticket.ID = id;
            ticket.AssignedToUserID = userRepository.GetClerk();
            ticket.Status = TicketStatus.Inspected;
            ticket.LastModifiedBy = Environment.UserName;
            ticketRepository.Update(ticket);
            return Ok();
        }

        [HttpPut]
        [Route("tickets/delivered/{ticketId}")]
        public IHttpActionResult PutDeliveredStatus(int ticketId)
        {
            TicketDTO ticket = ticketRepository.GetTicketById(ticketId);
            ticket.ID = ticketId;
            ticket.Status = TicketStatus.Delivered;
            ticket.LastModifiedBy = Environment.UserName;
            ticket.CompleteTime = DateTime.Now; 
            ticketRepository.Update(ticket);
            productOnHandRepository.Update(ticket.ProductId, ticket.Quantity);
            return Ok();
        }
    }
}