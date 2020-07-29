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
    public class RouteService : IRouteService
    {
        private readonly IDbRepository _dbRepository;
        private readonly IMapper _mapper;

        public RouteService(IDbRepository dbRepository, IMapper mapper)
        {
            _dbRepository = dbRepository;
            _mapper = mapper;
        }

        public async Task<Guid> Create(RouteModel routeModel)
        {
            var routeEntity = _mapper.Map<RouteEntity>(routeModel);
            routeEntity.Bus = await _dbRepository.Get<BusEntity>(b => b.Id == routeModel.BusId).FirstOrDefaultAsync();
            routeEntity.BusDriver = await _dbRepository.Get<BusDriverEntity>(d => d.Id == routeModel.DriverId)
                .FirstOrDefaultAsync();
            await _dbRepository.Add(routeEntity);
            await _dbRepository.SaveChangesAsync();
            return routeEntity.Id;
        }

        public List<RouteModel> GetAll()
        {
            var routes = _dbRepository.Get<RouteEntity>()
                .Include(b => b.Bus)
                .Include(d => d.BusDriver).ToList();
            var routeModels = _mapper.Map<List<RouteModel>>(routes);
            return routeModels;
        }

        public async Task<RouteModel> Get(Guid id)
        {
            var routeEntity = await _dbRepository.Get<RouteEntity>(x => x.Id == id)
                .Include(b => b.Bus)
                .Include(d => d.BusDriver)
                .FirstOrDefaultAsync();
            var routeModel = _mapper.Map<RouteModel>(routeEntity);
            return routeModel;
        }

        public async Task<Guid> Update(RouteModel routeModel)
        {
            var routeEntity = _mapper.Map<RouteEntity>(routeModel);
            await _dbRepository.Update(routeEntity);
            await _dbRepository.SaveChangesAsync();
            return routeEntity.Id;
        }

        public async Task Delete(Guid id)
        {
            await _dbRepository.Delete<PlaneEntity>(id);
            await _dbRepository.SaveChangesAsync();
        }
    }
}