using System;
using System.Collections.Generic;

namespace MiniBusCrm.DataAccess.Contracts.Entities
{
    public class OrderEntity : BaseEntity
    {
        public string OrderName { get; set; }
        public DateTime DepartureDate { get; set; }
        public RouteEntity Route { get; set; }
        public ICollection<TicketEntity> BusTickets { get; set; }

    }
}
