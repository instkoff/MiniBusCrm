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
            CreateMap<BusDriverModel, BusDriverEntity>();
            CreateMap<PlaneModel, PlaneEntity>();
            CreateMap<PassengerModel, PassengerEntity>();
            CreateMap<RouteModel, RouteEntity>();
            CreateMap<TicketModel, TicketEntity>();

            CreateMap<BusEntity, BusModel>();
            CreateMap<BusDriverEntity, BusDriverModel>();
            CreateMap<PlaneEntity, PlaneModel>()
                .ForMember(dest => dest.RouteId, opt => opt.MapFrom(src => src.Route.Id));
            CreateMap<PassengerEntity, PassengerModel>();
            CreateMap<RouteEntity, RouteModel>()
                .ForMember(dest=>dest.DriverId, opt=>opt.MapFrom(src=>src.BusDriver.Id))
                .ForMember(dest=>dest.BusId, opt=>opt.MapFrom(src=>src.Bus.Id));
            CreateMap<TicketEntity, TicketModel>()
                .ForMember(dest => dest.RouteId, opt => opt.MapFrom(src => src.Route.Id))
                .ForMember(dest=>dest.PlaneId, opt=>opt.MapFrom(src=>src.Plane.Id));
        }
    }
}