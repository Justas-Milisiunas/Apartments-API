using System.Collections.Generic;
using Apartments_API.Models;

namespace Apartments_API.DTO
{
    public class WorkerDto
    {
        public virtual ICollection<Darbas> Darbas { get; set; }
    }
}