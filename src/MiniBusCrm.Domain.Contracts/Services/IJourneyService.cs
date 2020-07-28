using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MiniBusCrm.Domain.Contracts.Models;

namespace MiniBusCrm.Domain.Contracts.Services
{
    public interface IJourneyService
    {
        Task<Guid> Create(JourneyModel journeyModel);
        List<JourneyModel> GetAll();
        Task<JourneyModel> Get(Guid id);
        Task<Guid> Update(JourneyModel journeyModel);
        Task Delete(Guid id);
    }
}