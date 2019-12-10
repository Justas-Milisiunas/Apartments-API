using System;
using System.Collections.Generic;

namespace Apartments_API.Models
{
    public partial class NuomosLaikotarpis
    {
        public DateTime? Nuo { get; set; }
        public DateTime? Iki { get; set; }
        public int? Busena { get; set; }
        public int IdNuomosLaikotarpis { get; set; }
        public int? FkNuomininkasidIsNaudotojas { get; set; }
        public int FkButasidButas { get; set; }

        public virtual ButoLaikotarpioBusena BusenaNavigation { get; set; }
        public virtual Butas FkButasidButasNavigation { get; set; }
        public virtual Nuomininkas FkNuomininkasidIsNaudotojasNavigation { get; set; }
    }
}
