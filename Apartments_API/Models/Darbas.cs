using System;
using System.Collections.Generic;

namespace Apartments_API.Models
{
    public partial class Darbas
    {
        public DateTime? SukurimoData { get; set; }
        public DateTime? IvykdymoData { get; set; }
        public decimal? Uzmokestis { get; set; }
        public int? Busena { get; set; }
        public int IdDarbas { get; set; }
        public int FkButasidButas { get; set; }
        public int FkSavininkasidIsNaudotojas { get; set; }
        public int? FkValytojasidIsNaudotojas { get; set; }

        public virtual DarboBusena BusenaNavigation { get; set; }
        public virtual Butas FkButasidButasNavigation { get; set; }
        public virtual Savininkas FkSavininkasidIsNaudotojasNavigation { get; set; }
        public virtual Valytojas FkValytojasidIsNaudotojasNavigation { get; set; }
    }
}
