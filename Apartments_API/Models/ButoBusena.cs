using System;
using System.Collections.Generic;

namespace Apartments_API.Models
{
    public partial class ButoBusena
    {
        public ButoBusena()
        {
            Butas = new HashSet<Butas>();
        }

        public int IdButoBusena { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Butas> Butas { get; set; }
    }
}
