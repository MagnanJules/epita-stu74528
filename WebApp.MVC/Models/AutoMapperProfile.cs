using AutoMapper;
using Microsoft.EntityFrameworkCore.Design;
using WebApp.Domain.Models;

namespace WebApp.MVC.Models
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<BikeStation,BikeStationDTO>().ForMember(dest=>dest.BikeStationId, act=> act.MapFrom(src=>src.number));

            // ForMember(dest => dest.x, act => act.MapFrom(src => src.x));

        }
    }
}
