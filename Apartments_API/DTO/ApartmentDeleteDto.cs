using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace Apartments_API.DTO
{
    public class ApartmentDeleteDto
    {
        [Required] public int? IdButas { get; set; }
        [Required] public int? FkSavininkasidIsNaudotojas { get; set; }
    }
}
