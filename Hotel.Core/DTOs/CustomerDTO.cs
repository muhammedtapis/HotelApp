using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Core.DTOs
{
    public class CustomerDTO : BaseDTO
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string PassportNo { get; set; }
        public string Address { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
    }
}