using static System.Runtime.InteropServices.JavaScript.JSType;
using AutoMapper;
using Domain.Entities;
using WebAppConcesionaria.Models;

namespace WebAppConcesionaria.Mappings
{

    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {

            CreateMap<Vehiculo, VehiculoDTO>()
                .ForMember(dest => dest.Vehiculo, input => input.MapFrom(i => i.Id))
                .ReverseMap();

            CreateMap<VehiculoDTO, Vehiculo>()
                .ForMember(dest => dest.Id, input => input.MapFrom(i => i.Vehiculo))
                .ReverseMap();
        }
    }
}
