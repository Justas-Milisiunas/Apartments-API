using System;
using Apartments_API.Models;

namespace Apartments_API.DTO
{
    public class RentIntervalDto
    {
        public DateTime? Nuo { get; set; }
        public DateTime? Iki { get; set; }
        public int? Busena { get; set; }
        public int IdNuomosLaikotarpis { get; set; }
        public int FkNuomininkasidIsNaudotojas { get; set; }
    }
}