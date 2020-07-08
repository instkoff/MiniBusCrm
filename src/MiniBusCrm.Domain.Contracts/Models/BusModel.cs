using System;

namespace MiniBusCrm.Domain.Contracts.Models
{
    public class BusModel
    {
        public Guid Id { get; set; }
        public string Model { get; set; }
        public string Number { get; set; }
    }
}