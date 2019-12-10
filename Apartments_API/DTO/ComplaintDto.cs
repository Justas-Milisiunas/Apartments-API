using System;
using System.ComponentModel.DataAnnotations;
using Apartments_API.Models;
using Microsoft.VisualBasic.CompilerServices;

namespace Apartments_API.DTO
{
    public class ComplaintDto
    {
        public DateTime? Data { get; set; }
        public string Pranesimas { get; set; }
        public int IdSkundas { get; set; }
        public int FkButasidButas { get; set; }
        public int FkNuomininkasidIsNaudotojas { get; set; }
    }
}