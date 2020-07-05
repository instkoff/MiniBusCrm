using System;
using System.Collections.Generic;

namespace MiniBusCrm.DataAccess.Entities
{
    public class DriverEntity : BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public string DoumentSerialNumber { get; set; }
        public string DocumentNumber { get; set; }
    }
}