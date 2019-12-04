using System;
using System.Collections.Generic;
using Apartments_API.Models;

namespace Apartments_API.DTO
{
    // TODO: Add status dto
    public class ApartmentDto
    {
        public int? Dydis { get; set; }
        public int? KambaruSkaicius { get; set; }
        public DateTime? PridejimoData { get; set; }
        public decimal? KainaUzNakti { get; set; }
        public string Adresas { get; set; }
        public string Nuotrauka { get; set; }
        public string NuotraukaUrl => "http://10.0.2.2:5000/api/photos/" + Nuotrauka;
        public string Aprašas { get; set; }
        public string Pavadinimas { get; set; }
        public string Miestas { get; set; }
        public string Šalis { get; set; }
        public int? Busena { get; set; }
        public int IdButas { get; set; }
        public int FkSavininkasidIsNaudotojas { get; set; }

        public virtual ApartmentStatusDto Status { get; set; }
        public virtual OwnerDto Savininkas { get; set; }
        public virtual ICollection<Darbas> Darbas { get; set; }
        public virtual ICollection<RentIntervalDto> NuomosLaikotarpis { get; set; }
        public virtual ICollection<Privalumas> Privalumas { get; set; }
        public virtual ICollection<Reitingas> Reitingas { get; set; }
        public virtual ICollection<Skundas> Skundas { get; set; }
    }
}