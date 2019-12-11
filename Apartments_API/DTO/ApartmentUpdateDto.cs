using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Apartments_API.DTO
{
    public class ApartmentUpdateDto
    {
        [Required]
        public int Dydis { get; set; }

        [Required]
        public int KambaruSkaicius { get; set; }

        [Required]
        public decimal KainaUzNakti { get; set; }
        [Required]
        public string Adresas { get; set; }
        [Required]
        public string NuotraukaUrl { get; set; }
        [Required]
        public string Aprašas { get; set; }
        [Required]
        public string Pavadinimas { get; set; }
        [Required]
        public string Miestas { get; set; }
        [Required]
        public string Šalis { get; set; }
        [Required]
        public int FkSavininkasidIsNaudotojas { get; set; }
        [Required]
        public int idButas { get; set; }
    }
}
