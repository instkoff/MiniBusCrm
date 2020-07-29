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
    public class PlaneService : IPlaneService
    {
        private readonly IDbRepository _dbRepository;
        private readonly IMapper _mapper;

        public PlaneService(IDbRepository dbRepository, IMapper mapper)
        {
            _dbRepository = dbRepository;
            _mapper = mapper;
        }

        public async Task<Guid> Create(PlaneModel planeModel)
        {
            var orderEntity = _mapper.Map<PlaneEntity>(planeModel);
            orderEntity.Route = await _dbRepository.Get<RouteEntity>(r => r.Id == planeModel.RouteId).FirstOrDefaultAsync();
            await _dbRepository.Add(orderEntity);
            await _dbRepository.SaveChangesAsync();
            return orderEntity.Id;
        }

        public List<PlaneModel> GetAll()
        {
            var planeCollection = _dbRepository.GetAll<PlaneEntity>()
                .Include(r => r.Route)
                .Include(t=>t.BusTickets).ThenInclude(p=>p.Passenger)
                .ToList();
            var planeModels = _mapper.Map<List<PlaneModel>>(planeCollection);
            return planeModels;
        }

        public async Task<PlaneModel> Get(Guid id)
        {
            var planeEntity = await _dbRepository.Get<PlaneEntity>(x => x.Id == id)
                .Include(r => r.Route)
                .Include(t => t.BusTickets)
                .FirstOrDefaultAsync();
            var orderModel = _mapper.Map<PlaneModel>(planeEntity);
            return orderModel;
        }

        public async Task<Guid> Update(PlaneModel planeModel)
        {
            var orderEntity = _mapper.Map<PlaneEntity>(planeModel);
            await _dbRepository.Update(orderEntity);
            await _dbRepository.SaveChangesAsync();
            return orderEntity.Id;
        }

        public async Task Delete(Guid id)
        {
            await _dbRepository.Delete<PlaneEntity>(id);
            await _dbRepository.SaveChangesAsync();
        }
    }
}