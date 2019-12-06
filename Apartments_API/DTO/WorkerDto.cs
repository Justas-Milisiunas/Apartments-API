using System.Collections.Generic;
using Apartments_API.Models;

namespace Apartments_API.DTO
{
    public class WorkerDto
    {
        public virtual IsNaudotojas IdIsNaudotojasNavigation { get; set; }

        public virtual ICollection<Darbas> Darbas { get; set; }
    }
}