using System;
using System.Collections.Generic;

namespace Apartments_API.Models
{
    public partial class DarboBusena
    {
        public DarboBusena()
        {
            Darbas = new HashSet<Darbas>();
        }

        public int IdDarboBusena { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Darbas> Darbas { get; set; }
    }
}
