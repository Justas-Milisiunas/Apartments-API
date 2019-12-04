using System;
using System.ComponentModel.DataAnnotations;

namespace Apartments_API.DTO
{
    public class BookingDto
    {
        [Required] public DateTime Nuo { get; set; }
        [Required] public DateTime Iki { get; set; }
        [Required] public int FkNuomininkasidIsNaudotojas { get; set; }
        [Required] public int FkButasidButas { get; set; }
    }
}