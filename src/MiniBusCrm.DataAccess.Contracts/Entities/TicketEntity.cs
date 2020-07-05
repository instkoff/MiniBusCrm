using System;

namespace MiniBusCrm.DataAccess.Entities
{
    public class TicketEntity : BaseEntity
    {
        public PassangerEntity Passenger { get; set; }
        public string Seat { get; set; }
        public decimal Price { get; set; }
        public bool IsBaggage { get; set; }
        public bool IsPaid { get; set; }
        public DateTime? PaidDate { get; set; }
        public RouteEntity Route { get; set; }
        public OrderEntity Order { get; set; }

    }
}