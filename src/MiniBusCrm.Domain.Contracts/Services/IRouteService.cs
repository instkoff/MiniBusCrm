using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MiniBusCrm.Domain.Contracts.Models;

namespace MiniBusCrm.Domain.Contracts.Services
{
    public interface IRouteService
    {
        Task<Guid> Create(RouteModel routeModel);
        List<RouteModel> GetAll();
        Task<RouteModel> Get(Guid id);
        Task<Guid> Update(RouteModel routeModel);
        Task Delete(Guid id);
    }
}