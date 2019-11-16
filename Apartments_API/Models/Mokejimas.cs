using System;
using System.Collections.Generic;

namespace Apartments_API.Models
{
    public partial class Mokejimas
    {
        public DateTime? Data { get; set; }
        public decimal? Suma { get; set; }
        public int IdMokejimas { get; set; }
        public int FkNuomininkasidIsNaudotojas { get; set; }

        public virtual Nuomininkas FkNuomininkasidIsNaudotojasNavigation { get; set; }
    }
}
