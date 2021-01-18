using System;

namespace MiniBusCrm.Domain.Contracts.Models
{
    public class RouteModel : BaseModel
    {
        public string RouteName { get; set; }
        public string ArrivalCity { get; set; }
        public string DepartureCity { get; set; }
        public Guid DriverId { get; set; }
        public Guid BusId { get; set; }
    }
}