using System.ComponentModel.DataAnnotations;

namespace Apartments_API.DTO
{
    public class RatingDto
    {
        [Required] public int? Ivertinimas { get; set; }
        [Required] public int? FkButasidButas { get; set; }
        [Required] public int? FkNuomininkasidIsNaudotojas { get; set; }
    }
}