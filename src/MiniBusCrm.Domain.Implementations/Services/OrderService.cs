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
    public class OrderService : IOrderService
    {
        private readonly IDbRepository _dbRepository;
        private readonly IMapper _mapper;

        public OrderService(IDbRepository dbRepository, IMapper mapper)
        {
            _dbRepository = dbRepository;
            _mapper = mapper;
        }

        public async Task<Guid> Create(OrderModel orderModel)
        {
            var orderEntity = _mapper.Map<OrderEntity>(orderModel);
            orderEntity.Route = _dbRepository.Get<RouteEntity>(x=>x.Id == orderModel.Route.Id).FirstOrDefault();
            await _dbRepository.Add(orderEntity);
            await _dbRepository.SaveChangesAsync();
            return orderEntity.Id;
        }
        public List<OrderModel> GetAll()
        {
            var orderCollection = _dbRepository.GetAll<OrderEntity>()
                .Include(r=>r.Route)
                .Include(t=>t.BusTickets)
                .ToList();
            var orderModels = _mapper.Map<List<OrderModel>>(orderCollection);
            return orderModels;
        }
        public async Task<OrderModel> Get(Guid id)
        {
            var orderEntity = await _dbRepository.Get<OrderEntity>(x => x.Id == id)
                .Include(r=>r.Route)
                .Include(t => t.BusTickets)
                .FirstOrDefaultAsync();
            var orderModel = _mapper.Map<OrderModel>(orderEntity);
            return orderModel;
        }

        public async Task<Guid> Update(OrderModel orderModel)
        {
            var orderEntity = _mapper.Map<OrderEntity>(orderModel);
            await _dbRepository.Update(orderEntity);
            await _dbRepository.SaveChangesAsync();
            return orderEntity.Id;
        }
        public async Task Delete(Guid id)
        {
            await _dbRepository.Delete<OrderEntity>(id);
            await _dbRepository.SaveChangesAsync();
        }
    }
}
