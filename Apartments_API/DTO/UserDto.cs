using Apartments_API.Models;

namespace Apartments_API.DTO
{
    public class UserDto
    {
        public int IdIsNaudotojas { get; set; }
        public string Vardas { get; set; }
        public string ElPastas { get; set; }
        public string Pavarde { get; set; }
        public decimal? Balansas { get; set; }
        public int Role { get; set; }
        
        public virtual TenantDto Nuomininkas { get; set; }
        public virtual OwnerDto Savininkas { get; set; }
        public virtual WorkerDto Valytojas { get; set; }
    }
}