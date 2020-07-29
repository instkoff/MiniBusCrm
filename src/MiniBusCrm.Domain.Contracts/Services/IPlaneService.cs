using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MiniBusCrm.Domain.Contracts.Models;

namespace MiniBusCrm.Domain.Contracts.Services
{
    public interface IPlaneService
    {
        Task<Guid> Create(PlaneModel planeModel);
        List<PlaneModel> GetAll();
        Task<PlaneModel> Get(Guid id);
        Task<Guid> Update(PlaneModel planeModel);
        Task Delete(Guid id);
    }
}