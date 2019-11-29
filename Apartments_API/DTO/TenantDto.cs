using System.Collections.Generic;
using Apartments_API.Models;

namespace Apartments_API.DTO
{
    public class TenantDto
    {
        public virtual ICollection<Mokejimas> Mokejimas { get; set; }
        public virtual ICollection<NuomosLaikotarpis> NuomosLaikotarpis { get; set; }
        public virtual ICollection<Reitingas> Reitingas { get; set; }
        public virtual ICollection<Skundas> Skundas { get; set; }
    }
}