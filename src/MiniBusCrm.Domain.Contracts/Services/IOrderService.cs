using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MiniBusCrm.Domain.Contracts.Models;

namespace MiniBusCrm.Domain.Contracts.Services
{
    public interface IOrderService
    {
        Task<Guid> Create(OrderModel orderModel);
        List<OrderModel> GetAll();
        Task<OrderModel> Get(Guid id);
        Task<Guid> Update(OrderModel orderModel);
        Task Delete(Guid id);
    }
}