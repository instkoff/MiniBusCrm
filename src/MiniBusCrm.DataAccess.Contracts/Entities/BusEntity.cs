using System;

namespace MiniBusCrm.DataAccess.Entities
{
    public class BusEntity : BaseEntity
    {
        public string BusModel { get; set; }
        public string BusNumber { get; set; }
    }
}