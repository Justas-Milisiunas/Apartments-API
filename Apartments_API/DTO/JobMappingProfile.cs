using Apartments_API.Models;
using AutoMapper;

namespace Apartments_API.DTO
{
    public class JobMappingProfile : Profile
    {
        public JobMappingProfile()
        {
            CreateMap<Darbas, JobDto>();
            CreateMap<DarboBusena, JobStateDto>();
            CreateMap<Darbas, JobAcceptDto>();
            CreateMap<Darbas, JobDto>()
            .ForMember(dest => dest.Valytojas,
                opt => opt.MapFrom(src => src.FkValytojasidIsNaudotojasNavigation))
            .ForMember(dest => dest.Butas,
                opt => opt.MapFrom(src => src.FkButasidButasNavigation));
        }
    }
}