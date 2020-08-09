using System;

namespace MiniBusCrm.Domain.Contracts.Models
{
    public class BusDriverModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public string DocumentSerialNumber { get; set; }
        public string DocumentNumber { get; set; }
        public string PhoneNumber { get; set; }
    }
}