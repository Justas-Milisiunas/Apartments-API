using System.ComponentModel.DataAnnotations;

namespace Apartments_API.DTO
{
    public class ComplaintWriteDto
    {
        [Required, MinLength(4), MaxLength(255)]
        public string Pranesimas { get; set; }

        [Required] public int FkButasidButas { get; set; }
        [Required] public int FkNuomininkasidIsNaudotojas { get; set; }
    }
}