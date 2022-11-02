using AutoMapper;
using CarService.Models;
using CarService.ViewModels;

namespace CarService.Mapping
{
    public class OwnerProfile : Profile
    {
        public OwnerProfile()
        {
            CreateMap<Owner, OwnerViewModel>().ReverseMap();
        }
    }
}