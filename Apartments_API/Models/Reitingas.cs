using System;
using System.Collections.Generic;

namespace Apartments_API.Models
{
    public partial class Reitingas
    {
        public DateTime? Data { get; set; }
        public int? Ivertinimas { get; set; }
        public int IdReitingas { get; set; }
        public int FkButasidButas { get; set; }
        public int FkNuomininkasidIsNaudotojas { get; set; }

        public virtual Butas FkButasidButasNavigation { get; set; }
        public virtual Nuomininkas FkNuomininkasidIsNaudotojasNavigation { get; set; }
    }
}
