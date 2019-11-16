using System;
using System.Collections.Generic;

namespace Apartments_API.Models
{
    public partial class Privalumas
    {
        public string Pavadinimas { get; set; }
        public int IdPrivalumas { get; set; }
        public int FkButasidButas { get; set; }

        public virtual Butas FkButasidButasNavigation { get; set; }
    }
}
