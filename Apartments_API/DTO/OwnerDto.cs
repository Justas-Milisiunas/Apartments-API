using System.Collections.Generic;
using Apartments_API.Models;

namespace Apartments_API.DTO
{
    public class OwnerDto
    {
        public int IdIsNaudotojas { get; set; }

        public virtual UserDto IdIsNaudotojasNavigation { get; set; }
    }
}