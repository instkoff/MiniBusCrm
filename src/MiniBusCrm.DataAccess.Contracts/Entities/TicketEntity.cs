using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiniBusCrm.DataAccess.Contracts.Entities
{
    public class TicketEntity : BaseEntity
    {
        public PassengerEntity Passenger { get; set; }
        public string Seat { get; set; }

        [Column(TypeName = "money")] public decimal Price { get; set; }

        public bool IsBaggage { get; set; }
        public bool IsPaid { get; set; }
        public DateTime? PaidDate { get; set; }
        public RouteEntity Route { get; set; }
        public PlaneEntity Plane { get; set; }
    }
}