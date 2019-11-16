using System;
using System.Collections.Generic;

namespace Apartments_API.Models
{
    public partial class IsNaudotojas
    {
        public string Vardas { get; set; }
        public string ElPastas { get; set; }
        public string Pavarde { get; set; }
        public DateTime? PaskutinisPrisijungimas { get; set; }
        public DateTime? RegistracijosData { get; set; }
        public string Slaptazodis { get; set; }
        public decimal? Balansas { get; set; }
        public int IdIsNaudotojas { get; set; }

        public virtual Nuomininkas Nuomininkas { get; set; }
        public virtual Savininkas Savininkas { get; set; }
        public virtual Valytojas Valytojas { get; set; }
    }
}
