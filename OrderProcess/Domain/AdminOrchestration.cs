using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OrderProcess.Data.AdoNet;
using OrderProcess.Data.Interface;

namespace OrderProcess.Domain
{
    public class AdminOrchestration: IAdminOrchestration
    {
        private readonly ITicketRepository ticketRepository;
        private readonly IProductOnHandRepository productOnHandRepository;

        public AdminOrchestration(ITicketRepository ticketRepo, IProductOnHandRepository productOnHandRepo)
        {
            ticketRepository = ticketRepo;
            productOnHandRepository = productOnHandRepo;

        }

        /// <summary>
        /// Calls the TicketRepository.GetAllTickets and ProductOnHandRepository.GetAllProductOnHand. Combines data from each to generate the Admin's view.
        /// </summary>
        /// <returns>AdminViewModel</returns>
        public AdminViewModel CollectAdminTicketandProductData()
        {
            AdminViewModel adminViewModel = new AdminViewModel();
            IList<TicketAdmin> listTicketAdmin = new List<TicketAdmin>();
            IList<ProductOnHandAdmin> listProductOnHandAdmin = new List<ProductOnHandAdmin>();

            var tickets = ticketRepository.GetAllTickets();
            var products = productOnHandRepository.GetAllProductOnHand();

            foreach (var ticket in tickets)
            {
                TicketAdmin ticketAdmin = new TicketAdmin();
                ticketAdmin.TicketStatus = (int) ticket.Status;
                ticketAdmin.ProductNumber = ticket.ProductNumber;

                if (ticket.CompleteTime == null)
                {
                    ticketAdmin.IsCompleted = false;
                }
                else
                {
                    ticketAdmin.IsCompleted = true;
                }

                listTicketAdmin.Add(ticketAdmin);
            }
            adminViewModel.TicketAdminData = listTicketAdmin;

            foreach (var product in products)
            {
                ProductOnHandAdmin productOnHandAdmin = new ProductOnHandAdmin();
                productOnHandAdmin.PartNumber = product.Product.PartNumber;
                productOnHandAdmin.Quantity = product.Quantity;
                listProductOnHandAdmin.Add(productOnHandAdmin);
            }
            adminViewModel.ProductOnHandAdminData = listProductOnHandAdmin;

            return adminViewModel;
        }
    }
}