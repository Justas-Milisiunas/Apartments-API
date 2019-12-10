using System;

namespace Apartments_API.DTO
{
    public class JobDto
    {
        public DateTime? SukurimoData { get; set; }
        public DateTime? IvykdymoData { get; set; }
        public decimal? Uzmokestis { get; set; }
        public int? Busena { get; set; }
        public int IdDarbas { get; set; }
        public int FkButasidButas { get; set; }
        public int FkSavininkasidIsNaudotojas { get; set; }
        public int? FkValytojasidIsNaudotojas { get; set; }

        public virtual JobStateDto DarboBusena { get; set; }
        public virtual ApartmentDto Butas {get; set;}

    }
}