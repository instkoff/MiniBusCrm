using System.Collections.Generic;
using MiniBusCrm.Domain.Contracts.Models;

namespace MiniBusCrm.Domain.Contracts.Services
{
    public interface IPassengerService
    {
        List<PassengerModel> GetAll();
    }
}