using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MiniBusCrm.DataAccess.Contracts;
using MiniBusCrm.DataAccess.Contracts.Entities;
using MiniBusCrm.Domain.Contracts.Models;
using MiniBusCrm.Domain.Contracts.Services;

namespace MiniBusCrm.Domain.Implementations.Services
{
    public class JourneyService : IJourneyService
    {
        private readonly IDbRepository _dbRepository;
        private readonly IMapper _mapper;

        public JourneyService(IDbRepository dbRepository, IMapper mapper)
        {
            _dbRepository = dbRepository;
            _mapper = mapper;
        }

        public async Task<Guid> Create(JourneyModel journeyModel)
        {
            var orderEntity = _mapper.Map<JourneyEntity>(journeyModel);
            orderEntity.Route = _dbRepository.Get<RouteEntity>(r => r.Id == journeyModel.RouteId).FirstOrDefault();
            await _dbRepository.Add(orderEntity);
            await _dbRepository.SaveChangesAsync();
            return orderEntity.Id;
        }

        public List<JourneyModel> GetAll()
        {
            var orderCollection = _dbRepository.GetAll<JourneyEntity>()
                .Include(r => r.Route)
                .Include(t => t.BusTickets)
                .ToList();
            var orderModels = _mapper.Map<List<JourneyModel>>(orderCollection);
            return orderModels;
        }

        public async Task<JourneyModel> Get(Guid id)
        {
            var orderEntity = await _dbRepository.Get<JourneyEntity>(x => x.Id == id)
                .Include(r => r.Route)
                .Include(t => t.BusTickets)
                .FirstOrDefaultAsync();
            var orderModel = _mapper.Map<JourneyModel>(orderEntity);
            return orderModel;
        }

        public async Task<Guid> Update(JourneyModel journeyModel)
        {
            var orderEntity = _mapper.Map<JourneyEntity>(journeyModel);
            await _dbRepository.Update(orderEntity);
            await _dbRepository.SaveChangesAsync();
            return orderEntity.Id;
        }

        public async Task Delete(Guid id)
        {
            await _dbRepository.Delete<JourneyEntity>(id);
            await _dbRepository.SaveChangesAsync();
        }
    }
}