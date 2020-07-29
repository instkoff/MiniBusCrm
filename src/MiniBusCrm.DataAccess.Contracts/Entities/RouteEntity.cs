namespace MiniBusCrm.DataAccess.Contracts.Entities
{
    public class RouteEntity : BaseEntity
    {
        public string RouteName { get; set; }
        public string ArrivalCity { get; set; }
        public string DepartureCity { get; set; }
        public BusDriverEntity BusDriver { get; set; }
        public BusEntity Bus { get; set; }
    }
}