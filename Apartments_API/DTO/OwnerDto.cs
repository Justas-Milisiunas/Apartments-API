using System.Collections.Generic;
using Apartments_API.Models;

namespace Apartments_API.DTO
{
    public class OwnerDto
    {
        public virtual ICollection<Butas> Butas { get; set; }
        public virtual ICollection<Darbas> Darbas { get; set; }
    }
}