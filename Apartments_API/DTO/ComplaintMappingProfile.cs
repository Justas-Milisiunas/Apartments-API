using Apartments_API.Models;
using AutoMapper;

namespace Apartments_API.DTO
{
    public class ComplaintMappingProfile : Profile
    {
        public ComplaintMappingProfile()
        {
            CreateMap<Skundas, ComplaintDto>();
            CreateMap<ComplaintWriteDto, Skundas>();
        }
    }
}