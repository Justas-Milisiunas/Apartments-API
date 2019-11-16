using System;
using System.Collections.Generic;

namespace Apartments_API.Models
{
    public partial class Skundas
    {
        public DateTime? Data { get; set; }
        public string Pranesimas { get; set; }
        public int IdSkundas { get; set; }
        public int FkButasidButas { get; set; }
        public int FkNuomininkasidIsNaudotojas { get; set; }

        public virtual Butas FkButasidButasNavigation { get; set; }
        public virtual Nuomininkas FkNuomininkasidIsNaudotojasNavigation { get; set; }
    }
}
