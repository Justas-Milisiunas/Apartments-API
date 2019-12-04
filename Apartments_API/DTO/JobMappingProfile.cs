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
        }
    }
}