using System.ComponentModel.DataAnnotations;

namespace Apartments_API.DTO
{
    public class JobAcceptDto
    {
        [Required]
        public int JobID {get; set;}

        [Required]
        public int IsUserID {get; set;}
    }
}