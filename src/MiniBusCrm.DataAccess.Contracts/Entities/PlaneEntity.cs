using System;
using System.Collections.Generic;

namespace MiniBusCrm.DataAccess.Contracts.Entities
{
    public class PlaneEntity : BaseEntity
    {
        public string PlaneName { get; set; }
        public DateTime DepartureDate { get; set; }
        public RouteEntity Route { get; set; }
        public ICollection<TicketEntity> BusTickets { get; set; }
    }
}