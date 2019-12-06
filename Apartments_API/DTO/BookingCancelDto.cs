using System.ComponentModel.DataAnnotations;

namespace Apartments_API.DTO
{
    public class BookingCancelDto
    {
        [Required] public int? RentPeriodId { get; set; }
        [Required] public int? TenantId { get; set; }
    }
}