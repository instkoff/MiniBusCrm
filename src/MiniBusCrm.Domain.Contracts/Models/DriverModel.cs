using System;

namespace MiniBusCrm.Domain.Contracts.Models
{
    public class DriverModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public string DoumentSerialNumber { get; set; }
        public string DocumentNumber { get; set; }
    }
}