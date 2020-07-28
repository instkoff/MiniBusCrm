using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MiniBusCrm.Domain.Contracts.Models;

namespace MiniBusCrm.Domain.Implementations.Services
{
    public interface ITicketService
    {
        Task<Guid> Create(TicketModel ticketModel);
        List<TicketModel> GetAll();
        Task<TicketModel> Get(Guid id);
        Task<Guid> Update(TicketModel ticketModel);
        Task Delete(Guid id);
    }
}