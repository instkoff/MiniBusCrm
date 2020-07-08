using System;
using System.Collections.Generic;

namespace MiniBusCrm.Domain.Contracts.Models
{
    public class OrderModel
    {
        public Guid Id { get; set; }
        public DateTime CreateDate { get; set; }
        public string OrderName { get; set; }
        public DateTime DepartureDate { get; set; }
        public RouteModel RouteEntity { get; set; }
        public List<TicketModel> BusTickets { get; set; }
    }
}
