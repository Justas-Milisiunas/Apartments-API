using System;

namespace Apartments_API.DTO
{
    public class ReportDto
    {
        public DateTime From {get; set;}
        public DateTime To {get; set; }
        public int UserID {get; set;}
        public bool Email { get; set; }
    }
}