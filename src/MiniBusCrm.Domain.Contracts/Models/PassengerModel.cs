﻿using System;
using System.Collections.Generic;

namespace MiniBusCrm.Domain.Contracts.Models
{
    public class PassengerModel : BaseModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public string PhoneNumber { get; set; }
        public List<TicketModel> BusTickets { get; set; }
    }
}