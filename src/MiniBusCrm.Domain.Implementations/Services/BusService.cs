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
    public class BusService : IBusService
    {
        private readonly IDbRepository _dbRepository;
        private readonly IMapper _mapper;

        public BusService(IDbRepository dbRepository, IMapper mapper)
        {
            _dbRepository = dbRepository;
            _mapper = mapper;
        }

        public async Task<Guid> Create(BusModel busModel)
        {
            var busEntity = _mapper.Map<BusEntity>(busModel);
            await _dbRepository.Add(busEntity);
            await _dbRepository.SaveChangesAsync();
            return busEntity.Id;
        }

        public List<BusModel> GetAll()
        {
            var busCollection = _dbRepository.GetAll<BusEntity>().ToList();
            var busModels = _mapper.Map<List<BusModel>>(busCollection);
            return busModels;
        }

        public async Task<BusModel> Get(Guid id)
        {
            var busEntity = await _dbRepository.Get<BusEntity>(x => x.Id == id).FirstOrDefaultAsync();
            var busModel = _mapper.Map<BusModel>(busEntity);
            return busModel;
        }

        public async Task<Guid> Update(BusModel busModel)
        {
            var busEntity = _mapper.Map<BusEntity>(busModel);
            await _dbRepository.Update(busEntity);
            await _dbRepository.SaveChangesAsync();
            return busEntity.Id;
        }

        public async Task Delete(Guid id)
        {
            await _dbRepository.Delete<BusEntity>(id);
            await _dbRepository.SaveChangesAsync();
        }

    }
}
