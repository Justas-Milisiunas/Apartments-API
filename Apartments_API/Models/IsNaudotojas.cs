using System;
using System.Collections.Generic;
using Apartments_API.DTO;

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

        public IsNaudotojas()
        {
            
        }

        public IsNaudotojas(UserCreateDto userCreateDto)
        {
            Vardas = userCreateDto.Vardas;
            Pavarde = userCreateDto.Pavarde;
            ElPastas = userCreateDto.ElPastas;
            Slaptazodis = userCreateDto.Slaptazodis;

            Balansas = 0;
            RegistracijosData = DateTime.UtcNow;
            PaskutinisPrisijungimas = DateTime.Now;
        }
    }
}
