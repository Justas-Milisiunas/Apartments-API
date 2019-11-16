using System;
using System.Collections.Generic;

namespace Apartments_API.Models
{
    public partial class ButoLaikotarpioBusena
    {
        public ButoLaikotarpioBusena()
        {
            NuomosLaikotarpis = new HashSet<NuomosLaikotarpis>();
        }

        public int IdButoLaikotarpioBusena { get; set; }
        public string Name { get; set; }

        public virtual ICollection<NuomosLaikotarpis> NuomosLaikotarpis { get; set; }
    }
}
