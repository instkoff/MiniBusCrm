using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MiniBusCrm.Domain.Contracts.Models;

namespace MiniBusCrm.Domain.Contracts.Services
{
    public interface IBusService
    {
        Task<Guid> Create(BusModel busModel);
        List<BusModel> GetAll();
        Task<BusModel> Get(Guid id);
        Task<Guid> Update(BusModel busModel);
        Task Delete(Guid id);
    }
}