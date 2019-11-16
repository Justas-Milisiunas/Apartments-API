using System;
using System.Collections.Generic;

namespace Apartments_API.Models
{
    public partial class Nuomininkas
    {
        public Nuomininkas()
        {
            Mokejimas = new HashSet<Mokejimas>();
            NuomosLaikotarpis = new HashSet<NuomosLaikotarpis>();
            Reitingas = new HashSet<Reitingas>();
            Skundas = new HashSet<Skundas>();
        }

        public int IdIsNaudotojas { get; set; }

        public virtual IsNaudotojas IdIsNaudotojasNavigation { get; set; }
        public virtual ICollection<Mokejimas> Mokejimas { get; set; }
        public virtual ICollection<NuomosLaikotarpis> NuomosLaikotarpis { get; set; }
        public virtual ICollection<Reitingas> Reitingas { get; set; }
        public virtual ICollection<Skundas> Skundas { get; set; }
    }
}
