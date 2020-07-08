using AutoMapper;
using MiniBusCrm.DataAccess.Contracts.Entities;
using MiniBusCrm.Domain.Contracts.Models;

namespace MiniBusCrm.Domain.Implementations.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<BusModel, BusEntity>();
            CreateMap<DriverModel, DriverEntity>();
            CreateMap<OrderModel, OrderEntity>();
            CreateMap<PassangerModel, PassangerEntity>();
            CreateMap<RouteModel, RouteEntity>();
            CreateMap<TicketModel, TicketEntity>();

            CreateMap<BusEntity, BusModel>();
            CreateMap<DriverEntity, DriverModel>();
            CreateMap<OrderEntity, OrderModel>();
            CreateMap<PassangerEntity, PassangerModel>();
            CreateMap<RouteEntity, RouteModel>();
            CreateMap<TicketEntity, TicketModel>();
        }
    }
}
