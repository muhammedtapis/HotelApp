using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Core.DTOs
{
    public class RoomDTO : BaseDTO
    {
        public int RoomNo { get; set; }
        public bool IsAvailable { get; set; }
        public decimal Price { get; set; }

        //navigation prop.
        public int FloorId { get; set; }
    }
}