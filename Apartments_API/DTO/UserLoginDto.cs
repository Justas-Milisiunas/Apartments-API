using System.ComponentModel.DataAnnotations;

namespace Apartments_API.DTO
{
    public class UserLoginDto
    {
        [Required, MinLength(4), StringLength(255), DataType(DataType.EmailAddress)]
        public string ElPastas { get; set; }
        [Required, MinLength(4), StringLength(255)]
        public string Slaptazodis { get; set; }
    }
}