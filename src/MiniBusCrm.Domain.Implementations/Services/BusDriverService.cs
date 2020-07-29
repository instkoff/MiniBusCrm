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
    public class BusDriverService : IBusDriverService
    {
        private readonly IDbRepository _dbRepository;
        private readonly IMapper _mapper;

        public BusDriverService(IDbRepository dbRepository, IMapper mapper)
        {
            _dbRepository = dbRepository;
            _mapper = mapper;
        }

        public async Task<Guid> Create(BusDriverModel busDriverModel)
        {
            var driverEntity = _mapper.Map<BusDriverEntity>(busDriverModel);
            await _dbRepository.Add(driverEntity);
            await _dbRepository.SaveChangesAsync();
            return driverEntity.Id;
        }

        public List<BusDriverModel> GetAll()
        {
            var driversCollection = _dbRepository.GetAll<BusDriverEntity>().ToList();
            var driverModels = _mapper.Map<List<BusDriverModel>>(driversCollection);
            return driverModels;
        }

        public async Task<BusDriverModel> Get(Guid id)
        {
            var driverEntity = await _dbRepository.Get<BusDriverEntity>(x => x.Id == id).FirstOrDefaultAsync();
            var driverModel = _mapper.Map<BusDriverModel>(driverEntity);
            return driverModel;
        }

        public async Task<Guid> Update(BusDriverModel busDriverModel)
        {
            var driverEntity = _mapper.Map<BusDriverEntity>(busDriverModel);
            await _dbRepository.Update(driverEntity);
            await _dbRepository.SaveChangesAsync();
            return driverEntity.Id;
        }

        public async Task Delete(Guid id)
        {
            await _dbRepository.Delete<BusDriverEntity>(id);
            await _dbRepository.SaveChangesAsync();
        }
    }
}
