using System.ComponentModel.DataAnnotations;

namespace Apartments_API.DTO
{
    public class UserCreateDto
    {
        [Required, MinLength(4), StringLength(255)]
        public string Vardas { get; set; }
        [Required, MinLength(4), StringLength(255), DataType(DataType.EmailAddress)]
        public string ElPastas { get; set; }
        [Required, MinLength(4), StringLength(255)]
        public string Pavarde { get; set; }
        [Required, MinLength(4), StringLength(255)]
        public string Slaptazodis { get; set; }
        [Required, Range(0, 2)]
        public int Role { get; set; }
    }
}