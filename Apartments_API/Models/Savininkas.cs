using System;
using System.Collections.Generic;
using Apartments_API.DTO;

namespace Apartments_API.Models
{
    public partial class Savininkas
    {
        public Savininkas()
        {
            Butas = new HashSet<Butas>();
            Darbas = new HashSet<Darbas>();
        }

        public int IdIsNaudotojas { get; set; }

        public virtual IsNaudotojas IdIsNaudotojasNavigation { get; set; }
        public virtual ICollection<Butas> Butas { get; set; }
        public virtual ICollection<Darbas> Darbas { get; set; }
    }
}
