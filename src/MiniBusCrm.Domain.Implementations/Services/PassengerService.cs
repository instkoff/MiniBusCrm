using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MiniBusCrm.DataAccess.Contracts;
using MiniBusCrm.DataAccess.Contracts.Entities;
using MiniBusCrm.Domain.Contracts.Models;
using MiniBusCrm.Domain.Contracts.Services;

namespace MiniBusCrm.Domain.Implementations.Services
{
    public class PassengerService : IPassengerService
    {
        private readonly IDbRepository _dbRepository;
        private readonly IMapper _mapper;

        public PassengerService(IDbRepository dbRepository, IMapper mapper)
        {
            _dbRepository = dbRepository;
            _mapper = mapper;
        }

        public List<PassengerModel> GetAll()
        {
            var passengersCollection = _dbRepository.Get<PassengerEntity>()
                .Include(t => t.BusTickets)
                .ThenInclude(r=>r.Route)
                .Include(t=>t.BusTickets)
                .ThenInclude(p=>p.Plane)
                .ToList();
            var passengers = _mapper.Map<List<PassengerModel>>(passengersCollection);
            return passengers;
        }

    }
}
