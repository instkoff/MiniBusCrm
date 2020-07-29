using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MiniBusCrm.Domain.Contracts.Models;

namespace MiniBusCrm.Domain.Contracts.Services
{
    public interface IBusDriverService
    {
        Task<Guid> Create(BusDriverModel busDriverModel);
        List<BusDriverModel> GetAll();
        Task<BusDriverModel> Get(Guid id);
        Task<Guid> Update(BusDriverModel busDriverModel);
        Task Delete(Guid id);
    }
}