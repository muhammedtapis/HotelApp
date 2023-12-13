using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Core.DTOs
{
    public class BedDTO : BaseDTO
    {
        public int BedNumber { get; set; }
        public int RoomId { get; set; }
    }
}