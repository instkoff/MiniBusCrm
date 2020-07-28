using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MiniBusCrm.DataAccess.Contracts;
using MiniBusCrm.DataAccess.Contracts.Entities;
using MiniBusCrm.Domain.Contracts.Models;

namespace MiniBusCrm.Domain.Implementations.Services
{
    public class TicketService : ITicketService
    {
        private readonly IDbRepository _dbRepository;
        private readonly IMapper _mapper;

        public TicketService(IDbRepository dbRepository, IMapper mapper)
        {
            _dbRepository = dbRepository;
            _mapper = mapper;
        }

        public async Task<Guid> Create(TicketModel ticketModel)
        {
            var ticketEntity = _mapper.Map<TicketEntity>(ticketModel);
            await _dbRepository.Add(ticketEntity);
            await _dbRepository.SaveChangesAsync();
            return ticketEntity.Id;
        }

        public List<TicketModel> GetAll()
        {
            var tickets = _dbRepository.Get<TicketEntity>()
                .Include(o => o.Journey)
                .Include(p => p.Passenger)
                .Include(r => r.Route).ToList();
            var ticketModels = _mapper.Map<List<TicketModel>>(tickets);
            return ticketModels;
        }

        public async Task<TicketModel> Get(Guid id)
        {
            var ticketEntity = await _dbRepository.Get<TicketEntity>(x => x.Id == id)
                .Include(o => o.Journey)
                .Include(p => p.Passenger)
                .Include(r => r.Route)
                .FirstOrDefaultAsync();
            var ticketModel = _mapper.Map<TicketModel>(ticketEntity);
            return ticketModel;
        }

        public async Task<Guid> Update(TicketModel ticketModel)
        {
            var ticket = _mapper.Map<TicketEntity>(ticketModel);
            await _dbRepository.Update(ticket);
            await _dbRepository.SaveChangesAsync();
            return ticket.Id;
        }

        public async Task Delete(Guid id)
        {
            await _dbRepository.Delete<TicketEntity>(id);
            await _dbRepository.SaveChangesAsync();
        }
    }
}