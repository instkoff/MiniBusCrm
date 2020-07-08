using System.Collections.Generic;

namespace MiniBusCrm.DataAccess.Contracts.Entities
{
    public class PassangerEntity : BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public string PhoneNumber { get; set; }
        public ICollection<TicketEntity> BusTickets { get; set; }
    }
}