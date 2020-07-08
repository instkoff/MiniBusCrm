using System;

namespace MiniBusCrm.Domain.Contracts.Models
{
    public class TicketModel
    {
        public Guid Id { get; set; }
        public DateTime CreateDate { get; set; }
        public PassangerModel Passenger { get; set; }
        public string Seat { get; set; }
        public decimal Price { get; set; }
        public bool IsBaggage { get; set; }
        public bool IsPaid { get; set; }
        public DateTime? PaidDate { get; set; }
        public RouteModel Route { get; set; }
        public OrderModel Order { get; set; }
    }
}