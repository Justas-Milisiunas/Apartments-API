using Apartments_API.Models;
using AutoMapper;

namespace Apartments_API.DTO
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<IsNaudotojas, UserCreateDto>();
            CreateMap<UserCreateDto, IsNaudotojas>();
            CreateMap<Nuomininkas, TenantDto>();
            CreateMap<Savininkas, OwnerDto>();
            CreateMap<Valytojas, WorkerDto>();
            CreateMap<IsNaudotojas, UserDto>()
                .ForMember(dest => dest.Role, opt => opt.MapFrom(src =>
                    (src.Nuomininkas != null) ? 0
                    : (src.Savininkas != null) ? 1
                    : (src.Valytojas != null) ? 2 : 0));
        }
    }
}