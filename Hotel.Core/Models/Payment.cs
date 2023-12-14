using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Core.Models
{
    public class Payment : BaseEntity
    {
        public decimal Amount { get; set; }
        public bool IsPayed { get; set; }

        //navigation prop.
        //public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; } //one to one with
    }
}