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
            CreateMap<JourneyModel, JourneyEntity>();
            CreateMap<PassangerModel, PassangerEntity>();
            CreateMap<RouteModel, RouteEntity>();
            CreateMap<TicketModel, TicketEntity>();

            CreateMap<BusEntity, BusModel>();
            CreateMap<DriverEntity, DriverModel>();
            CreateMap<JourneyEntity, JourneyModel>()
                .ForMember(dest => dest.RouteId, opt => opt.MapFrom(src => src.Route.Id));
            CreateMap<PassangerEntity, PassangerModel>();
            CreateMap<RouteEntity, RouteModel>()
                .ForMember(dest=>dest.DriverId, opt=>opt.MapFrom(src=>src.Driver.Id))
                .ForMember(dest=>dest.BusId, opt=>opt.MapFrom(src=>src.Bus.Id));
            CreateMap<TicketEntity, TicketModel>()
                .ForMember(dest => dest.RouteId, opt => opt.MapFrom(src => src.Route.Id))
                .ForMember(dest=>dest.JourneyId, opt=>opt.MapFrom(src=>src.Journey.Id));
        }
    }
}