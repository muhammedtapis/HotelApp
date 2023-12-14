using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Core.DTOs
{
    public class PaymentDTO : BaseDTO
    {
        public decimal Amount { get; set; }
        public bool IsPayed { get; set; }
    }
}