﻿namespace MiniBusCrm.DataAccess.Contracts.Entities
{
    public class BusDriverEntity : BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public string DoumentSerialNumber { get; set; }
        public string DocumentNumber { get; set; }
    }
}