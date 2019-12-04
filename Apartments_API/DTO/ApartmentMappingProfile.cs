using Apartments_API.Models;
using AutoMapper;

namespace Apartments_API.DTO
{
    public class ApartmentMappingProfile : Profile
    {
        public ApartmentMappingProfile()
        {
            CreateMap<Butas, ApartmentDto>()
                .ForMember(dest => dest.Savininkas,
                    opt => opt.MapFrom(src => src.FkSavininkasidIsNaudotojasNavigation))
                .ForMember(dest => dest.Nuotrauka, opt => opt.MapFrom(src => src.NuotraukaUrl))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.BusenaNavigation));
            CreateMap<Savininkas, OwnerDto>();
            CreateMap<NuomosLaikotarpis, RentIntervalDto>();
            CreateMap<ButoBusena, ApartmentStatusDto>();
        }
    }
}