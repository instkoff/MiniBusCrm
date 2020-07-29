using System;
using System.Collections.Generic;

namespace MiniBusCrm.Domain.Contracts.Models
{
    public class PlaneModel
    {
        public Guid Id { get; set; }
        public DateTime CreateDate { get; set; }
        public string PlaneName { get; set; }
        public DateTime DepartureDate { get; set; }
        public Guid RouteId { get; set; }
        public List<TicketModel> BusTickets { get; set; }
    }
}