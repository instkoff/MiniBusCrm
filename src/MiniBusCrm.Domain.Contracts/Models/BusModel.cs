using System;

namespace MiniBusCrm.Domain.Contracts.Models
{
    public class BusModel : BaseModel
    {
        public string Model { get; set; }
        public string Number { get; set; }
    }
}