using AutoMapper;
using CarService.Models;
using CarService.ViewModels;

namespace CarService.Mapping
{
    public class VehicleProfile : Profile
    {
        public VehicleProfile()
        {
            CreateMap<Vehicle, VehicleViewModel>();
            CreateMap<VehicleViewModel, Vehicle>()
                .ForMember(x => x.OwnerId, opt => opt.MapFrom(y => y.Owner.Id))
                .ForMember(x => x.Owner, opt => opt.Ignore());

            CreateMap<Service, ServiceViewModel>();
            CreateMap<ServiceViewModel, Service>()
                .ForMember(x => x.Vehicle, opt => opt.Ignore());
        }
    }
}