using System;

namespace MiniBusCrm.DataAccess.Entities
{
    public class RouteEntity : BaseEntity
    {
        public string RouteName { get; set; }
        public string ArrivalCity { get; set; }
        public string DepartureCity { get; set; }
        public DriverEntity Driver { get; set; }
        public BusEntity Bus { get; set; }
    }
}